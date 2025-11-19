using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calcis.Modules.Employee.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsPasswordSetColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPasswordSet",
                schema: "employee",
                table: "user_entity",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPasswordSet",
                schema: "employee",
                table: "user_entity");
        }
    }
}
