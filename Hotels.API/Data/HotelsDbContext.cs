using Microsoft.EntityFrameworkCore;

namespace Hotels.API.Data
{
    public class HotelsDbContext : DbContext
    {
        public HotelsDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id=1,
                    Name= "Adrion Aparthotel",
                    Price = 103,
                    Latutude = 44.892125,
                    Longitude = 13.8055818,
                },
                new Hotel
                {
                    Id = 2,
                    Name = "B&B Sonia",
                    Price = 56,
                    Latutude = 44.8921259,
                    Longitude = 13.8263311,
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Crazy House Hostel",
                    Price = 53,
                    Latutude = 44.8920093,
                    Longitude = 13.826331,
                },
                new Hotel
                {
                    Id = 4,
                    Name = "Villa Brandestini",
                    Price = 217,
                    Latutude = 44.8953402,
                    Longitude = 13.8200907,
                },
                new Hotel
                {
                    Id = 5,
                    Name = "Milan Hotel",
                    Price = 150,
                    Latutude = 44.8982558,
                    Longitude = 13.7962011,
                }

            );
        }
    }
}
