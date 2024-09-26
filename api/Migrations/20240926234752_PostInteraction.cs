using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class PostInteraction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostInteractions",
                table: "PostInteractions");

            migrationBuilder.DropIndex(
                name: "IX_PostInteractions_UserId",
                table: "PostInteractions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66329958-6839-46e9-95ba-16a8d9b2e0aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8faf90a9-d569-456a-92b8-9b3cc0f9e359");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5966fb6-cd42-4935-86f6-7febb2566528");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PostInteractions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostInteractions",
                table: "PostInteractions",
                columns: new[] { "UserId", "PostId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f2f5af9-7ccf-456c-a5f7-a343816540a9", null, "User", "USER" },
                    { "3fd48d5a-778e-44ea-8635-7739a98d1510", null, "Moderator", "MODERATOR" },
                    { "d7e75a23-1d7f-410a-abed-cee3ce7aebb5", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostInteractions",
                table: "PostInteractions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f2f5af9-7ccf-456c-a5f7-a343816540a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fd48d5a-778e-44ea-8635-7739a98d1510");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7e75a23-1d7f-410a-abed-cee3ce7aebb5");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "PostInteractions",
                type: "TEXT",
                maxLength: 38,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostInteractions",
                table: "PostInteractions",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66329958-6839-46e9-95ba-16a8d9b2e0aa", null, "Moderator", "MODERATOR" },
                    { "8faf90a9-d569-456a-92b8-9b3cc0f9e359", null, "Administrator", "ADMINISTRATOR" },
                    { "b5966fb6-cd42-4935-86f6-7febb2566528", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostInteractions_UserId",
                table: "PostInteractions",
                column: "UserId");
        }
    }
}
