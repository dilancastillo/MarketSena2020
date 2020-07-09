using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketSENA.Models
{
    [Table("Galeria")]
    public class Galeria
    {
        [Key]
        public int GaleriaID { get; set; }
        public string UrlImg { get; set; }
    }
}
