using Bookkeeping.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookkeeping.API
{
    public class BookkeepingContext: DbContext
    {
        public BookkeepingContext(DbContextOptions<BookkeepingContext> options)
      : base(options)
        {
        }

        public DbSet<CashFlow> CashFlows { get; set; }
        public DbSet<CashFlowType> CashFlowTypes { get; set; }
        public DbSet<YearMonthIncomeExpense> YearMonthIncomeExpenses { get; set; }
        public DbSet<CashFlowLog> CashFlowLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
