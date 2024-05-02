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
                    Odjel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Djelatnici", x => x.Odjel);
                });

            migrationBuilder.CreateTable(
                name: "Odjeli",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odjeli", x => x.ID);
                });

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
                    Nedjelja = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rasporedi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rasporedi_Djelatnici_djelatnik",
                        column: x => x.djelatnik,
                        principalTable: "Djelatnici",
                        principalColumn: "Odjel");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rasporedi_djelatnik",
                table: "Rasporedi",
                column: "djelatnik");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Odjeli");

            migrationBuilder.DropTable(
                name: "Rasporedi");

            migrationBuilder.DropTable(
                name: "Djelatnici");
        }
    }
}
