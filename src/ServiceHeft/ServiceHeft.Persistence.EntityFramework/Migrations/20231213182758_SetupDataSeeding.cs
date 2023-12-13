using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceHeft.Persistence.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class SetupDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Model",
                columns: new[] { "InternalName", "Manufacturer", "OfficialName" },
                values: new object[,]
                {
                    { "E39", "BMW", "M5" },
                    { "E46", "BMW", "330i" },
                    { "X7", "Citroen", "C5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Model",
                keyColumns: new[] { "InternalName", "Manufacturer" },
                keyValues: new object[] { "E39", "BMW" });

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumns: new[] { "InternalName", "Manufacturer" },
                keyValues: new object[] { "E46", "BMW" });

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumns: new[] { "InternalName", "Manufacturer" },
                keyValues: new object[] { "X7", "Citroen" });
        }
    }
}
