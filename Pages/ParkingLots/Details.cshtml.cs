using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkingLotSystem.Data;
using ParkingSystem.Models;

namespace ParkingLotSystem.Pages.ParkingLots
{
    public class DetailsModel : PageModel
    {
        private readonly ParkingLotSystem.Data.ParkingLotSystemContext _context;

        public DetailsModel(ParkingLotSystem.Data.ParkingLotSystemContext context)
        {
            _context = context;
        }

        public ParkingLot ParkingLot { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkinglot = await _context.ParkingLot.FirstOrDefaultAsync(m => m.ID == id);
            if (parkinglot == null)
            {
                return NotFound();
            }
            else
            {
                ParkingLot = parkinglot;
            }
            return Page();
        }
    }
}
