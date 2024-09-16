using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4df4c737-3e1e-4b18-8dd9-38106e17fd1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88363818-7b24-4230-938c-608a8631e77e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8fb775b4-ac83-4b18-b6ba-405756d63051", "af07c233-ae5a-45a3-ae7a-b60e29884928" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fb775b4-ac83-4b18-b6ba-405756d63051");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af07c233-ae5a-45a3-ae7a-b60e29884928");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f17c140-4b02-4e69-8f28-85fa45d9f38a", null, "User", "USER" },
                    { "97c68c5a-de4d-4dbd-b2f7-631e8ec9168f", null, "Administrator", "ADMINISTRATOR" },
                    { "d0e9037b-68e6-4a00-874c-c9c664492735", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d5656d60-4c91-45bb-b2ea-08e0f97469e4", 0, null, "", "30709467-3ba2-4490-a55d-e584cb728738", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEEOgtnPB9F79il6j+DXa2IhZ0AkKquHCWWYjXyB7VsYSlSSG/PaNGBk/ss/9MvidsA==", null, false, "dcf42e9d-339b-474b-a7f1-9ab8b4b6511e", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "97c68c5a-de4d-4dbd-b2f7-631e8ec9168f", "d5656d60-4c91-45bb-b2ea-08e0f97469e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f17c140-4b02-4e69-8f28-85fa45d9f38a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0e9037b-68e6-4a00-874c-c9c664492735");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "97c68c5a-de4d-4dbd-b2f7-631e8ec9168f", "d5656d60-4c91-45bb-b2ea-08e0f97469e4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97c68c5a-de4d-4dbd-b2f7-631e8ec9168f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5656d60-4c91-45bb-b2ea-08e0f97469e4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4df4c737-3e1e-4b18-8dd9-38106e17fd1c", null, "User", "USER" },
                    { "88363818-7b24-4230-938c-608a8631e77e", null, "Moderator", "MODERATOR" },
                    { "8fb775b4-ac83-4b18-b6ba-405756d63051", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "af07c233-ae5a-45a3-ae7a-b60e29884928", 0, null, "", "26f3068d-2f31-4f52-a90a-9edd36ce0e2c", "admin@gmail.com", false, false, null, null, null, null, null, false, "b402e65c-5164-480f-a3b1-e8f124f371e7", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8fb775b4-ac83-4b18-b6ba-405756d63051", "af07c233-ae5a-45a3-ae7a-b60e29884928" });
        }
    }
}
