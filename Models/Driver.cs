using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace arbimed.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        [StringLength(50)]
        public string LicenseNumber { get; set; }
        public int UsedVehicleCount { get; set; }
    }
}
