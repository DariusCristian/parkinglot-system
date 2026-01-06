using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingSystem.Models
{
    public class ParkingLot
    {
        public int ID { get; set; }

        [Display(Name = "Parking lot name")]
        [Required(ErrorMessage = "Parking lot name is required.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 60 characters.")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required.")]
        [StringLength(120, ErrorMessage = "Address cannot exceed 120 characters.")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
        public string City { get; set; } = string.Empty;

        [Display(Name = "Capacity (spots)")]
        [Range(1, 5000, ErrorMessage = "Capacity must be between 1 and 5000.")]
        public int Capacity { get; set; }

        [Display(Name = "Hourly rate")]
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500, ErrorMessage = "Hourly rate must be between 0.01 and 500.")]
        public decimal HourlyRate { get; set; }
    }
}