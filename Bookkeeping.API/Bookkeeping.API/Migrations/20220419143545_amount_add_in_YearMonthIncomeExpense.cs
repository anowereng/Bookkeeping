using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookkeeping.API.Migrations
{
    public partial class amount_add_in_YearMonthIncomeExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "YearMonthIncomeExpenses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "YearMonthIncomeExpenses");
        }
    }
}
