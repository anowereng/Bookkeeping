using Bookkeeping.API.Models;
using Bookkeeping.API.RequestModel;
using Bookkeeping.API.ViewModels;

namespace Bookkeeping.API.Services
{
    public class ReconciliationManager : IReconciliationManager
    {
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


    }
}
