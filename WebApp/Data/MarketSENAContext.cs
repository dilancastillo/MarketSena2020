using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MarketSENA.Models;

namespace MarketSENA.Data
{
    public class MarketSENAContext : DbContext
    {
        public MarketSENAContext (DbContextOptions<MarketSENAContext> options)
            : base(options)
        {
            
        }

        public DbSet<MarketSENA.Models.CiiuClase> CiiuClase { get; set; }

        public DbSet<MarketSENA.Models.CiiuDivision> CiiuDivision { get; set; }

        public DbSet<MarketSENA.Models.CiiuGrupo> CiiuGrupo { get; set; }

        public DbSet<MarketSENA.Models.CiiuSeccion> CiiuSeccion { get; set; }

        public DbSet<MarketSENA.Models.Componente> Componente { get; set; }

        public DbSet<MarketSENA.Models.Empresa> Empresa { get; set; }

        public DbSet<MarketSENA.Models.ModeloNegocio> ModeloNegocio { get; set; }

        public DbSet<MarketSENA.Models.Plantilla> Plantilla { get; set; }

        public DbSet<MarketSENA.Models.Producto> Producto { get; set; }

        public DbSet<MarketSENA.Models.Rol> Rol { get; set; }

        public DbSet<MarketSENA.Models.Seccion> Seccion { get; set; }

        public DbSet<MarketSENA.Models.SectorEconomico> SectorEconomico { get; set; }

        public DbSet<MarketSENA.Models.TipoRol> TipoRol { get; set; }

        public DbSet<MarketSENA.Models.Usuario> Usuario { get; set; }

        public DbSet<MarketSENA.Models.UsuarioEmpresa> UsuarioEmpresa { get; set; }
    }
}
