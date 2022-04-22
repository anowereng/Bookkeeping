using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookkeeping.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashFlows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashFlowTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashFlowId = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlowTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashFlowTypes_CashFlows_CashFlowId",
                        column: x => x.CashFlowId,
                        principalTable: "CashFlows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YearMonthIncomeExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashFlowId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearMonthIncomeExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YearMonthIncomeExpenses_CashFlows_CashFlowId",
                        column: x => x.CashFlowId,
                        principalTable: "CashFlows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowTypes_CashFlowId",
                table: "CashFlowTypes",
                column: "CashFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_YearMonthIncomeExpenses_CashFlowId",
                table: "YearMonthIncomeExpenses",
                column: "CashFlowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashFlowTypes");

            migrationBuilder.DropTable(
                name: "YearMonthIncomeExpenses");

            migrationBuilder.DropTable(
                name: "CashFlows");
        }
    }
}
