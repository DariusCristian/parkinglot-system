using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkingLotSystem.Data;
using ParkingLotSystem.Models.ViewModels;

namespace ParkingLotSystem.Pages.SubscriptionPlans
{
    public class IndexModel : PageModel
    {
        private readonly ParkingLotSystemContext _context;

        public IndexModel(ParkingLotSystemContext context)
        {
            _context = context;
        }

        public SubscriptionPlanIndexData PlanData { get; set; } = new SubscriptionPlanIndexData();
        public int SubscriptionPlanID { get; set; }

        public string NameSort { get; set; } = string.Empty;
        public string PriceSort { get; set; } = string.Empty;
        public string CurrentFilter { get; set; } = string.Empty;

        public async Task OnGetAsync(int? id, string? sortOrder, string? searchString)
        {
            NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            PriceSort = sortOrder == "price" ? "price_desc" : "price";
            CurrentFilter = searchString ?? "";

            IQueryable<Models.SubscriptionPlan> plansIQ = _context.SubscriptionPlan
                .Include(p => p.PlanParkingLots)
                    .ThenInclude(pp => pp.ParkingLot);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                plansIQ = plansIQ.Where(p => p.Name.Contains(searchString));
            }

            plansIQ = sortOrder switch
            {
                "name_desc" => plansIQ.OrderByDescending(p => p.Name),
                "price" => plansIQ.OrderBy(p => p.MonthlyPrice),
                "price_desc" => plansIQ.OrderByDescending(p => p.MonthlyPrice),
                _ => plansIQ.OrderBy(p => p.Name),
            };

            PlanData.SubscriptionPlans = await plansIQ.AsNoTracking().ToListAsync();

            if (id != null)
            {
                SubscriptionPlanID = id.Value;

                var selectedPlan = PlanData.SubscriptionPlans.Single(p => p.ID == id.Value);

                PlanData.ParkingLots = selectedPlan.PlanParkingLots
                    .Select(pp => pp.ParkingLot!)
                    .OrderBy(l => l.Name)
                    .ToList();
            }
        }
    }
}