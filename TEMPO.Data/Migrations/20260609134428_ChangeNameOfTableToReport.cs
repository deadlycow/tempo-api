using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEMPO.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameOfTableToReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeEntries_WeeklyReport_WeeklyReportId",
                table: "TimeEntries");

            migrationBuilder.DropTable(
                name: "WeeklyReport");

            migrationBuilder.RenameColumn(
                name: "WeeklyReportId",
                table: "TimeEntries",
                newName: "ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeEntries_WeeklyReportId",
                table: "TimeEntries",
                newName: "IX_TimeEntries_ReportId");

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WeekStart = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RejectedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedBack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_EmployeeId",
                table: "Reports",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeEntries_Reports_ReportId",
                table: "TimeEntries",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeEntries_Reports_ReportId",
                table: "TimeEntries");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.RenameColumn(
                name: "ReportId",
                table: "TimeEntries",
                newName: "WeeklyReportId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeEntries_ReportId",
                table: "TimeEntries",
                newName: "IX_TimeEntries_WeeklyReportId");

            migrationBuilder.CreateTable(
                name: "WeeklyReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeedBack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RejectedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekStart = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyReport_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyReport_EmployeeId",
                table: "WeeklyReport",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeEntries_WeeklyReport_WeeklyReportId",
                table: "TimeEntries",
                column: "WeeklyReportId",
                principalTable: "WeeklyReport",
                principalColumn: "Id");
        }
    }
}
