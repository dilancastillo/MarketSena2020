using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketSENA.Models
{
    [Table("SectorEconomico")]
    public class SectorEconomico
    {
        [Key]
        public int SectorEconomicoID { get; set; }
        public int CiiuSeccionID { get; set; }
        public CiiuSeccion CiiuSeccion { get; set; }
        public string Codigo { get; set; }
        public string Tipo { get; set; }
    }
}
