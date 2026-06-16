using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSStyleApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedpage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInNavMenu",
                table: "Pages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NavOrdet",
                table: "Pages",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInNavMenu",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "NavOrdet",
                table: "Pages");
        }
    }
}
