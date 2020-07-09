using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketSENA.Models
{
    [Table("CiiuSeccion")]
    public class CiiuSeccion
    {
        [Key]
        public int CiiuSeccionID { get; set; }
        //[JsonPropertyName("titulo")]
        public string Descripcion { get; set; }
        //[JsonPropertyName("B")]
        public string Codigo { get; set; }
    }
    //public class CiiuSecciones
    //{
    //    [JsonPropertyName("titulo")]
    //    public string Descripcion { get; set; }
    //    [JsonPropertyName("B")]
    //    public string Codigo { get; set; }
    //    public IList<CiiuSeccion> ciiuLista { get; set; }
    //}
}
