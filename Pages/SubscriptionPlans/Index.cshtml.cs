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
    public class IndexModel : PageModel
    {
        private readonly ParkingLotSystem.Data.ParkingLotSystemContext _context;

        public IndexModel(ParkingLotSystem.Data.ParkingLotSystemContext context)
        {
            _context = context;
        }

        public IList<Models.SubscriptionPlan> SubscriptionPlan { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SubscriptionPlan = await _context.SubscriptionPlan.ToListAsync();
        }
    }
}
