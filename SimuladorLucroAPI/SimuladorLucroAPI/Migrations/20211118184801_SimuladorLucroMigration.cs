using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimuladorLucroAPI.Migrations
{
    public partial class SimuladorLucroMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    Duracao = table.Column<TimeSpan>(nullable: false, defaultValue: new TimeSpan(0, 1, 0, 0, 0)),
                    Valor = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    Custo = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servico");
        }
    }
}
