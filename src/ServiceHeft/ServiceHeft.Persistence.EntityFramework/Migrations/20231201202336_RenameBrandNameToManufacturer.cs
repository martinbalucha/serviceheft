using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceHeft.Persistence.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RenameBrandNameToManufacturer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModelInfo_Brand",
                table: "Cars",
                newName: "ModelInfo_Manufacturer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModelInfo_Manufacturer",
                table: "Cars",
                newName: "ModelInfo_Brand");
        }
    }
}
