using Microsoft.EntityFrameworkCore;

namespace TravelAgency.Models
{
    public class TravelAgencyContext : DbContext
    {
        public TravelAgencyContext(DbContextOptions<TravelAgencyContext> options)
            : base(options)
        {
        }

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Review> Reviews { get; set; }        
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData
                (
                    new User { UserId = 1, Name = "Bob" },
                    new User { UserId = 2, Name = "Mary" }
                );
            builder.Entity<Review>()
                .HasData
                (
                    new Review { ReviewId = 1, Rating = 1, Text = "Yolo", DestinationId = 1, UserId = 1 },
                    new Review { ReviewId = 2, Rating = 2, Text = "It's windy", UserId = 1, DestinationId = 1 },
                    new Review { ReviewId = 3, Rating = 5, Text = "Yolo", UserId = 2, DestinationId = 2 },
                    new Review { ReviewId = 4, Rating = 4, Text = "Yolo", UserId = 2, DestinationId = 2 }
                );
            builder.Entity<Destination>()
                .HasData
                (
                    new Destination { DestinationId = 1, City = "Tokyo", Country = "Japan" },
                    new Destination { DestinationId = 2, City = "Chicago", Country = "USA" }
                );
        }
    }
}