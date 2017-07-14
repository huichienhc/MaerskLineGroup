using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLineGroup.Models
{
    public class Container
    {
        public int ContainerID { get; set; }
        
        [Required]
        public String ContainerName { get; set; }

        public int ContainerWeight { get; set; }
    }
}