using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapitwo.Migrations
{
    /// <inheritdoc />
    public partial class secendmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    Bookshelfandbookid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookshelf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bookstatus = table.Column<int>(type: "int", nullable: false),
                    Bookshelfandbookid = table.Column<int>(type: "int", nullable: false),
                    Bookshelfandshelfid = table.Column<int>(type: "int", nullable: false),
                    Bookshelfanduserid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookshelf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Userid = table.Column<int>(type: "int", nullable: false),
                    Bookshelfandshelfid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Joindate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bookshelfanduserid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookshelfandbook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bookid = table.Column<int>(type: "int", nullable: false),
                    Bookshelfid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookshelfandbook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookshelfandbook_Books_Bookid",
                        column: x => x.Bookid,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookshelfandbook_Bookshelf_Bookshelfid",
                        column: x => x.Bookshelfid,
                        principalTable: "Bookshelf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookshelfandshelf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bookshelfid = table.Column<int>(type: "int", nullable: false),
                    Shelfid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookshelfandshelf", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookshelfandshelf_Bookshelf_Bookshelfid",
                        column: x => x.Bookshelfid,
                        principalTable: "Bookshelf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookshelfandshelf_Shelf_Shelfid",
                        column: x => x.Shelfid,
                        principalTable: "Shelf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookshelfanduser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<int>(type: "int", nullable: false),
                    Bookshelfid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookshelfanduser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookshelfanduser_Bookshelf_Bookshelfid",
                        column: x => x.Bookshelfid,
                        principalTable: "Bookshelf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookshelfanduser_User_Userid",
                        column: x => x.Userid,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookshelfandbook_Bookid",
                table: "Bookshelfandbook",
                column: "Bookid");

            migrationBuilder.CreateIndex(
                name: "IX_Bookshelfandbook_Bookshelfid",
                table: "Bookshelfandbook",
                column: "Bookshelfid");

            migrationBuilder.CreateIndex(
                name: "IX_Bookshelfandshelf_Bookshelfid",
                table: "Bookshelfandshelf",
                column: "Bookshelfid");

            migrationBuilder.CreateIndex(
                name: "IX_Bookshelfandshelf_Shelfid",
                table: "Bookshelfandshelf",
                column: "Shelfid");

            migrationBuilder.CreateIndex(
                name: "IX_Bookshelfanduser_Bookshelfid",
                table: "Bookshelfanduser",
                column: "Bookshelfid");

            migrationBuilder.CreateIndex(
                name: "IX_Bookshelfanduser_Userid",
                table: "Bookshelfanduser",
                column: "Userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookshelfandbook");

            migrationBuilder.DropTable(
                name: "Bookshelfandshelf");

            migrationBuilder.DropTable(
                name: "Bookshelfanduser");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Shelf");

            migrationBuilder.DropTable(
                name: "Bookshelf");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
