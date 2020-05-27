using DataCallingFirefighters.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCallingFirefighters.ApplicationServices.GetParkingTerminalListUseCase
{
    public class GetDataCallingFirefighterListUseCaseRequest : IUseCaseRequest<GetDataCallingFirefighterListUseCaseResponse>
    {
        public string District { get; private set; }
        public long? DataCallingFirefighterId { get; private set; }

        private GetDataCallingFirefighterListUseCaseRequest()
        { }

        public static GetDataCallingFirefighterListUseCaseRequest CreateAllDataCallingFirefightersRequest()
        {
            return new GetDataCallingFirefighterListUseCaseRequest();
        }

        public static GetDataCallingFirefighterListUseCaseRequest CreateDataCallingFirefighterRequest(long dataCallingFirefighterId)
        {
            return new GetDataCallingFirefighterListUseCaseRequest() { DataCallingFirefighterId = dataCallingFirefighterId };
        }
        public static GetDataCallingFirefighterListUseCaseRequest CreateDistrictParkingTerminalsRequest(string district)
        {
            return new GetDataCallingFirefighterListUseCaseRequest() { District = district };
        }
    }
}
