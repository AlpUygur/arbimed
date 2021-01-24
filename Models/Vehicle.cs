using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace arbimed.Models
{
    public class Vehicle
    {

        [Key]
        public int VehicleID { get; set; }
        [RegularExpression("#-####-###")]
        [StringLength(10)]
        public string PlateNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastTripDateTime { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalTravelDistanceInKilometers { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal AverageFuelConsumptionInLitres { get; set; }

    }
}
