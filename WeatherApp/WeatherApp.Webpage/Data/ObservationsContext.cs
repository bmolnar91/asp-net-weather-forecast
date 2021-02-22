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
                UserName = "User",
                Description = "It is very hot and sunny here",
                Timestamp = new DateTime(2020, 11, 14, 9, 28, 0),
            },
            new Observation
            {
                Id = 2,
                City = "Budapest",
                UserName = "Jane",
                Description = "Freezing cold",
                Timestamp = new DateTime(2020, 10, 14, 9, 28, 0),
            },
            new Observation
            {
                Id = 3,
                City = "Madrid",
                UserName = "Pablo",
                Description = "Beach time!",
                Timestamp = new DateTime(2020, 6, 14, 9, 28, 0),
            });
        }
    }
}
