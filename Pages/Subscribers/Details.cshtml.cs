using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkingLotSystem.Data;
using ParkingLotSystem.Models;

namespace ParkingLotSystem.Pages.Subscribers
{
    public class DetailsModel : PageModel
    {
        private readonly ParkingLotSystem.Data.ParkingLotSystemContext _context;

        public DetailsModel(ParkingLotSystem.Data.ParkingLotSystemContext context)
        {
            _context = context;
        }

        public Subscriber Subscriber { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.Subscriber.FirstOrDefaultAsync(m => m.ID == id);
            if (subscriber == null)
            {
                return NotFound();
            }
            else
            {
                Subscriber = subscriber;
            }
            return Page();
        }
    }
}
