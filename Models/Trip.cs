using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace arbimed.Models
{
    public class Trip
    {

        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DistanceInKilometers { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FuelConsumptionInLitres { get; set; }
    }
}
