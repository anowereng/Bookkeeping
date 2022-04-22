using AutoWrapper.Wrappers;
using Bookkeeping.API.Models;
using Bookkeeping.API.RequestModel;
using Bookkeeping.API.ViewModels;
using System.Net;

namespace Bookkeeping.API.Services
{
    public class ReconciliationService : IReconciliationService
    {
        public BookkeepingContext _context;
        private IReconciliationManager _reconciliationManager;
        public ReconciliationService(BookkeepingContext context, IReconciliationManager reconciliationManager)
        {
            this._context = context;
            this._reconciliationManager = reconciliationManager;
        }
        public async Task<ApiResponse> GetData(ReconciliationRequestModel request)
        {
            var reconciliationViewModel = new ReconciliationViewModel();
            reconciliationViewModel.Income = await _reconciliationManager.GetIncomeAmount(request);
            reconciliationViewModel.Expense = await _reconciliationManager.GetExpenseAmount(request);
            reconciliationViewModel.CumulativeIncome = _reconciliationManager.CumulativeProcess(reconciliationViewModel.Income);
            reconciliationViewModel.CumulativeCost = _reconciliationManager.CumulativeProcess(reconciliationViewModel.Expense);
            reconciliationViewModel.Result = _reconciliationManager.IncomCostResultProcess(reconciliationViewModel.Income, reconciliationViewModel.Expense);
            reconciliationViewModel.IncomeCashFlowLogsData = await _reconciliationManager.GetIncomeCashFlowTypesData(request);
            reconciliationViewModel.ExpenseCashFlowLogsData = await _reconciliationManager.GetExpenseCashFlowTypesData(request);
            reconciliationViewModel.ReconciliationResult = await _reconciliationManager.GetReconciliationResult(request);
            reconciliationViewModel.FinalResult = _reconciliationManager.GetFinalResult(reconciliationViewModel.ReconciliationResult, reconciliationViewModel.Result);
            reconciliationViewModel.CumulativeFinalResult = _reconciliationManager.CumulativeProcess(reconciliationViewModel.FinalResult);


            return new ApiResponse { Result = reconciliationViewModel, StatusCode = (int)HttpStatusCode.OK, IsError = false };
        }
        public async Task<ApiResponse> AddUpdateCashFlowLog(List<AddUpdateCashFlowLogModel> models)
        {
            var list = models.Select(x => new CashFlowLog
            {
                Amount = x.Amount,
                Month = x.Month,
                CashFlowTypeId = x.TypeId,
                Year = x.Year
            }).ToList();

            await _reconciliationManager.ClearData();
            await _context.CashFlowLogs.AddRangeAsync(list);
            await _context.SaveChangesAsync();

            return new ApiResponse { Result = null, Message = "Save Successfully", StatusCode = (int)HttpStatusCode.OK, IsError = false };
        }

        
    }

}
