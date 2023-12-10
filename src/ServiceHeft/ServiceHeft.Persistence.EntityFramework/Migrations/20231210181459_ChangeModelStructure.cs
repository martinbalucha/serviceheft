using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceHeft.Persistence.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModelStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelInfo_Manufacturer",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModelInfo_ModelName",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "ModelInternalName",
                table: "Cars",
                type: "nvarchar(40)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModelManufacturer",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Manufacturer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InternalName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    OfficialName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => new { x.Manufacturer, x.InternalName });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelManufacturer_ModelInternalName",
                table: "Cars",
                columns: new[] { "ModelManufacturer", "ModelInternalName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Model_ModelManufacturer_ModelInternalName",
                table: "Cars",
                columns: new[] { "ModelManufacturer", "ModelInternalName" },
                principalTable: "Model",
                principalColumns: new[] { "Manufacturer", "InternalName" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Model_ModelManufacturer_ModelInternalName",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ModelManufacturer_ModelInternalName",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModelInternalName",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModelManufacturer",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "ModelInfo_Manufacturer",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModelInfo_ModelName",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
