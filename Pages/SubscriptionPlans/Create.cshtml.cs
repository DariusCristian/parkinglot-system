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
        public SubscriptionPlan SubscriptionPlan { get; set; } = new();

        public IActionResult OnGet()
        {
            SubscriptionPlan.PlanParkingLots = new List<PlanParkingLot>();
            PopulateAssignedParkingLotData(_context, SubscriptionPlan);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string[]? selectedParkingLots)
        {
            if (!ModelState.IsValid)
            {
                SubscriptionPlan.PlanParkingLots = new List<PlanParkingLot>();
                PopulateAssignedParkingLotData(_context, SubscriptionPlan);
                return Page();
            }

            SubscriptionPlan.PlanParkingLots = new List<PlanParkingLot>();
            foreach (var lotId in selectedParkingLots ?? Array.Empty<string>())
            {
                SubscriptionPlan.PlanParkingLots.Add(new PlanParkingLot
                {
                    ParkingLotID = int.Parse(lotId)
                });
            }

            _context.SubscriptionPlan.Add(SubscriptionPlan);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}