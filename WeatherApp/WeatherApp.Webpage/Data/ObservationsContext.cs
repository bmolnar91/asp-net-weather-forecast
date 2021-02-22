using Microsoft.EntityFrameworkCore;
using System;

namespace WeatherApp.WebSite.Models
{
    public class ObservationsContext : DbContext
    {
        public ObservationsContext(DbContextOptions<ObservationsContext> options) : base(options)
        {
        }

        public DbSet<Observation> Observations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Observation>().HasData(
            new Observation
            {
                Id = 1,
                City = "Budapest",
                Timestamp = new DateTime(2020, 11, 14, 9, 28, 0),
                UserName = "User",
                Description = "It is very hot and sunny here"
            },
            new Observation
            {
                Id = 2,
                City = "Budapest",
                Timestamp = new DateTime(2020, 10, 14, 9, 28, 0),
                UserName = "Jane",
                Description = "Freezing cold"
            },
            new Observation
            {
                Id = 3,
                City = "Madrid",
                Timestamp = new DateTime(2020, 6, 14, 9, 28, 0),
                UserName = "Pablo",
                Description = "Beach time!"
            });
        }
    }
}
