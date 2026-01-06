using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingLotSystem.Data;
using ParkingLotSystem.Models;

namespace ParkingLotSystem.Pages.Subscriptions
{
    public class EditModel : PageModel
    {
        private readonly ParkingLotSystem.Data.ParkingLotSystemContext _context;

        public EditModel(ParkingLotSystem.Data.ParkingLotSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subscription Subscription { get; set; } = default!;

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Subscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionExists(Subscription.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SubscriptionExists(int id)
        {
            return _context.Subscription.Any(e => e.ID == id);
        }
    }
}
