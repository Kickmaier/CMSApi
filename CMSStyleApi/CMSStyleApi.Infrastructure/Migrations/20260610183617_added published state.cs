using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSStyleApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedpublishedstate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Pages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Pages");
        }
    }
}
