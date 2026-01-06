using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Models;

namespace ParkingLotSystem.Data
{
    public class ParkingLotSystemContext : DbContext
    {
        public ParkingLotSystemContext (DbContextOptions<ParkingLotSystemContext> options)
            : base(options)
        {
        }

        public DbSet<ParkingSystem.Models.ParkingLot> ParkingLot { get; set; } = default!;
    }
}
