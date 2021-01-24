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
        [Required(ErrorMessage = "This field is requied")]
        public int VehicleId { get; set; }
        [Required(ErrorMessage = "This field is requied")]
        public int DriverId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "This field is requied")]
        public decimal DistanceInKilometers { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "This field is requied")]
        public decimal FuelConsumptionInLitres { get; set; }

  
    }

}
