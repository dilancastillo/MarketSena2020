using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketSENA.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CiiuSeccion",
                columns: table => new
                {
                    CiiuSeccionID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CiiuSeccion", x => x.CiiuSeccionID);
                });

            migrationBuilder.CreateTable(
                name: "ModeloNegocio",
                columns: table => new
                {
                    ModeloNegocioID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloNegocio", x => x.ModeloNegocioID);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RolID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    VerificacionEmail = table.Column<string>(nullable: true),
                    Contrasenia = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "CiiuDivision",
                columns: table => new
                {
                    CiiuDivisionID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CiiuSeccionID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CiiuDivision", x => x.CiiuDivisionID);
                    table.ForeignKey(
                        name: "FK_CiiuDivision_CiiuSeccion_CiiuSeccionID",
                        column: x => x.CiiuSeccionID,
                        principalTable: "CiiuSeccion",
                        principalColumn: "CiiuSeccionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectorEconomico",
                columns: table => new
                {
                    SectorEconomicoID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CiiuSeccionID = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorEconomico", x => x.SectorEconomicoID);
                    table.ForeignKey(
                        name: "FK_SectorEconomico_CiiuSeccion_CiiuSeccionID",
                        column: x => x.CiiuSeccionID,
                        principalTable: "CiiuSeccion",
                        principalColumn: "CiiuSeccionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plantilla",
                columns: table => new
                {
                    PlantillaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModeloNegocioID = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Visible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantilla", x => x.PlantillaID);
                    table.ForeignKey(
                        name: "FK_Plantilla_ModeloNegocio_ModeloNegocioID",
                        column: x => x.ModeloNegocioID,
                        principalTable: "ModeloNegocio",
                        principalColumn: "ModeloNegocioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoRol",
                columns: table => new
                {
                    TipoRolID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RolID = table.Column<int>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRol", x => x.TipoRolID);
                    table.ForeignKey(
                        name: "FK_TipoRol_Rol_RolID",
                        column: x => x.RolID,
                        principalTable: "Rol",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoRol_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CiiuGrupo",
                columns: table => new
                {
                    CiiuGrupoID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CiiuDivisionID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CiiuGrupo", x => x.CiiuGrupoID);
                    table.ForeignKey(
                        name: "FK_CiiuGrupo_CiiuDivision_CiiuDivisionID",
                        column: x => x.CiiuDivisionID,
                        principalTable: "CiiuDivision",
                        principalColumn: "CiiuDivisionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    EmpresaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModeloNegocioID = table.Column<int>(nullable: false),
                    SectorEconomicoID = table.Column<int>(nullable: false),
                    RazonSocial = table.Column<string>(nullable: true),
                    Nit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.EmpresaID);
                    table.ForeignKey(
                        name: "FK_Empresa_ModeloNegocio_ModeloNegocioID",
                        column: x => x.ModeloNegocioID,
                        principalTable: "ModeloNegocio",
                        principalColumn: "ModeloNegocioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empresa_SectorEconomico_SectorEconomicoID",
                        column: x => x.SectorEconomicoID,
                        principalTable: "SectorEconomico",
                        principalColumn: "SectorEconomicoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seccion",
                columns: table => new
                {
                    SeccionID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlantillaID = table.Column<int>(nullable: false),
                    Visible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seccion", x => x.SeccionID);
                    table.ForeignKey(
                        name: "FK_Seccion_Plantilla_PlantillaID",
                        column: x => x.PlantillaID,
                        principalTable: "Plantilla",
                        principalColumn: "PlantillaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CiiuClase",
                columns: table => new
                {
                    CiiuClaseID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CiiuGrupoID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CiiuClase", x => x.CiiuClaseID);
                    table.ForeignKey(
                        name: "FK_CiiuClase_CiiuGrupo_CiiuGrupoID",
                        column: x => x.CiiuGrupoID,
                        principalTable: "CiiuGrupo",
                        principalColumn: "CiiuGrupoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpresaID = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    UrlImg = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Unidad = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Promocion = table.Column<string>(nullable: true),
                    Descuento = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoID);
                    table.ForeignKey(
                        name: "FK_Producto_Empresa_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEmpresa",
                columns: table => new
                {
                    UsuarioEmpresaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpresaID = table.Column<int>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEmpresa", x => x.UsuarioEmpresaID);
                    table.ForeignKey(
                        name: "FK_UsuarioEmpresa_Empresa_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEmpresa_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    ComponenteID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SeccionID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Visible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.ComponenteID);
                    table.ForeignKey(
                        name: "FK_Componente_Seccion_SeccionID",
                        column: x => x.SeccionID,
                        principalTable: "Seccion",
                        principalColumn: "SeccionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CiiuClase_CiiuGrupoID",
                table: "CiiuClase",
                column: "CiiuGrupoID");

            migrationBuilder.CreateIndex(
                name: "IX_CiiuDivision_CiiuSeccionID",
                table: "CiiuDivision",
                column: "CiiuSeccionID");

            migrationBuilder.CreateIndex(
                name: "IX_CiiuGrupo_CiiuDivisionID",
                table: "CiiuGrupo",
                column: "CiiuDivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_SeccionID",
                table: "Componente",
                column: "SeccionID");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_ModeloNegocioID",
                table: "Empresa",
                column: "ModeloNegocioID");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_SectorEconomicoID",
                table: "Empresa",
                column: "SectorEconomicoID");

            migrationBuilder.CreateIndex(
                name: "IX_Plantilla_ModeloNegocioID",
                table: "Plantilla",
                column: "ModeloNegocioID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_EmpresaID",
                table: "Producto",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Seccion_PlantillaID",
                table: "Seccion",
                column: "PlantillaID");

            migrationBuilder.CreateIndex(
                name: "IX_SectorEconomico_CiiuSeccionID",
                table: "SectorEconomico",
                column: "CiiuSeccionID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoRol_RolID",
                table: "TipoRol",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoRol_UsuarioID",
                table: "TipoRol",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresa_EmpresaID",
                table: "UsuarioEmpresa",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresa_UsuarioID",
                table: "UsuarioEmpresa",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CiiuClase");

            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "TipoRol");

            migrationBuilder.DropTable(
                name: "UsuarioEmpresa");

            migrationBuilder.DropTable(
                name: "CiiuGrupo");

            migrationBuilder.DropTable(
                name: "Seccion");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "CiiuDivision");

            migrationBuilder.DropTable(
                name: "Plantilla");

            migrationBuilder.DropTable(
                name: "SectorEconomico");

            migrationBuilder.DropTable(
                name: "ModeloNegocio");

            migrationBuilder.DropTable(
                name: "CiiuSeccion");
        }
    }
}
