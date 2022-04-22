namespace Bookkeeping.API.Models
{
    public class CashFlowLog : BaseEntity
    {
        public int CashFlowTypeId { get; set; }
        public CashFlowType CashFlowType { get; set; }
        public double Amount { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }

    }
}
