using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calcis.Modules.Fleet.Infrastructure.Migrations.FleetReadDb
{
    /// <inheritdoc />
    public partial class FixDriverMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AdrExpiryDate",
                schema: "fleet",
                table: "driver",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AdrNumber",
                schema: "fleet",
                table: "driver",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CertificateNoCriminalRecordNumber",
                schema: "fleet",
                table: "driver",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedTimestamp",
                schema: "fleet",
                table: "driver",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DrivingLicenseExpiryDate",
                schema: "fleet",
                table: "driver",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DrivingLicenseNumber",
                schema: "fleet",
                table: "driver",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "fleet",
                table: "driver",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "fleet",
                table: "driver",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IdentityCardExpiryDate",
                schema: "fleet",
                table: "driver",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IdentityCardNumber",
                schema: "fleet",
                table: "driver",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Is95Code",
                schema: "fleet",
                table: "driver",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMedicalCertificateValid",
                schema: "fleet",
                table: "driver",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPsychologicalExamValid",
                schema: "fleet",
                table: "driver",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "fleet",
                table: "driver",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MedicalCertificateExpiryDate",
                schema: "fleet",
                table: "driver",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PassportExpiryDate",
                schema: "fleet",
                table: "driver",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                schema: "fleet",
                table: "driver",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PsychologicalExamExpiryDate",
                schema: "fleet",
                table: "driver",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TachographCardNumber",
                schema: "fleet",
                table: "driver",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "fleet",
                table: "driver",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdrExpiryDate",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "AdrNumber",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "CertificateNoCriminalRecordNumber",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "CreatedTimestamp",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "DrivingLicenseExpiryDate",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "DrivingLicenseNumber",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "IdentityCardExpiryDate",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "IdentityCardNumber",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "Is95Code",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "IsMedicalCertificateValid",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "IsPsychologicalExamValid",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "MedicalCertificateExpiryDate",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "PassportExpiryDate",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "PsychologicalExamExpiryDate",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "TachographCardNumber",
                schema: "fleet",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "fleet",
                table: "driver");
        }
    }
}
