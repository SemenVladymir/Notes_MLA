using Microsoft.EntityFrameworkCore;
using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.EF
{
    public class MobileContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }

        public MobileContext(DbContextOptions<MobileContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MV43C0T;Database=PhonesBase;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
