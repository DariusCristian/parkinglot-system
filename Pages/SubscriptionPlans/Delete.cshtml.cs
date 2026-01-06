using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkingLotSystem.Data;
using ParkingLotSystem.Models;

namespace ParkingLotSystem.Pages.SubscriptionPlans
{
    public class DeleteModel : PageModel
    {
        private readonly ParkingLotSystem.Data.ParkingLotSystemContext _context;

        public DeleteModel(ParkingLotSystem.Data.ParkingLotSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.SubscriptionPlan SubscriptionPlan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptionplan = await _context.SubscriptionPlan.FirstOrDefaultAsync(m => m.ID == id);

            if (subscriptionplan == null)
            {
                return NotFound();
            }
            else
            {
                SubscriptionPlan = subscriptionplan;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptionplan = await _context.SubscriptionPlan.FindAsync(id);
            if (subscriptionplan != null)
            {
                SubscriptionPlan = subscriptionplan;
                _context.SubscriptionPlan.Remove(SubscriptionPlan);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
