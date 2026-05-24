using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEMPO.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeEntryUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TimeEntries_ProjectId",
                table: "TimeEntries");

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_ProjectId_EmployeeId_Date",
                table: "TimeEntries",
                columns: new[] { "ProjectId", "EmployeeId", "Date" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TimeEntries_ProjectId_EmployeeId_Date",
                table: "TimeEntries");

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_ProjectId",
                table: "TimeEntries",
                column: "ProjectId");
        }
    }
}
