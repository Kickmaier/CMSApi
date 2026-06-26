using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSStyleApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class multiplechangestopagestructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NavOrdet",
                table: "Pages",
                newName: "NavOrder");

            migrationBuilder.AddColumn<string>(
                name: "FooterContent",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FooterStyleJson",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeaderContent",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeaderStyleJson",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainContent",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainStyleJson",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterContent",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "FooterStyleJson",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "HeaderContent",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "HeaderStyleJson",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "MainContent",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "MainStyleJson",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "NavOrder",
                table: "Pages",
                newName: "NavOrdet");
        }
    }
}
