using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calcis.Modules.Fleet.Infrastructure.Migrations.FleetReadDb
{
    /// <inheritdoc />
    public partial class AddStateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                schema: "fleet",
                table: "driver",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                schema: "fleet",
                table: "driver");
        }
    }
}
