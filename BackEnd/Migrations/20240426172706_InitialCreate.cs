using BackEnd.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
      
                 
    protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "Djelatnici",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Odjel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Djelatnici", x => x.ID);
                });

            migrationBuilder.DropColumn(
            name: "Discriminator",
            table: "Djelatnici");

            migrationBuilder.CreateTable(
                name: "Rasporedi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    djelatnik = table.Column<int>(type: "int", nullable: true),
                    Ponedjeljak = table.Column<int>(type: "int", nullable: true),
                    Utorak = table.Column<int>(type: "int", nullable: true),
                    Srijeda = table.Column<int>(type: "int", nullable: true),
                    Cetvrtak = table.Column<int>(type: "int", nullable: true),
                    Petak = table.Column<int>(type: "int", nullable: true),
                    Subota = table.Column<int>(type: "int", nullable: true),
                    Nedjelja = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rasporedi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rasporedi_Djelatnici_djelatnik",
                        column: x => x.djelatnik,
                        principalTable: "Djelatnici",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Rasporedfondsati",
                columns: table => new
                {
                    FondsatiID = table.Column<int>(type: "int", nullable: false),
                    RasporediID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rasporedfondsati", x => new { x.FondsatiID, x.RasporediID });
                    table.ForeignKey(
                        name: "FK_Rasporedfondsati_Rasporedi_FondsatiID",
                        column: x => x.FondsatiID,
                        principalTable: "Rasporedi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rasporedfondsati_Rasporedi_RasporediID",
                        column: x => x.RasporediID,
                        principalTable: "Rasporedi",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rasporedfondsati_RasporediID",
                table: "Rasporedfondsati",
                column: "RasporediID");

            migrationBuilder.CreateIndex(
                name: "IX_Rasporedi_djelatnik",
                table: "Rasporedi",
                column: "djelatnik");
        }
        
    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
        {
        migrationBuilder.DropColumn(
            name: "Discriminator",
            table: "Djelatnici");

        migrationBuilder.DropTable(
                name: "Rasporedfondsati");

            migrationBuilder.DropTable(
                name: "Rasporedi");

            migrationBuilder.DropTable(
                name: "Djelatnici");
        }
    }
}
