using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkingLotSystem.Data;
using ParkingLotSystem.Models;

namespace ParkingLotSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ParkingLotSystemContext _context;

        public IndexModel(ParkingLotSystemContext context)
        {
            _context = context;
        }

        public int ParkingLotCount { get; set; }
        public int SubscriptionPlanCount { get; set; }
        public int SubscriberCount { get; set; }
        public int SubscriptionCount { get; set; }
        public int ActiveSubscriptionCount { get; set; }

        public IList<Subscription> UpcomingExpirations { get; set; } = new List<Subscription>();

        public async Task OnGetAsync()
        {
            var today = DateTime.Today;

            ParkingLotCount = await _context.ParkingLot.AsNoTracking().CountAsync();
            SubscriptionPlanCount = await _context.SubscriptionPlan.AsNoTracking().CountAsync();
            SubscriberCount = await _context.Subscriber.AsNoTracking().CountAsync();
            SubscriptionCount = await _context.Subscription.AsNoTracking().CountAsync();

            // Active = not expired (lab-style)
            ActiveSubscriptionCount = await _context.Subscription
                .AsNoTracking()
                .CountAsync(s => s.EndDate >= today);

            // Show next expiring subscriptions (top 5)
            UpcomingExpirations = await _context.Subscription
                .Include(s => s.Subscriber)
                .Include(s => s.SubscriptionPlan)
                .AsNoTracking()
                .Where(s => s.EndDate >= today)
                .OrderBy(s => s.EndDate)
                .Take(5)
                .ToListAsync();
        }
    }
}