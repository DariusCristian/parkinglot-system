using System.ComponentModel.DataAnnotations;

namespace ParkingLotSystem.Models
{
    public class Subscription
    {
        public int ID { get; set; }

        public int? SubscriberID { get; set; }
        public Subscriber? Subscriber { get; set; }

        public int? SubscriptionPlanID { get; set; }
        public SubscriptionPlan? SubscriptionPlan { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(30);
    }
}