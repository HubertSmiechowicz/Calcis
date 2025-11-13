using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calcis.Modules.Employee.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "employee");

            migrationBuilder.CreateTable(
                name: "user_entity",
                schema: "employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_entity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_group_membership",
                schema: "employee",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_group_membership", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_user_group_membership_user_entity_UserId",
                        column: x => x.UserId,
                        principalSchema: "employee",
                        principalTable: "user_entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_group_membership",
                schema: "employee");

            migrationBuilder.DropTable(
                name: "user_entity",
                schema: "employee");
        }
    }
}
