using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkingLotSystem.Data;
using ParkingLotSystem.Models.ViewModels;

namespace ParkingLotSystem.Pages.ParkingLots
{
    public class IndexModel : PageModel
    {
        private readonly ParkingLotSystemContext _context;

        public IndexModel(ParkingLotSystemContext context)
        {
            _context = context;
        }

        public ParkingLotIndexData ParkingLotData { get; set; } = new ParkingLotIndexData();
        public int ParkingLotID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            ParkingLotData.ParkingLots = await _context.ParkingLot
                .Include(l => l.PlanParkingLots)
                    .ThenInclude(pl => pl.SubscriptionPlan)
                .AsNoTracking()
                .OrderBy(l => l.Name)
                .ToListAsync();

            if (id != null)
            {
                ParkingLotID = id.Value;

                var selectedLot = ParkingLotData.ParkingLots
                    .Single(l => l.ID == id.Value);

                ParkingLotData.SubscriptionPlans = selectedLot.PlanParkingLots
                    .Select(pl => pl.SubscriptionPlan!)
                    .OrderBy(p => p.Name)
                    .ToList();
            }
        }
    }
}