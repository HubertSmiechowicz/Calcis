using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calcis.Modules.Maintenance.Infrastructure.Migrations.MaintenanceReadDb
{
    /// <inheritdoc />
    public partial class AddTableMechanic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "maintenance");

            migrationBuilder.CreateTable(
                name: "mechanic",
                schema: "maintenance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IsFGaseCertiicate = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsSepPermissions = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsTdtPermissions = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsTachographInstalationPermissions = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsUdtPermissions = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsWeldingPermissions = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mechanic", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mechanic",
                schema: "maintenance");
        }
    }
}
