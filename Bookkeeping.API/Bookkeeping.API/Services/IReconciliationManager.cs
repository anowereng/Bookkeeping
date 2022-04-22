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
        Task<MonthValueViewModel> GetIncomeAmount(ReconciliationRequestModel request);
        Task<MonthValueViewModel> GetExpenseAmount(ReconciliationRequestModel request);
        Task<List<CashFlowLogsViewModel>> GetIncomeCashFlowTypesData(ReconciliationRequestModel request);
        Task<List<CashFlowLogsViewModel>> GetExpenseCashFlowTypesData(ReconciliationRequestModel request);
        MonthValueViewModel GetFinalResult(MonthValueViewModel recResult, MonthValueViewModel result);
        Task<MonthValueViewModel> GetReconciliationResult(ReconciliationRequestModel request);
        Task ClearData();

    }
}
