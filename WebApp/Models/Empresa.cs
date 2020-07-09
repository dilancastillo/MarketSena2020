using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketSENA.Models
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        public int EmpresaID { get; set; }
        public int ModeloNegocioID { get; set; }
        public ModeloNegocio ModeloNegocio { get; set; }
        public int SectorEconomicoID { get; set; }
        public SectorEconomico SectorEconomico { get; set; }
        public string RazonSocial { get; set; }
        public string Nit { get; set; }
    }
}
