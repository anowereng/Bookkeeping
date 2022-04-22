namespace Bookkeeping.API.ViewModels
{
    public class ReconciliationViewModel
    {
        public MonthValueViewModel Income { get; set; }
        public MonthValueViewModel Expense { get; set; }
        public MonthValueViewModel CumulativeIncome { get; set; }
        public MonthValueViewModel CumulativeCost { get; set; }
        public MonthValueViewModel Result { get; set; }
        public List<CashFlowLogsViewModel> IncomeCashFlowLogsData { get; set; }
        public List<CashFlowLogsViewModel> ExpenseCashFlowLogsData { get; set; }
        public MonthValueViewModel ReconciliationResult { get; set; }
        public MonthValueViewModel FinalResult { get; set; }
        public MonthValueViewModel CumulativeFinalResult { get; set; }
    }


}
