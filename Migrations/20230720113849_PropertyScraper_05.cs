using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PropertyScraper.Migrations
{
    /// <inheritdoc />
    public partial class PropertyScraper_05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Properties");

            migrationBuilder.CreateTable(
                name: "PropertyImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    thumbnail = table.Column<string>(type: "text", nullable: false),
                    small = table.Column<string>(type: "text", nullable: false),
                    medium = table.Column<string>(type: "text", nullable: false),
                    large = table.Column<string>(type: "text", nullable: false),
                    __typename = table.Column<string>(type: "text", nullable: false),
                    PropertyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyImage_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage",
                column: "PropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyImage");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Properties",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
