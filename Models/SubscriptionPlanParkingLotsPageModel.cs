using Microsoft.AspNetCore.Mvc.RazorPages;
using ParkingLotSystem.Data;

namespace ParkingLotSystem.Models
{
    public class SubscriptionPlanParkingLotsPageModel : PageModel
    {
        public List<AssignedParkingLotData> AssignedParkingLotDataList { get; set; } = new();

        public void PopulateAssignedParkingLotData(ParkingLotSystemContext context, SubscriptionPlan plan)
        {
            var allLots = context.ParkingLot;
            var planLots = new HashSet<int>(plan.PlanParkingLots.Select(x => x.ParkingLotID));

            AssignedParkingLotDataList = new List<AssignedParkingLotData>();
            foreach (var lot in allLots)
            {
                AssignedParkingLotDataList.Add(new AssignedParkingLotData
                {
                    ParkingLotID = lot.ID,
                    Name = lot.Name,
                    Assigned = planLots.Contains(lot.ID)
                });
            }
        }

        public void UpdatePlanParkingLots(ParkingLotSystemContext context, string[] selectedParkingLots, SubscriptionPlan planToUpdate)
        {
            selectedParkingLots ??= Array.Empty<string>();

            var selectedHS = new HashSet<string>(selectedParkingLots);
            var currentLotIDs = new HashSet<int>(planToUpdate.PlanParkingLots.Select(x => x.ParkingLotID));

            foreach (var lot in context.ParkingLot)
            {
                var lotIdStr = lot.ID.ToString();

                if (selectedHS.Contains(lotIdStr))
                {
                    if (!currentLotIDs.Contains(lot.ID))
                    {
                        planToUpdate.PlanParkingLots.Add(new PlanParkingLot
                        {
                            ParkingLotID = lot.ID,
                            SubscriptionPlanID = planToUpdate.ID
                        });
                    }
                }
                else
                {
                    if (currentLotIDs.Contains(lot.ID))
                    {
                        var toRemove = planToUpdate.PlanParkingLots
                            .SingleOrDefault(x => x.ParkingLotID == lot.ID);

                        if (toRemove != null)
                            context.Remove(toRemove);
                    }
                }
            }
        }
    }
}