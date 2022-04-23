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
                    new User { UserId = 2, Name = "Mary" }, 
                    new User { UserId = 3, Name = "Dakota" }, 
                    new User { UserId = 4, Name = "Riley" }, 
                    new User { UserId = 5, Name = "Sam" }
                );
            builder.Entity<Review>()
                .HasData
                (
                    new Review { ReviewId = 1, Rating = 5, Text = "Yolo", UserId = 1, DestinationId = 1 },
                    new Review { ReviewId = 2, Rating = 3, Text = "Awesome", UserId = 1, DestinationId = 2 },
                    new Review { ReviewId = 3, Rating = 5, Text = "Cool", UserId = 2, DestinationId = 2 },
                    new Review { ReviewId = 4, Rating = 1, Text = "Bad", UserId = 1, DestinationId = 3 },
                    new Review { ReviewId = 5, Rating = 3, Text = "Eh", UserId = 2, DestinationId = 3 },
                    new Review { ReviewId = 6, Rating = 1, Text = "Word", UserId = 3, DestinationId = 3 },
                    new Review { ReviewId = 7, Rating = 4, Text = "Radical", UserId = 1, DestinationId = 4 },
                    new Review { ReviewId = 8, Rating = 4, Text = "Cawabunga", UserId = 2, DestinationId = 4 },
                    new Review { ReviewId = 9, Rating = 5, Text = "Go there!", UserId = 3, DestinationId = 4 },
                    new Review { ReviewId = 10, Rating = 5, Text = "Do eet!", UserId = 4, DestinationId = 4 },
                    new Review { ReviewId = 11, Rating = 4, Text = "Rad", UserId = 1, DestinationId = 5 },
                    new Review { ReviewId = 12, Rating = 5, Text = "Nice", UserId = 2, DestinationId = 5 },
                    new Review { ReviewId = 13, Rating = 4, Text = "Da Bomb", UserId = 3, DestinationId = 5 },
                    new Review { ReviewId = 14, Rating = 5, Text = "Cool", UserId = 4, DestinationId = 5 },
                    new Review { ReviewId = 15, Rating = 5, Text = "Cool", UserId = 5, DestinationId = 5 }
                );
            builder.Entity<Destination>()
                .HasData
                (
                    new Destination { DestinationId = 1, City = "Tokyo", Country = "Japan" },
                    new Destination { DestinationId = 2, City = "Chicago", Country = "USA" },
                    new Destination { DestinationId = 3, City = "London", Country = "England" },
                    new Destination { DestinationId = 4, City = "Los Angelos", Country = "Usa" },
                    new Destination { DestinationId = 5, City = "Sydney", Country = "Australia" }
                );
        }
    }
}