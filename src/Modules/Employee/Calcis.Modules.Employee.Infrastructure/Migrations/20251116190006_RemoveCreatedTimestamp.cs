using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calcis.Modules.Employee.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCreatedTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTimestamp",
                schema: "employee",
                table: "user_entity");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "employee",
                table: "user_entity",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "employee",
                table: "user_entity");

            migrationBuilder.AddColumn<long>(
                name: "CreatedTimestamp",
                schema: "employee",
                table: "user_entity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
