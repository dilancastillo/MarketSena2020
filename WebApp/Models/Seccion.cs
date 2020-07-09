using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketSENA.Models
{
    [Table("Seccion")]
    public class Seccion
    {
        [Key]
        public int SeccionID { get; set; }
        public int PlantillaID { get; set; }
        public Plantilla Plantilla { get; set; }
        public Boolean Visible { get; set; }
    }
}
