using Microsoft.AspNetCore.Mvc;
using ParkingLotSystem.Data;
using ParkingLotSystem.Models;

namespace ParkingLotSystem.Pages.SubscriptionPlans
{
    public class CreateModel : SubscriptionPlanParkingLotsPageModel
    {
        private readonly ParkingLotSystemContext _context;

        public CreateModel(ParkingLotSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubscriptionPlan SubscriptionPlan { get; set; } = new SubscriptionPlan();

        public IActionResult OnGet()
        {
            var plan = new SubscriptionPlan();
            PopulateAssignedParkingLotData(_context, plan);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string[]? selectedParkingLots)
        {
            var newPlan = new SubscriptionPlan();

            if (selectedParkingLots != null)
            {
                newPlan.PlanParkingLots = new List<PlanParkingLot>();
                foreach (var lotId in selectedParkingLots)
                {
                    newPlan.PlanParkingLots.Add(new PlanParkingLot
                    {
                        ParkingLotID = int.Parse(lotId)
                    });
                }
            }

            if (await TryUpdateModelAsync(
                    newPlan,
                    "SubscriptionPlan",
                    p => p.Name, p => p.MonthlyPrice, p => p.DurationDays))
            {
                _context.SubscriptionPlan.Add(newPlan);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // If validation fails, repopulate checkbox list
            PopulateAssignedParkingLotData(_context, newPlan);
            return Page();
        }
    }
}
