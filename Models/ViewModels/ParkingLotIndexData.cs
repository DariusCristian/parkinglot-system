using ParkingLotSystem.Models;

namespace ParkingLotSystem.Models.ViewModels
{
    public class ParkingLotIndexData
    {
        public IEnumerable<ParkingLot> ParkingLots { get; set; } = Enumerable.Empty<ParkingLot>();
        public IEnumerable<SubscriptionPlan> SubscriptionPlans { get; set; } = Enumerable.Empty<SubscriptionPlan>();
    }
}