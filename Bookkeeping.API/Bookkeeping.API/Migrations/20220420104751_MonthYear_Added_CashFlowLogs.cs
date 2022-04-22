using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookkeeping.API.Migrations
{
    public partial class MonthYear_Added_CashFlowLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "CashFlowLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "CashFlowLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "CashFlowLogs");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "CashFlowLogs");
        }
    }
}
