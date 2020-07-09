using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketSENA.Models
{
    [Table("CiiuDivision")]
    public class CiiuDivision
    {
        [Key]
        public int CiiuDivisionID { get; set; }
        public int CiiuSeccionID { get; set; }
        public CiiuSeccion CiiuSeccion { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
    }
}
