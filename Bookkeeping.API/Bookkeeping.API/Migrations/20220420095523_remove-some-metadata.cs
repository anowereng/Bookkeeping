using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookkeeping.API.Migrations
{
    public partial class removesomemetadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "YearMonthIncomeExpenses");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "YearMonthIncomeExpenses");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "CashFlowTypes");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "CashFlowTypes");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "CashFlows");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "CashFlows");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Created",
                table: "YearMonthIncomeExpenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Modified",
                table: "YearMonthIncomeExpenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Created",
                table: "CashFlowTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Modified",
                table: "CashFlowTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Created",
                table: "CashFlows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Modified",
                table: "CashFlows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
