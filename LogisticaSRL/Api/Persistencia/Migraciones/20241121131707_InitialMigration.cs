using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Domicilios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Pais = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Calle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    CodigoPostal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoDNI",
                columns: table => new
                {
                    IdTipoDni = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DNIextranjero = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Pais = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDNI", x => x.IdTipoDni);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Centrales",
                columns: table => new
                {
                    IdCentral = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DomicilioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centrales", x => x.IdCentral);
                    table.ForeignKey(
                        name: "FK_Centrales_Domicilios_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "Domicilios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    IdPersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoDNIId = table.Column<int>(type: "int", nullable: false),
                    DomicilioId = table.Column<int>(type: "int", nullable: false),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    PaisResidente = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.IdPersona);
                    table.ForeignKey(
                        name: "FK_Personas_Domicilios_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "Domicilios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_TipoDNI_TipoDNIId",
                        column: x => x.TipoDNIId,
                        principalTable: "TipoDNI",
                        principalColumn: "IdTipoDni",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    IdSucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumeroS = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DomicilioId = table.Column<int>(type: "int", nullable: false),
                    IdCentral = table.Column<int>(type: "int", nullable: false),
                    CentralIdCentral = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.IdSucursal);
                    table.ForeignKey(
                        name: "FK_Sucursales_Centrales_CentralIdCentral",
                        column: x => x.CentralIdCentral,
                        principalTable: "Centrales",
                        principalColumn: "IdCentral",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sucursales_Domicilios_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "Domicilios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Envios",
                columns: table => new
                {
                    NumeroSeguimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPersonaEmisora = table.Column<int>(type: "int", nullable: false),
                    personaEmisoraIdPersona = table.Column<int>(type: "int", nullable: false),
                    IdPersonaReceptora = table.Column<int>(type: "int", nullable: false),
                    personaReceptoraIdPersona = table.Column<int>(type: "int", nullable: false),
                    SucursalDespachoId = table.Column<int>(type: "int", nullable: false),
                    SucursalDestinoId = table.Column<int>(type: "int", nullable: false),
                    CentralDespachoId = table.Column<int>(type: "int", nullable: false),
                    CentralDestinoId = table.Column<int>(type: "int", nullable: false),
                    estadoEnvio = table.Column<int>(type: "int", nullable: false),
                    Dimensiones = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Peso = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envios", x => x.NumeroSeguimiento);
                    table.ForeignKey(
                        name: "FK_Envios_Centrales_CentralDespachoId",
                        column: x => x.CentralDespachoId,
                        principalTable: "Centrales",
                        principalColumn: "IdCentral",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Envios_Centrales_CentralDestinoId",
                        column: x => x.CentralDestinoId,
                        principalTable: "Centrales",
                        principalColumn: "IdCentral",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Envios_Personas_personaEmisoraIdPersona",
                        column: x => x.personaEmisoraIdPersona,
                        principalTable: "Personas",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Envios_Personas_personaReceptoraIdPersona",
                        column: x => x.personaReceptoraIdPersona,
                        principalTable: "Personas",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Envios_Sucursales_SucursalDespachoId",
                        column: x => x.SucursalDespachoId,
                        principalTable: "Sucursales",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Envios_Sucursales_SucursalDestinoId",
                        column: x => x.SucursalDestinoId,
                        principalTable: "Sucursales",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HistorialesEnvio",
                columns: table => new
                {
                    IdHistorialEnvio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumeroSeguimiento = table.Column<int>(type: "int", nullable: false),
                    envioNumeroSeguimiento = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    estadoEnvio = table.Column<int>(type: "int", nullable: false),
                    FechaCambio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialesEnvio", x => x.IdHistorialEnvio);
                    table.ForeignKey(
                        name: "FK_HistorialesEnvio_Envios_envioNumeroSeguimiento",
                        column: x => x.envioNumeroSeguimiento,
                        principalTable: "Envios",
                        principalColumn: "NumeroSeguimiento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialesEnvio_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IntentosEntrega",
                columns: table => new
                {
                    IdIntentoEntrega = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumeroSeguimiento = table.Column<int>(type: "int", nullable: false),
                    EnvioNumeroSeguimiento = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    NumeroIntento = table.Column<int>(type: "int", nullable: false),
                    Entregado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaIntento = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntentosEntrega", x => x.IdIntentoEntrega);
                    table.ForeignKey(
                        name: "FK_IntentosEntrega_Envios_EnvioNumeroSeguimiento",
                        column: x => x.EnvioNumeroSeguimiento,
                        principalTable: "Envios",
                        principalColumn: "NumeroSeguimiento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntentosEntrega_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Centrales_DomicilioId",
                table: "Centrales",
                column: "DomicilioId");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_CentralDespachoId",
                table: "Envios",
                column: "CentralDespachoId");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_CentralDestinoId",
                table: "Envios",
                column: "CentralDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_personaEmisoraIdPersona",
                table: "Envios",
                column: "personaEmisoraIdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_personaReceptoraIdPersona",
                table: "Envios",
                column: "personaReceptoraIdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_SucursalDespachoId",
                table: "Envios",
                column: "SucursalDespachoId");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_SucursalDestinoId",
                table: "Envios",
                column: "SucursalDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesEnvio_envioNumeroSeguimiento",
                table: "HistorialesEnvio",
                column: "envioNumeroSeguimiento");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesEnvio_SucursalId",
                table: "HistorialesEnvio",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_IntentosEntrega_EnvioNumeroSeguimiento",
                table: "IntentosEntrega",
                column: "EnvioNumeroSeguimiento");

            migrationBuilder.CreateIndex(
                name: "IX_IntentosEntrega_SucursalId",
                table: "IntentosEntrega",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DomicilioId",
                table: "Personas",
                column: "DomicilioId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_TipoDNIId",
                table: "Personas",
                column: "TipoDNIId");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_CentralIdCentral",
                table: "Sucursales",
                column: "CentralIdCentral");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_DomicilioId",
                table: "Sucursales",
                column: "DomicilioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialesEnvio");

            migrationBuilder.DropTable(
                name: "IntentosEntrega");

            migrationBuilder.DropTable(
                name: "Envios");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropTable(
                name: "TipoDNI");

            migrationBuilder.DropTable(
                name: "Centrales");

            migrationBuilder.DropTable(
                name: "Domicilios");
        }
    }
}
