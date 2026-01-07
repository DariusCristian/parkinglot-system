using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingLotSystem.Data;
using ParkingLotSystem.Models;

namespace ParkingLotSystem.Pages.SubscriptionPlans
{
    public class EditModel : SubscriptionPlanParkingLotsPageModel
    {
        private readonly ParkingLotSystemContext _context;

        public EditModel(ParkingLotSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubscriptionPlan SubscriptionPlan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            SubscriptionPlan = await _context.SubscriptionPlan
                .Include(p => p.PlanParkingLots)
                .ThenInclude(pp => pp.ParkingLot)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (SubscriptionPlan == null) return NotFound();

            PopulateAssignedParkingLotData(_context, SubscriptionPlan);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[]? selectedParkingLots)
        {
            if (id == null) return NotFound();

            var planToUpdate = await _context.SubscriptionPlan
                .Include(p => p.PlanParkingLots)
                    .ThenInclude(pp => pp.ParkingLot)
                .FirstOrDefaultAsync(p => p.ID == id);

            if (planToUpdate == null) return NotFound();

            if (await TryUpdateModelAsync(
                    planToUpdate,
                    "SubscriptionPlan",
                    p => p.Name, p => p.MonthlyPrice, p => p.DurationDays))
            {
                UpdatePlanParkingLots(_context, selectedParkingLots ?? Array.Empty<string>(), planToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdatePlanParkingLots(_context, selectedParkingLots ?? Array.Empty<string>(), planToUpdate);
            PopulateAssignedParkingLotData(_context, planToUpdate);
            return Page();
        }
    }
}