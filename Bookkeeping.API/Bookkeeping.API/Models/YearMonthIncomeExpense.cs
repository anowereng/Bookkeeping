namespace Bookkeeping.API.Models
{
    public class YearMonthIncomeExpense: BaseEntity
    {
        public string Month { get; set; }
        public string Year { get; set; }
        public int CashFlowId { get; set; }
        public double Amount { get; set; }
        public CashFlow CashFlow { get; set; }
    }
}
