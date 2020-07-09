using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketSENA.Models
{
    [Table("TipoRol")]
    public class TipoRol
    {
        [Key]
        public int TipoRolID { get; set; }
        public int RolID { get; set; }
        public Rol Rol { get; set; }
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }
    }
}
