using Microsoft.EntityFrameworkCore;
using ParkingLotSystem.Models;

namespace ParkingLotSystem.Data
{
    public class ParkingLotSystemContext : DbContext
    {
        public ParkingLotSystemContext(DbContextOptions<ParkingLotSystemContext> options)
            : base(options)
        {
        }

        public DbSet<ParkingLot> ParkingLot { get; set; } = default!;
        public DbSet<SubscriptionPlan> SubscriptionPlan { get; set; } = default!;
        public DbSet<PlanParkingLot> PlanParkingLot { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlanParkingLot>()
                .HasKey(x => new { x.SubscriptionPlanID, x.ParkingLotID });
        }
    }
}