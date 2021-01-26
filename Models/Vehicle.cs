using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [RegularExpression("[0-9]-[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9]")]
        [StringLength(10)]
        public string PlateNumber { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastTripDateTime { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalTravelDistanceInKilometers { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal AverageFuelConsumptionInLitres { get; set; }

        public Vehicle()
        {
            TotalTravelDistanceInKilometers += 0;
            AverageFuelConsumptionInLitres += 0;
        }

    }
}
