using DataCallingFirefighters.ApplicationServices.GetParkingTerminalListUseCase;
using System.Net;
using Newtonsoft.Json;
using DataCallingFirefighters.ApplicationServices.Ports;

namespace DataCallingFirefighters.InfrastructureServices.Presenters
{
    public class DataCallingFirefighterListPresenter : IOutputPort<GetDataCallingFirefighterListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public DataCallingFirefighterListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetDataCallingFirefighterListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.DataCallingFirefighters) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
