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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Review>()
                .HasData
                (
                    new Review { ReviewId = 1, User = "Bob", Rating = 6, Text = "Yolo", DestinationId = 1 },
                    new Review { ReviewId = 2, User = "Charlie", Rating = 2, Text = "It's windy", DestinationId = 1 },
                    new Review { ReviewId = 3, User = "Dakota", Rating = 6, Text = "go there", DestinationId = 2 },
                    new Review { ReviewId = 4, User = "Bob", Rating = 6, Text = "Yolo", DestinationId = 2 },
                    new Review { ReviewId = 5, User = "Sam", Rating = 6, Text = "Yolo", DestinationId = 2 }
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