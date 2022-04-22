using AutoWrapper.Wrappers;
using Bookkeeping.API.RequestModel;
using Bookkeeping.API.Services;
using Bookkeeping.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bookkeeping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReconciliationController : ControllerBase
    {

        private readonly ILogger<ReconciliationController> _logger;
        private  IReconciliationService _service;

        public ReconciliationController(ILogger<ReconciliationController> logger, IReconciliationService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<ApiResponse> Get(ReconciliationRequestModel requestModel)
        {
            return await _service.GetData(requestModel);
        }

        [HttpPost("AddOrUpdateCostLog")]
        public async Task<ApiResponse> Post(List<AddUpdateCashFlowLogModel> models)
        {
            return await _service.AddUpdateCashFlowLog(models);
        }

    }
}