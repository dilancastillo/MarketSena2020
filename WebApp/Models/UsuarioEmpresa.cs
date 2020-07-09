using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketSENA.Models
{
    [Table("UsuarioEmpresa")]
    public class UsuarioEmpresa
    {
        [Key]
        public int UsuarioEmpresaID { get; set; }
        public int EmpresaID { get; set; }
        public Empresa Empresa { get; set; }
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
    }
}
