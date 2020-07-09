using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketSENA.Models
{
    [Table("Componente")]
    public class Componente
    {
        [Key]
        public int ComponenteID { get; set; }
        public int SeccionID { get; set; }
        public Seccion Seccion { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public Boolean Visible { get; set; }
    }
}
