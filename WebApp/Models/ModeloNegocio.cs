using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketSENA.Models
{
    [Table("ModeloNegocio")]
    public class ModeloNegocio
    {
        [Key]
        public int ModeloNegocioID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
