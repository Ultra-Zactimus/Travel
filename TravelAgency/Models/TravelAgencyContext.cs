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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Destination>()
                .HasData
                (
                    // new Destination { DestinationId = 3, City = "Tokyo", Country = "Japan", Review = "It was amazing. Definitely go there!", Rating = 5 },
                    new Destination { DestinationId = 3, City = "Tokyo", Country = "Japan", [ new Review { ReviewId = 1, User = "name", Rating = 5, Text = "It was amazing. Definitely go there!" }, new Review { ReviewId = 2, User = "name", Rating = 5, Text = "It was amazing. Definitely go there!", Destination.DestinationId = 3 }] }
                    // new Destination { DestinationId = 4, City = "Venice", Country = "Italy", Review = "The food? The Bomb Dot Com", Rating = 5 }
                );
        }
    }
}