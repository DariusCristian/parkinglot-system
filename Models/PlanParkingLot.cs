namespace ParkingLotSystem.Models
{
    public class PlanParkingLot
    {
        public int SubscriptionPlanID { get; set; }
        public SubscriptionPlan? SubscriptionPlan { get; set; }

        public int ParkingLotID { get; set; }
        public ParkingLot? ParkingLot { get; set; }
    }
}