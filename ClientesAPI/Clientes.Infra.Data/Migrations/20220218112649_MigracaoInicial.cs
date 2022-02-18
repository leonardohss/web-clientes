using Microsoft.EntityFrameworkCore.Migrations;

namespace Clientes.Infra.Data.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profissao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(30)", nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    DataDeNascimento = table.Column<string>(type: "varchar(100)", nullable: false),
                    Idade = table.Column<byte>(type: "tinyint", nullable: false),
                    IdProfissao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Profissao_IdProfissao",
                        column: x => x.IdProfissao,
                        principalTable: "Profissao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdProfissao",
                table: "Cliente",
                column: "IdProfissao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Profissao");
        }
    }
}
