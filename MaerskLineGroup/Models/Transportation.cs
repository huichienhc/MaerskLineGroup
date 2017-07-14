using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaerskLineGroup.Models
{
    public class Transportation
    {
        public int TransportationID { get; set; }
        
        [ForeignKey("Ship")]
        public int ShipID { get; set; }
        public Ship Ship { get; set; }

        [ForeignKey("Container")]
        public int ContainerID { get; set; }
        public Container Container { get; set; }

        [DataType(DataType.Date)]
        public DateTime ArrivalTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [ForeignKey("Shipyard")]
        public int ArrivalShipyardID { get; set; }
        public virtual Shipyard Shipyard { get; set; }

        [ForeignKey("Shipyard1")]
        public int DepartureShipyardID { get; set; }
        public virtual Shipyard Shipyard1 { get; set; }

    }

}