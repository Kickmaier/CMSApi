using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSStyleApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removedThemes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_PageTemplates_PageTemplateId",
                table: "Pages");

            migrationBuilder.DropTable(
                name: "PageTemplates");

            migrationBuilder.DropIndex(
                name: "IX_Pages_UserId",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "PageTemplateId",
                table: "Pages",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Pages_PageTemplateId",
                table: "Pages",
                newName: "IX_Pages_ProjectId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Projects_ProjectId",
                table: "Pages",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Projects_ProjectId",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Pages",
                newName: "PageTemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_Pages_ProjectId",
                table: "Pages",
                newName: "IX_Pages_PageTemplateId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Pages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "PageTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FontStyle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeaderColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowFooter = table.Column<bool>(type: "bit", nullable: false),
                    ShowSidebarLeft = table.Column<bool>(type: "bit", nullable: false),
                    ShowSidebarRight = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageTemplates_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pages_UserId",
                table: "Pages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PageTemplates_ProjectId",
                table: "PageTemplates",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_PageTemplates_PageTemplateId",
                table: "Pages",
                column: "PageTemplateId",
                principalTable: "PageTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
