using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBCOREBCC2021.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agricultores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proprietario = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    municipio = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agricultores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantidade = table.Column<float>(type: "real", nullable: false),
                    valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    produtorid = table.Column<int>(type: "int", nullable: true),
                    hectares = table.Column<float>(type: "real", nullable: false),
                    municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Areas_Agricultores_produtorid",
                        column: x => x.produtorid,
                        principalTable: "Agricultores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsumosArea",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    areaid = table.Column<int>(type: "int", nullable: true),
                    insumoid = table.Column<int>(type: "int", nullable: true),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quantidade = table.Column<float>(type: "real", nullable: false),
                    valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsumosArea", x => x.id);
                    table.ForeignKey(
                        name: "FK_InsumosArea_Areas_areaid",
                        column: x => x.areaid,
                        principalTable: "Areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsumosArea_Insumos_insumoid",
                        column: x => x.insumoid,
                        principalTable: "Insumos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_produtorid",
                table: "Areas",
                column: "produtorid");

            migrationBuilder.CreateIndex(
                name: "IX_InsumosArea_areaid",
                table: "InsumosArea",
                column: "areaid");

            migrationBuilder.CreateIndex(
                name: "IX_InsumosArea_insumoid",
                table: "InsumosArea",
                column: "insumoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsumosArea");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Insumos");

            migrationBuilder.DropTable(
                name: "Agricultores");
        }
    }
}
