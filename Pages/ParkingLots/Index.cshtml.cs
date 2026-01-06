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
    public class IndexModel : PageModel
    {
        private readonly ParkingLotSystem.Data.ParkingLotSystemContext _context;

        public IndexModel(ParkingLotSystem.Data.ParkingLotSystemContext context)
        {
            _context = context;
        }

        public IList<ParkingLot> ParkingLot { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ParkingLot = await _context.ParkingLot.ToListAsync();
        }
    }
}
