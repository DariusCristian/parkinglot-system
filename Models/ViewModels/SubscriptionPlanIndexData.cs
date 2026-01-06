using ParkingLotSystem.Models;

namespace ParkingLotSystem.Models.ViewModels
{
    public class SubscriptionPlanIndexData
    {
        public IEnumerable<SubscriptionPlan> SubscriptionPlans { get; set; } = Enumerable.Empty<SubscriptionPlan>();
        public IEnumerable<ParkingLot> ParkingLots { get; set; } = Enumerable.Empty<ParkingLot>();
    }
}
