using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSStyleApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedSpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Projects",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Projects",
                newName: "userId");
        }
    }
}
