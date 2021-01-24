using arbimed.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arbimed.Data
{
    public class ArbimedContext : DbContext
    {
        public ArbimedContext(DbContextOptions<ArbimedContext> options) : base(options) { }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Trip> Trip { get; set; }
        public DbSet<Driver> Driver { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Trip>().HasNoKey();
            modelBuilder.Entity<Vehicle>().Property(v => v.TotalTravelDistanceInKilometers).HasDefaultValue(0);
            modelBuilder.Entity<Driver>().Property(d => d.UsedVehicleCount).HasDefaultValue(0);

        }
    }
}
