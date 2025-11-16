using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calcis.Modules.Employee.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedTimestamp",
                schema: "employee",
                table: "user_entity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "employee",
                table: "user_entity",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailVerified",
                schema: "employee",
                table: "user_entity",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                schema: "employee",
                table: "user_entity",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "employee",
                table: "user_entity",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "employee",
                table: "user_entity",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NotBefore",
                schema: "employee",
                table: "user_entity",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                schema: "employee",
                table: "user_entity",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Totp",
                schema: "employee",
                table: "user_entity",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                schema: "employee",
                table: "user_entity",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTimestamp",
                schema: "employee",
                table: "user_entity");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "employee",
                table: "user_entity");

            migrationBuilder.DropColumn(
                name: "EmailVerified",
                schema: "employee",
                table: "user_entity");

            migrationBuilder.DropColumn(
                name: "Enabled",
                schema: "employee",
                table: "user_entity");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "employee",
                table: "user_entity");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "employee",
                table: "user_entity");

            migrationBuilder.DropColumn(
                name: "NotBefore",
                schema: "employee",
                table: "user_entity");

            migrationBuilder.DropColumn(
                name: "State",
                schema: "employee",
                table: "user_entity");

            migrationBuilder.DropColumn(
                name: "Totp",
                schema: "employee",
                table: "user_entity");

            migrationBuilder.DropColumn(
                name: "Username",
                schema: "employee",
                table: "user_entity");
        }
    }
}
