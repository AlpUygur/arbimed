using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace arbimed.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DistanceInKilometers { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FuelConsumptionInLitres { get; set; }

  
    }

}
