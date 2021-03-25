using System;
using ClassLibrary1.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1
{
    public class TouristiqueDbContext : IdentityDbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Chambre> Chambres { get; set; }
        public DbSet<Activite> Activites { get; set; }
        public DbSet<TransportHotel> TransportHotels { get; set; }
        public DbSet<TransportSite> TransportSites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Movies;User Id=sa;Password=Youssef456*");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<TransportHotel>().HasKey(e => new { e.TransportId , e.HotelId });
            builder.Entity<TransportSite>().HasKey(e => new { e.TransportId , e.SiteId });
            
            builder.Entity<TransportHotel>().HasOne(th => th.Hotel).WithMany(h => h.TransportHotels);
            builder.Entity<TransportHotel>().HasOne(th => th.Transport).WithMany(t => t.TransportHotels);
            
            builder.Entity<TransportSite>().HasOne(ts => ts.Site).WithMany(s =>  s.TransportSites);
            builder.Entity<TransportSite>().HasOne(ts => ts.Transport).WithMany(t => t.TransportSites);
        }
    }
}