using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calcis.Modules.Fleet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCreatedTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTimestamp",
                schema: "fleet",
                table: "driver");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedTimestamp",
                schema: "fleet",
                table: "driver",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
