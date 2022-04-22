using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookkeeping.API.Migrations
{
    public partial class CashFlowLogs_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashFlowLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashFlowTypeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlowLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashFlowLogs_CashFlowTypes_CashFlowTypeId",
                        column: x => x.CashFlowTypeId,
                        principalTable: "CashFlowTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowLogs_CashFlowTypeId",
                table: "CashFlowLogs",
                column: "CashFlowTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashFlowLogs");
        }
    }
}
