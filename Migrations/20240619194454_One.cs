using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_ProjetDonetCore.Migrations
{
    /// <inheritdoc />
    public partial class One : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    IdCl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.IdCl);
                });

            migrationBuilder.CreateTable(
                name: "voiture",
                columns: table => new
                {
                    IdVoi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    matricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_sortie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    couleur = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voiture", x => x.IdVoi);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    IdLoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoitureIdVoi = table.Column<int>(type: "int", nullable: false),
                    clientIdCl = table.Column<int>(type: "int", nullable: false),
                    dateLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateRetour = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.IdLoc);
                    table.ForeignKey(
                        name: "FK_location_client_clientIdCl",
                        column: x => x.clientIdCl,
                        principalTable: "client",
                        principalColumn: "IdCl",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_location_voiture_VoitureIdVoi",
                        column: x => x.VoitureIdVoi,
                        principalTable: "voiture",
                        principalColumn: "IdVoi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_location_clientIdCl",
                table: "location",
                column: "clientIdCl");

            migrationBuilder.CreateIndex(
                name: "IX_location_VoitureIdVoi",
                table: "location",
                column: "VoitureIdVoi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "voiture");
        }
    }
}
