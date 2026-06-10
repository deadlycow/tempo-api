using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEMPO.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEntityToDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reports_EmployeeId",
                table: "Reports");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "TimeEntries",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_EmployeeId_WeekStart",
                table: "Reports",
                columns: new[] { "EmployeeId", "WeekStart" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reports_EmployeeId_WeekStart",
                table: "Reports");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeEntries",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_EmployeeId",
                table: "Reports",
                column: "EmployeeId");
        }
    }
}
