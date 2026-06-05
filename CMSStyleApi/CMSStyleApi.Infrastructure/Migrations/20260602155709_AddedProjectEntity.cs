using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSStyleApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "PageTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Pages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageTemplates_ProjectId",
                table: "PageTemplates",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_PageTemplateId",
                table: "Pages",
                column: "PageTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_ProjectId",
                table: "Pages",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_PageTemplates_PageTemplateId",
                table: "Pages",
                column: "PageTemplateId",
                principalTable: "PageTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Projects_ProjectId",
                table: "Pages",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PageTemplates_Projects_ProjectId",
                table: "PageTemplates",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_PageTemplates_PageTemplateId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Projects_ProjectId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_PageTemplates_Projects_ProjectId",
                table: "PageTemplates");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_PageTemplates_ProjectId",
                table: "PageTemplates");

            migrationBuilder.DropIndex(
                name: "IX_Pages_PageTemplateId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_ProjectId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "PageTemplates");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Pages");
        }
    }
}
