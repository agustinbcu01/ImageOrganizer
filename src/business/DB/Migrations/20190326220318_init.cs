using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.DB.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Crc = table.Column<string>(nullable: true),
                    EntryCreateAt = table.Column<DateTime>(nullable: false),
                    EntryModifiedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    FolderType = table.Column<int>(nullable: false),
                    FolderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Archive",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Crc = table.Column<string>(nullable: true),
                    EntryCreateAt = table.Column<DateTime>(nullable: false),
                    EntryModifiedAt = table.Column<DateTime>(nullable: false),
                    ArchiveStatus = table.Column<int>(nullable: false),
                    Mediatype = table.Column<int>(nullable: false),
                    MetaDada = table.Column<string>(nullable: true),
                    FolderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archive_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[] { 0, "Root Path", "E:\\MediaRoot" });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[] { 1, "Time Out", "10" });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[] { 2, "Drop Location", "E:\\Drop" });

            migrationBuilder.CreateIndex(
                name: "IX_Archive_Crc",
                table: "Archive",
                column: "Crc");

            migrationBuilder.CreateIndex(
                name: "IX_Archive_FolderId",
                table: "Archive",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Archive_Path",
                table: "Archive",
                column: "Path");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_Crc",
                table: "Folders",
                column: "Crc");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_FolderId",
                table: "Folders",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_Path",
                table: "Folders",
                column: "Path");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archive");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Folders");
        }
    }
}
