using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectOrganizer.Migrations
{
    public partial class AttachmentsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttachmentModules",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FileId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    DocumentType = table.Column<string>(nullable: true),
                    CardId = table.Column<string>(nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentModules_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentModules_CardId",
                table: "AttachmentModules",
                column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentModules");
        }
    }
}
