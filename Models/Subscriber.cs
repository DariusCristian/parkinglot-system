using System.ComponentModel.DataAnnotations;

namespace ParkingLotSystem.Models
{
    public class Subscriber
    {
        public int ID { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Address { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => (FirstName ?? "") + " " + (LastName ?? "");

        public ICollection<Subscription>? Subscriptions { get; set; }
    }
}