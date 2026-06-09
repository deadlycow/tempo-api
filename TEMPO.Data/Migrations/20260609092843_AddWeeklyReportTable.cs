using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEMPO.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWeeklyReportTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeEntries_AspNetUsers_EmployeeId",
                table: "TimeEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeEntries_Projects_ProjectId",
                table: "TimeEntries");

            migrationBuilder.AddColumn<Guid>(
                name: "WeeklyReportId",
                table: "TimeEntries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Projects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "WeeklyReport",
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
                    table.PrimaryKey("PK_WeeklyReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyReport_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_WeeklyReportId",
                table: "TimeEntries",
                column: "WeeklyReportId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyReport_EmployeeId",
                table: "WeeklyReport",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeEntries_AspNetUsers_EmployeeId",
                table: "TimeEntries",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeEntries_Projects_ProjectId",
                table: "TimeEntries",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeEntries_WeeklyReport_WeeklyReportId",
                table: "TimeEntries",
                column: "WeeklyReportId",
                principalTable: "WeeklyReport",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeEntries_AspNetUsers_EmployeeId",
                table: "TimeEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeEntries_Projects_ProjectId",
                table: "TimeEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeEntries_WeeklyReport_WeeklyReportId",
                table: "TimeEntries");

            migrationBuilder.DropTable(
                name: "WeeklyReport");

            migrationBuilder.DropIndex(
                name: "IX_TimeEntries_WeeklyReportId",
                table: "TimeEntries");

            migrationBuilder.DropColumn(
                name: "WeeklyReportId",
                table: "TimeEntries");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Projects");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeEntries_AspNetUsers_EmployeeId",
                table: "TimeEntries",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeEntries_Projects_ProjectId",
                table: "TimeEntries",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
