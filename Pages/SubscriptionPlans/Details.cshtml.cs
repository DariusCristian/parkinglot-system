using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkingLotSystem.Data;
using ParkingLotSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace ParkingLotSystem.Pages.SubscriptionPlans
{
    public class DetailsModel : PageModel
    {
        private readonly ParkingLotSystem.Data.ParkingLotSystemContext _context;

        public DetailsModel(ParkingLotSystem.Data.ParkingLotSystemContext context)
        {
            _context = context;
        }

        public Models.SubscriptionPlan SubscriptionPlan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptionplan = await _context.SubscriptionPlan
                .Include(p => p.PlanParkingLots)
                    .ThenInclude(pp => pp.ParkingLot)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

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
    }
}
