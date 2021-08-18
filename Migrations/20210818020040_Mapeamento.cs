using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBCOREBCC2021.Migrations
{
    public partial class Mapeamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Agricultores_produtorid",
                table: "Areas");

            migrationBuilder.RenameColumn(
                name: "produtorid",
                table: "Areas",
                newName: "produtorId");

            migrationBuilder.RenameIndex(
                name: "IX_Areas_produtorid",
                table: "Areas",
                newName: "IX_Areas_produtorId");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "Insumos",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "produtorId",
                table: "Areas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Agricultores_produtorId",
                table: "Areas",
                column: "produtorId",
                principalTable: "Agricultores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Agricultores_produtorId",
                table: "Areas");

            migrationBuilder.RenameColumn(
                name: "produtorId",
                table: "Areas",
                newName: "produtorid");

            migrationBuilder.RenameIndex(
                name: "IX_Areas_produtorId",
                table: "Areas",
                newName: "IX_Areas_produtorid");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "Insumos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);

            migrationBuilder.AlterColumn<int>(
                name: "produtorid",
                table: "Areas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Agricultores_produtorid",
                table: "Areas",
                column: "produtorid",
                principalTable: "Agricultores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
