using HypSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HypSuite.Data
{
    public class HypSuiteDBContext: DbContext
    {
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Bed> Beds {get;set;}
    public DbSet<HotelClient> Clients {get;set;}
    public DbSet<Location> Locations {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=;initial catalog=;user id=;password=");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Room>().HasKey(u => u.RoomID);
      builder.Entity<HotelClient>().HasKey(h=>h.ClientID);
      builder.Entity<HotelClient>().HasIndex(u => u.Name).IsUnique();
      builder.Entity<Bed>().HasKey(p => p.BedID);
      builder.Entity<Location>().HasKey(l=>l.LocationID);
    }

  }
}