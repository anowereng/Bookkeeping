using Bookkeeping.API.RequestModel;

namespace Bookkeeping.API.ViewModels
{
    public class CashFlowLogsViewModel
    {
        public CashFlowLogsViewModel()
        {
            this.Month = new MonthValueViewModel();
        }
        public int LogId { get; set; }
        public string TypeName { get; set; }
        public int TypeId { get; set; }
        public MonthValueViewModel Month { get; set; }
        public string MonthName { get; set; }
        public double Amount { get; set; }
        public string Year { get; set; }

    }
}
