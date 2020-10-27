using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectOrganizer.Migrations
{
    public partial class A_embedurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmbedUrl",
                table: "AttachmentModules",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmbedUrl",
                table: "AttachmentModules");
        }
    }
}
