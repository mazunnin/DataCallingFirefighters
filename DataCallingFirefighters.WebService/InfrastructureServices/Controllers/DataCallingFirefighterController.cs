using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataCallingFirefighters.DomainObjects;
using DataCallingFirefighters.ApplicationServices.GetParkingTerminalListUseCase;
using DataCallingFirefighters.InfrastructureServices.Presenters;

namespace DataCallingFirefighters.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataCallingFirefighterController : ControllerBase
    {
        private readonly ILogger<DataCallingFirefighterController> _logger;
        private readonly IGetDataCallingFirefighterListUseCase _getDataCallingFirefighterListUseCase;

        public DataCallingFirefighterController(ILogger<DataCallingFirefighterController> logger,
                                IGetDataCallingFirefighterListUseCase getDataCallingFirefighterListUseCase)
        {
            _logger = logger;
            _getDataCallingFirefighterListUseCase = getDataCallingFirefighterListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDataCallingFirefighters()
        {
            var presenter = new DataCallingFirefighterListPresenter();
            await _getDataCallingFirefighterListUseCase.Handle(GetDataCallingFirefighterListUseCaseRequest.CreateAllDataCallingFirefightersRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{dataCallingFirefighterId}")]
        public async Task<ActionResult> GetDataCallingFirefighter(long dataCallingFirefighterId)
        {
            var presenter = new DataCallingFirefighterListPresenter();
            await _getDataCallingFirefighterListUseCase.Handle(GetDataCallingFirefighterListUseCaseRequest.CreateDataCallingFirefighterRequest(dataCallingFirefighterId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("District/{district}")]
        public async Task<ActionResult> GetDistrictFilter(string district)
        {
            var presenter = new DataCallingFirefighterListPresenter();
            await _getDataCallingFirefighterListUseCase.Handle(GetDataCallingFirefighterListUseCaseRequest.CreateDistrictParkingTerminalsRequest(district), presenter);
            return presenter.ContentResult;
        }
    }
}
