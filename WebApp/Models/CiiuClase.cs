using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketSENA.Models
{
    [Table("CiiuClase")]
    public class CiiuClase
    {
        [Key]
        public int CiiuClaseID { get; set; }
        public int CiiuGrupoID { get; set; }
        public CiiuGrupo CiiuGrupo { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
    }
}
