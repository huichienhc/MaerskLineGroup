using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLineGroup.Models
{
    public class Warehouse
    {
        
        public int WarehouseID { get; set; }

        [Required]
        public String WarehouseName { get; set; }

        public String Location { get; set; }
    }
}