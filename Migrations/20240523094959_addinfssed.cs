using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapitwo.Migrations
{
    /// <inheritdoc />
    public partial class addinfssed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d2f93d56-7247-425c-8efd-afb87d5b66e9", "1", "Admin", "ADMIN" },
                    { "f9866e6f-66ca-4f6d-998d-0ef6d500bdb4", "2", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2f93d56-7247-425c-8efd-afb87d5b66e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9866e6f-66ca-4f6d-998d-0ef6d500bdb4");
        }
    }
}
