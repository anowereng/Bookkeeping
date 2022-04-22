using Bookkeeping.API.Models;
using Bookkeeping.API.RequestModel;
using Bookkeeping.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Bookkeeping.API.Services
{
    public class ReconciliationManager : IReconciliationManager
    {
        public BookkeepingContext _context;
        public ReconciliationManager(BookkeepingContext context)
        {
            this._context = context;
        }

        public MonthValueViewModel GetNewMonthModel(List<MonthAmountViewModel> amountViewModels)
        {
            var model = new MonthValueViewModel();
            foreach (var item in amountViewModels)
            {
                switch (item.Month.ToLower())
                {
                    case "jan":
                        model.Jan = item.Amount;
                        break;
                    case "feb":
                        model.Feb = item.Amount;
                        break;

                    case "mar":
                        model.Mar = item.Amount;
                        break;
                    case "apr":
                        model.Apr = item.Amount;
                        break;
                    case "may":
                        model.May = item.Amount;
                        break;
                    case "jun":
                        model.Jun = item.Amount;
                        break;
                    case "jul":
                        model.Jul = item.Amount;
                        break;
                    case "aug":
                        model.Aug = item.Amount;
                        break;
                    case "sep":
                        model.Sep = item.Amount;
                        break;
                    case "oct":
                        model.Oct = item.Amount;
                        break;
                    case "nov":
                        model.Nov = item.Amount;
                        break;
                    case "dec":
                        model.Dec = item.Amount;
                        break;
                    default:
                        break;
                }

            }
            return model;
        }
  
        public MonthValueViewModel CumulativeProcess(MonthValueViewModel viewModel)
        {
            var cumViewModel = new MonthValueViewModel();

            cumViewModel.Jan = viewModel.Jan;

            cumViewModel.Feb = cumViewModel.Jan + viewModel.Feb;

            cumViewModel.Mar = cumViewModel.Feb + viewModel.Mar;

            cumViewModel.Apr = cumViewModel.Mar + viewModel.Apr;

            cumViewModel.May = cumViewModel.Apr + viewModel.May;

            cumViewModel.Jun = cumViewModel.May + viewModel.Jun;

            cumViewModel.Jul = cumViewModel.Jun + viewModel.Jul;

            cumViewModel.Aug = cumViewModel.Jul + viewModel.Aug;

            cumViewModel.Sep = cumViewModel.Aug + viewModel.Sep;

            cumViewModel.Oct = cumViewModel.Sep + viewModel.Oct;

            cumViewModel.Nov = cumViewModel.Oct + viewModel.Nov;

            cumViewModel.Dec = cumViewModel.Nov + viewModel.Dec;

            return cumViewModel;
        }

        public MonthValueViewModel IncomCostResultProcess(MonthValueViewModel income, MonthValueViewModel expense)
        {
            var result = new MonthValueViewModel();

            result.Jan = income.Jan - expense.Jan;
            result.Feb = income.Feb - expense.Feb;
            result.Mar = income.Mar - expense.Mar;
            result.Apr = income.Apr - expense.Apr;
            result.May = income.May - expense.May;
            result.Jun = income.Jun - expense.Jun;

            result.Jul = income.Jul - expense.Jul;
            result.Aug = income.Aug - expense.Aug;
            result.Sep = income.Sep - expense.Sep;
            result.Oct = income.Oct - expense.Oct;
            result.Nov = income.Nov - expense.Nov;
            result.Dec = income.Dec - expense.Dec;

            return result;
        }
        public List<CashFlowLogsViewModel> CashFlowLogsToViewModel(List<CashFlowLog> logs)
        {
            var cashFlowList = new List<CashFlowLogsViewModel>();

            foreach (var item in logs)
            {
                var cashFlow = cashFlowList.FirstOrDefault(x => x.TypeName == item.CashFlowType.TypeName);

                if (cashFlow == null)
                {
                    cashFlow = new CashFlowLogsViewModel();
                    cashFlow.TypeName = item.CashFlowType.TypeName;
                    cashFlow.LogId = item.Id;
                    cashFlow.TypeId = item.CashFlowTypeId;
                    cashFlow.Year = item.Year;
                    cashFlowList.Add(cashFlow);
                }

                switch (item.Month.ToLower())
                {

                    case "jan":
                        cashFlow.Month.Jan = item.Amount;
                        break;
                    case "feb":
                        cashFlow.Month.Feb = item.Amount;
                        break;

                    case "mar":
                        cashFlow.Month.Mar = item.Amount;
                        break;
                    case "apr":
                        cashFlow.Month.Apr = item.Amount;
                        break;
                    case "may":
                        cashFlow.Month.May = item.Amount;
                        break;
                    case "jun":
                        cashFlow.Month.Jun = item.Amount;
                        break;
                    case "jul":
                        cashFlow.Month.Jul = item.Amount;
                        break;
                    case "aug":
                        cashFlow.Month.Aug = item.Amount;
                        break;
                    case "sep":
                        cashFlow.Month.Sep = item.Amount;
                        break;
                    case "oct":
                        cashFlow.Month.Oct = item.Amount;
                        break;
                    case "nov":
                        cashFlow.Month.Nov = item.Amount;
                        break;
                    case "dec":
                        cashFlow.Month.Dec = item.Amount;
                        break;
                    default:
                        break;
                }

            }
            return cashFlowList;
        }

        public async Task ClearData()
        {
            var list = await _context.CashFlowLogs.ToListAsync();
            _context.CashFlowLogs.RemoveRange(list);
            await _context.SaveChangesAsync();
        }

        public async Task<MonthValueViewModel> GetIncomeAmount(ReconciliationRequestModel input)
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

            var result = GetNewMonthModel(list);
            return result;
        }

        public async Task<MonthValueViewModel> GetReconciliationResult(ReconciliationRequestModel input)
        {

            var incomeModel = await _context.CashFlows.SingleOrDefaultAsync(x => x.Name == "Income");

            var incomeMonthViewModels = await _context.CashFlowLogs.Include(x => x.CashFlowType).ThenInclude(y => y.CashFlow)
                                                      .Where(x => x.Year == input.Year)
                                                      .ToListAsync();

            var list = incomeMonthViewModels.GroupBy(x => new { Month = x.Month })
                                  .Select(g =>
                                   new MonthAmountViewModel
                                   {
                                       Month = g.Key.Month,
                                       Amount = g.Sum(b => b.CashFlowType.CashFlow.Name == "Income" ? b.Amount : b.Amount * -1)
                                   }).ToList();

            var result = GetNewMonthModel(list);

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

            var result = GetNewMonthModel(list);
            return result;
        }

        public async Task<List<CashFlowLogsViewModel>> GetIncomeCashFlowTypesData(ReconciliationRequestModel input)
        {
            var incomeModel = await _context.CashFlows.SingleOrDefaultAsync(x => x.Name == "Income");

            var cashFlowLogs = await _context.CashFlowLogs.Include(x => x.CashFlowType).ThenInclude(y => y.CashFlow).
                                                                    Where(x => x.CashFlowType.CashFlow.Id == incomeModel.Id && x.Year == input.Year)
                                                                    .ToListAsync();
            var cashFlowLogsVewModel = CashFlowLogsToViewModel(cashFlowLogs);
            return cashFlowLogsVewModel;

        }

        public async Task<List<CashFlowLogsViewModel>> GetExpenseCashFlowTypesData(ReconciliationRequestModel input)
        {
            var expenseModel = await _context.CashFlows.SingleOrDefaultAsync(x => x.Name == "Expense");

            var cashFlowLogs = await _context.CashFlowLogs.Include(x => x.CashFlowType).ThenInclude(y => y.CashFlow).
                                                                    Where(x => x.CashFlowType.CashFlow.Id == expenseModel.Id && x.Year == input.Year)
                                                                    .ToListAsync();

            var cashFlowLogsVewModel = CashFlowLogsToViewModel(cashFlowLogs);
            return cashFlowLogsVewModel;

        }

        public MonthValueViewModel GetFinalResult(MonthValueViewModel recResult, MonthValueViewModel result)
        {

            recResult.Jan += result.Jan;
            recResult.Feb += result.Feb;
            recResult.Mar += result.Mar;
            recResult.Apr += result.Apr;
            recResult.May += result.May;
            recResult.Jun += result.Jun;
            recResult.Jul += result.Jul;
            recResult.Aug += result.Aug;
            recResult.Sep += result.Sep;
            recResult.Oct += result.Oct;
            recResult.Nov += result.Nov;
            recResult.Dec += result.Dec;

            return recResult;

        }



    }
}
