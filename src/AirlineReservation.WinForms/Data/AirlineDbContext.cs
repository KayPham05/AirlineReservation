using AirlineReservation.WinForms.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservation.WinForms.Data;

public class AirlineDbContext : DbContext
{
    public AirlineDbContext(DbContextOptions<AirlineDbContext> options)
        : base(options)
    {
    }

    public DbSet<Flight> Flights => Set<Flight>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.ToTable("Flights");
            entity.HasKey(f => f.Id);
            entity.Property(f => f.FlightNumber).HasMaxLength(10).IsRequired();
            entity.Property(f => f.Origin).HasMaxLength(3).IsRequired();
            entity.Property(f => f.Destination).HasMaxLength(3).IsRequired();
            entity.Property(f => f.DepartureTime).IsRequired();
            entity.Property(f => f.ArrivalTime).IsRequired();
            entity.Property(f => f.SeatsAvailable).IsRequired();
        });
    }
}
