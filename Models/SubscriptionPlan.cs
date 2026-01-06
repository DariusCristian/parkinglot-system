using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingLotSystem.Models
{
    public class SubscriptionPlan
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Plan name is required.")]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "decimal(8, 2)")]
        [Range(0.01, 999999, ErrorMessage = "Monthly price must be greater than 0.")]
        public decimal MonthlyPrice { get; set; }

        [Range(1, 3650, ErrorMessage = "Duration days must be between 1 and 3650.")]
        public int DurationDays { get; set; }

        public ICollection<PlanParkingLot> PlanParkingLots { get; set; } = new List<PlanParkingLot>();

        public ICollection<Subscription>? Subscriptions { get; set; }
    }
}