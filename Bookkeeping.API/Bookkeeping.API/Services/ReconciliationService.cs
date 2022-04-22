using AutoWrapper.Wrappers;
using Bookkeeping.API.Models;
using Bookkeeping.API.RequestModel;
using Bookkeeping.API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            reconciliationViewModel.Income = await GetIncomeAmount(request);
            reconciliationViewModel.Expense = await GetExpenseAmount(request);
            reconciliationViewModel.CumulativeIncome = _reconciliationManager.CumulativeProcess(reconciliationViewModel.Income);
            reconciliationViewModel.CumulativeCost = _reconciliationManager.CumulativeProcess(reconciliationViewModel.Expense);
            reconciliationViewModel.Result = _reconciliationManager.IncomCostResultProcess(reconciliationViewModel.Income, reconciliationViewModel.Expense);
            reconciliationViewModel.IncomeCashFlowLogsData = await GetIncomeCashFlowTypesData(request);
            reconciliationViewModel.ExpenseCashFlowLogsData = await GetExpenseCashFlowTypesData(request);
            return new ApiResponse { Result = reconciliationViewModel, StatusCode = (int)HttpStatusCode.OK, IsError = false };
        }
        public async Task<ApiResponse> AddUpdateCashFlowLog(List<AddUpdateCashFlowLogModel> models)
        {
            await UpdateCashFlowLog(models);
            await AddCashFlowLog(models);

            return new ApiResponse { Result = null, Message = "Save Successfully", StatusCode = (int)HttpStatusCode.OK, IsError = false };
        }
        private async Task<bool> AddCashFlowLog(List<AddUpdateCashFlowLogModel> models)
        {
            var newItems = models.Where(x => x.LogId == 0).ToList();
            var list = newItems.Select(x => new CashFlowLog
            {
                Amount = x.Amount,
                Month = x.Month,
                CashFlowTypeId = x.TypeId,
                Year = x.Year
            }).ToList();

            await _context.CashFlowLogs.AddRangeAsync(list);
            await _context.SaveChangesAsync();
            return true;
        }
        private async Task<bool> UpdateCashFlowLog(List<AddUpdateCashFlowLogModel> models)
        {
            var updateItems = models.Where(x => x.LogId != 0).ToList();
            var selectedItems = models.Select(x => x.LogId).ToArray();
            var dbItems = _context.CashFlowLogs.Where(x => selectedItems.Any(y => x.Id == y)).ToList();

            if (!dbItems.Any())
                return false;

            foreach (var item in dbItems)
            {
                var updateItem = updateItems.Where(x => x.LogId == item.Id).FirstOrDefault();
                if (updateItem != null)
                {
                    item.Amount = updateItem.Amount;
                    item.Month = updateItem.Month;
                    await _context.SaveChangesAsync();
                }
            }
            return true;
        }
        private async Task<MonthValueViewModel> GetIncomeAmount(ReconciliationRequestModel input)
        {
            var incomeModel = await _context.CashFlows.SingleOrDefaultAsync(x => x.Name == "Income");

            var incomeMonthViewModels = await _context.YearMonthIncomeExpenses.Where(x => x.CashFlowId == incomeModel.Id && x.Year == input.Year).ToListAsync();
            var list = incomeMonthViewModels.GroupBy(x => new { x.Month, x.Amount })
                                             .Select(g =>
                                             {
                                                 var a = g.ToList();
                                                 return
                                                 new MonthAmountViewModel
                                                 {
                                                     Month = a[0].Month,
                                                     Amount = a[0].Amount
                                                 };
                                             }).ToList();

            var result = _reconciliationManager.GetNewMonthModel(list);
            return result;
        }
        public async Task<MonthValueViewModel> GetExpenseAmount(ReconciliationRequestModel input)
        {
            var expenseModel = await _context.CashFlows.SingleOrDefaultAsync(x => x.Name == "Expense");

            var expenseMonthViewModels = await _context.YearMonthIncomeExpenses.Where(x => x.CashFlowId == expenseModel.Id && x.Year == input.Year).ToListAsync();
            var list = expenseMonthViewModels.GroupBy(x => new { x.Month, x.Amount })
                                             .Select(g =>
                                             {
                                                 var a = g.ToList();
                                                 return
                                                 new MonthAmountViewModel
                                                 {
                                                     Month = a[0].Month,
                                                     Amount = a[0].Amount
                                                 };
                                             }).ToList();

            var result = _reconciliationManager.GetNewMonthModel(list);
            return result;
        }

        private async Task<List<CashFlowLogsViewModel>> GetIncomeCashFlowTypesData(ReconciliationRequestModel input)
        {
            var incomeModel = await _context.CashFlows.SingleOrDefaultAsync(x => x.Name == "Income");

            var cashFlowLogs = await _context.CashFlowLogs.Include(x => x.CashFlowType).ThenInclude(y => y.CashFlow).
                                                                    Where(x => x.CashFlowType.CashFlow.Id == incomeModel.Id && x.Year == input.Year)
                                                                    .ToListAsync();
            var cashFlowLogsVewModel = _reconciliationManager.CashFlowLogsToViewModel(cashFlowLogs);
            return cashFlowLogsVewModel;

        }

        private async Task<List<CashFlowLogsViewModel>> GetExpenseCashFlowTypesData(ReconciliationRequestModel input)
        {
            var expenseModel = await _context.CashFlows.SingleOrDefaultAsync(x => x.Name == "Expense");

            var cashFlowLogs = await _context.CashFlowLogs.Include(x => x.CashFlowType).ThenInclude(y => y.CashFlow).
                                                                    Where(x => x.CashFlowType.CashFlow.Id == expenseModel.Id && x.Year == input.Year)
                                                                    .ToListAsync();

            var cashFlowLogsVewModel = _reconciliationManager.CashFlowLogsToViewModel(cashFlowLogs);
            return cashFlowLogsVewModel;

        }
       
    }

}
