using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkingLotSystem.Data;
using ParkingLotSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace ParkingLotSystem.Pages.ParkingLots
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ParkingLotSystem.Data.ParkingLotSystemContext _context;

        public CreateModel(ParkingLotSystem.Data.ParkingLotSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ParkingLot ParkingLot { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ParkingLot.Add(ParkingLot);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
