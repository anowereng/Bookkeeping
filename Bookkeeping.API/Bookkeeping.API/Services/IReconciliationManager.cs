using Bookkeeping.API.Models;
using Bookkeeping.API.RequestModel;
using Bookkeeping.API.ViewModels;

namespace Bookkeeping.API.Services
{
    public interface IReconciliationManager
    {
        MonthValueViewModel GetNewMonthModel(List<MonthAmountViewModel> amountViewModels);
        MonthValueViewModel CumulativeProcess(MonthValueViewModel viewModel);
        MonthValueViewModel IncomCostResultProcess(MonthValueViewModel income, MonthValueViewModel expense);
        List<CashFlowLogsViewModel> CashFlowLogsToViewModel(List<CashFlowLog> logs);
    }
}
