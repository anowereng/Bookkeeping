using AutoWrapper.Wrappers;
using Bookkeeping.API.Models;
using Bookkeeping.API.RequestModel;
using Bookkeeping.API.ViewModels;

namespace Bookkeeping.API.Services
{
    public interface IReconciliationService
    {
        Task<ApiResponse> GetData(ReconciliationRequestModel input);
        Task<ApiResponse> AddUpdateCashFlowLog(List<AddUpdateCashFlowLogModel> models);

    }
}