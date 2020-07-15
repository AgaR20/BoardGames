using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class visitsInGamesId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Visits",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_GameId",
                table: "Visits",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Games_GameId",
                table: "Visits",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Games_GameId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_GameId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Visits");
        }
    }
}
