using HypSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HypSuite.Data
{
    public class HypSuiteDBContext: DbContext
    {
    public DbSet<Room> Rooms { get; set; }
    public DbSet<HotelClient> Clients {get;set;}
    public DbSet<Location> Locations {get;set;}
    public DbSet<Employee> Admin {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;initial catalog=HypSuite;user id=sa;password=Password12345");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Room>().HasKey(u => u.RoomID);
      builder.Entity<HotelClient>().HasKey(h=>h.ClientID);
      builder.Entity<HotelClient>().HasMany(h=>h.Locations);
      builder.Entity<HotelClient>().HasIndex(u => u.Name).IsUnique();
      builder.Entity<Location>().HasKey(l=>l.LocationID);
      builder.Entity<Location>().HasMany(l=>l.Rooms);
    }

  }
}