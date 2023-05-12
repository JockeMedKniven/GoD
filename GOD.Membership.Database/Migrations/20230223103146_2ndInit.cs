using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GOD.Membership.Database.Migrations
{
    /// <inheritdoc />
    public partial class _2ndInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameGenres_Games_GameID",
                table: "GameGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenres_Genres_GenreID",
                table: "GameGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_Sims_Games_ParentGameId",
                table: "Sims");

            migrationBuilder.RenameColumn(
                name: "ParentGameId",
                table: "Sims",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "GenreID",
                table: "GameGenres",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "GameGenres",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameGenres_GenreID",
                table: "GameGenres",
                newName: "IX_GameGenres_GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenres_Games_GameId",
                table: "GameGenres",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenres_Genres_GenreId",
                table: "GameGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sims_Games_GameId",
                table: "Sims",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameGenres_Games_GameId",
                table: "GameGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenres_Genres_GenreId",
                table: "GameGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_Sims_Games_GameId",
                table: "Sims");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Sims",
                newName: "ParentGameId");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "GameGenres",
                newName: "GenreID");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "GameGenres",
                newName: "GameID");

            migrationBuilder.RenameIndex(
                name: "IX_GameGenres_GenreId",
                table: "GameGenres",
                newName: "IX_GameGenres_GenreID");

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenres_Games_GameID",
                table: "GameGenres",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenres_Genres_GenreID",
                table: "GameGenres",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sims_Games_ParentGameId",
                table: "Sims",
                column: "ParentGameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
