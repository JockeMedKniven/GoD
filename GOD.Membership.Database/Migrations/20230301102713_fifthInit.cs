using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GOD.Membership.Database.Migrations
{
    /// <inheritdoc />
    public partial class fifthInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sims",
                table: "Sims");

            migrationBuilder.DropColumn(
                name: "SimiliarGameId",
                table: "Sims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sims",
                table: "Sims",
                columns: new[] { "GameId", "SimilarGameId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sims",
                table: "Sims");

            migrationBuilder.AddColumn<int>(
                name: "SimiliarGameId",
                table: "Sims",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sims",
                table: "Sims",
                columns: new[] { "GameId", "SimiliarGameId" });
        }
    }
}
