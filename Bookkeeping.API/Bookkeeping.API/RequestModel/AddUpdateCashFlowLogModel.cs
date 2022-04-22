namespace Bookkeeping.API.RequestModel
{
    public class AddUpdateCashFlowLogModel
    {
        public int LogId { get; set; }
        public int TypeId { get; set; }
        public int CashFlowId { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public double Amount { get; set; }
    }
}
