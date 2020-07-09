using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketSENA.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirmar Email")]
        [Compare("Email",
            ErrorMessage = "El Email y el Email de confirmación no coinciden")]
        public string VerificacionEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Contrasenia { get; set; }
    }
}
