using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_ProjetDonetCore.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_location_client_clientIdCl",
                table: "location");

            migrationBuilder.DropForeignKey(
                name: "FK_location_voiture_VoitureIdVoi",
                table: "location");

            migrationBuilder.RenameColumn(
                name: "clientIdCl",
                table: "location",
                newName: "IdVoi");

            migrationBuilder.RenameColumn(
                name: "VoitureIdVoi",
                table: "location",
                newName: "IdCl");

            migrationBuilder.RenameIndex(
                name: "IX_location_VoitureIdVoi",
                table: "location",
                newName: "IX_location_IdCl");

            migrationBuilder.RenameIndex(
                name: "IX_location_clientIdCl",
                table: "location",
                newName: "IX_location_IdVoi");

            migrationBuilder.AddForeignKey(
                name: "FK_location_client_IdCl",
                table: "location",
                column: "IdCl",
                principalTable: "client",
                principalColumn: "IdCl",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_location_voiture_IdVoi",
                table: "location",
                column: "IdVoi",
                principalTable: "voiture",
                principalColumn: "IdVoi",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_location_client_IdCl",
                table: "location");

            migrationBuilder.DropForeignKey(
                name: "FK_location_voiture_IdVoi",
                table: "location");

            migrationBuilder.RenameColumn(
                name: "IdVoi",
                table: "location",
                newName: "clientIdCl");

            migrationBuilder.RenameColumn(
                name: "IdCl",
                table: "location",
                newName: "VoitureIdVoi");

            migrationBuilder.RenameIndex(
                name: "IX_location_IdVoi",
                table: "location",
                newName: "IX_location_clientIdCl");

            migrationBuilder.RenameIndex(
                name: "IX_location_IdCl",
                table: "location",
                newName: "IX_location_VoitureIdVoi");

            migrationBuilder.AddForeignKey(
                name: "FK_location_client_clientIdCl",
                table: "location",
                column: "clientIdCl",
                principalTable: "client",
                principalColumn: "IdCl",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_location_voiture_VoitureIdVoi",
                table: "location",
                column: "VoitureIdVoi",
                principalTable: "voiture",
                principalColumn: "IdVoi",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
