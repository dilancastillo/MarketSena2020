using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketSENA.Models
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int ProductoID { get; set; }
        public int EmpresaID { get; set; }
        public Empresa Empresa { get; set; }
        public string Nombre { get; set; }
        public Decimal Precio { get; set; }
        public string UrlImg { get; set; }
        public string Tipo { get; set; }
        public int Unidad { get; set; }
        public string Codigo { get; set; }
        public string Promocion { get; set; }
        public Decimal Descuento { get; set; }
    }
}
