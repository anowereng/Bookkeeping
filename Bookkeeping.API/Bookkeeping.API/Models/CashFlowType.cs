namespace Bookkeeping.API.Models
{
    public class CashFlowType: BaseEntity
    {
        public int CashFlowId { get; set; }
        public CashFlow CashFlow { get; set; }
        public string TypeName { get; set; }

    }
}
