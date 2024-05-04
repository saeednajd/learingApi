using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapitwo.Migrations
{
    /// <inheritdoc />
    public partial class shelfedited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bokshelfid",
                table: "Shelf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bokshelfid",
                table: "Shelf",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
