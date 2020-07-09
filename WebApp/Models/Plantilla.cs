using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketSENA.Models
{
    [Table("Plantilla")]
    public class Plantilla
    {
        [Key]
        public int PlantillaID { get; set; }
        public int ModeloNegocioID { get; set; }
        public ModeloNegocio ModeloNegocio { get; set; }
        public DateTime Fecha { get; set; }
        public Boolean Visible { get; set; }
    }
}
