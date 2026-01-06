using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ParkingLotSystem.Areas.Identity.Data
{
    public class ParkingLotSystemIdentityContext : IdentityDbContext<IdentityUser>
    {
        public ParkingLotSystemIdentityContext(DbContextOptions<ParkingLotSystemIdentityContext> options)
            : base(options)
        {
        }
    }
}