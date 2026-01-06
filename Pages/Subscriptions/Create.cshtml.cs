using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkingLotSystem.Data;
using ParkingLotSystem.Models;

namespace ParkingLotSystem.Pages.Subscriptions
{
    public class CreateModel : PageModel
    {
        private readonly ParkingLotSystem.Data.ParkingLotSystemContext _context;

        public CreateModel(ParkingLotSystem.Data.ParkingLotSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var planList = _context.SubscriptionPlan
                .Select(p => new
                {
                    p.ID,
                    PlanDisplay = p.Name + " - " + p.MonthlyPrice + " / " + p.DurationDays + " days"
                });

            ViewData["SubscriptionPlanID"] = new SelectList(planList, "ID", "PlanDisplay");
            ViewData["SubscriberID"] = new SelectList(_context.Subscriber, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Subscription Subscription { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Subscription.Add(Subscription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
