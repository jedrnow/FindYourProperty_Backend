using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyScraper.Migrations
{
    /// <inheritdoc />
    public partial class PropertyScraper_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Properties",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Properties");
        }
    }
}
