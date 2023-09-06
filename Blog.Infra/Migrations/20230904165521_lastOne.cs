using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Infra.Migrations
{
    /// <inheritdoc />
    public partial class lastOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "99f58a33-0090-4e49-ba68-dd75298a5055",
                column: "ConcurrencyStamp",
                value: "99f58a33-0090-4e49-ba68-dd75298a5055");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "680701c5-19d5-4ea2-97ed-126b5ae40803", "680701c5-19d5-4ea2-97ed-126b5ae40803", "Admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "680701c5-19d5-4ea2-97ed-126b5ae40803");

            migrationBuilder.UpdateData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "99f58a33-0090-4e49-ba68-dd75298a5055",
                column: "ConcurrencyStamp",
                value: null);
        }
    }
}
