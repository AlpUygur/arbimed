using arbimed.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arbimed.Data
{
    public class DriverContext : DbContext
    {
        public DriverContext(DbContextOptions<DriverContext> options) : base(options) { }
        public DbSet<Driver> Driver { get; set; }
    }
}
