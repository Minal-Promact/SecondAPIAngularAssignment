using Microsoft.EntityFrameworkCore;
using SecondAPIAngularAssignment.Model;

namespace SecondAPIAngularAssignment.Data
{
    public class EFDataContext : DbContext
    {
        public EFDataContext()
        {

        }

        public EFDataContext(DbContextOptions<EFDataContext> options)
           : base(options)
        {
        }

        public DbSet<Carousel> Carousels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("WebApiDatabase");
            }

        }
    }
}
