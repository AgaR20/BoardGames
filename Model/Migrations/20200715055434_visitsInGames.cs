using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class visitsInGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Games_VisitedGameId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_VisitedGameId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "VisitedGameId",
                table: "Visits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VisitedGameId",
                table: "Visits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitedGameId",
                table: "Visits",
                column: "VisitedGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Games_VisitedGameId",
                table: "Visits",
                column: "VisitedGameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
