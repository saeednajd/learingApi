using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapitwo.Migrations
{
    /// <inheritdoc />
    public partial class addinguserseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2f93d56-7247-425c-8efd-afb87d5b66e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9866e6f-66ca-4f6d-998d-0ef6d500bdb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aee423a8-8370-4b31-a168-867e6c7722f1", "1", "Admin", "ADMIN" },
                    { "be074e02-b4ac-4621-b3f6-13f23f08d7e0", "2", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Joindate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3cf93777-050b-448d-bc03-1b1b49413814", 0, "8b87d25f-ca35-469b-b48e-d98e4bee4b18", "user@example.com", true, new DateTime(2024, 5, 23, 13, 23, 0, 888, DateTimeKind.Local).AddTicks(2102), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOGlo3pa1zOulejQv1JpUzb/CJ0CATkpmchUePCvI4K4NaqXjQTVh292WhukrUcIVg==", null, false, "eca52f2d-e4ae-42b3-a9ca-eddcb4ab1763", false, "user@example.com" },
                    { "a2d2f43b-d465-4f32-add1-f86fb9783536", 0, "cd553d00-7638-4536-8635-e331d3d64628", "admin@example.com", true, new DateTime(2024, 5, 23, 13, 23, 0, 795, DateTimeKind.Local).AddTicks(8837), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEN0ElSl+tZxbWixatWW2yTDV+I3Ki4W83BktsTZYL3LcplLexEmODmqWdZ0XyDusWQ==", null, false, "df480e93-6dff-4710-ac14-e4f1889b7a98", false, "admin@example.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aee423a8-8370-4b31-a168-867e6c7722f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be074e02-b4ac-4621-b3f6-13f23f08d7e0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cf93777-050b-448d-bc03-1b1b49413814");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2d2f43b-d465-4f32-add1-f86fb9783536");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d2f93d56-7247-425c-8efd-afb87d5b66e9", "1", "Admin", "ADMIN" },
                    { "f9866e6f-66ca-4f6d-998d-0ef6d500bdb4", "2", "User", "USER" }
                });
        }
    }
}
