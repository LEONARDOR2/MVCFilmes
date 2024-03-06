using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCFilmes.Migrations
{
    public partial class Adicionandoumcampopontos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pontos",
                table: "Filmes",
                type: "int",
                nullable: true);
                
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pontos",
                table: "Filmes");
               
        }
    }
}
