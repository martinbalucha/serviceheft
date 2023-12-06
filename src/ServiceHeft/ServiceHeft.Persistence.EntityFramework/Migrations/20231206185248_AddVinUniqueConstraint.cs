using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceHeft.Persistence.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddVinUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Cars_Vin",
                table: "Cars",
                column: "Vin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Cars_Vin",
                table: "Cars");
        }
    }
}
