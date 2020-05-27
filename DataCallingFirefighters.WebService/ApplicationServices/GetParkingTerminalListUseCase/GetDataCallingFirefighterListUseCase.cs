using System.Threading.Tasks;
using System.Collections.Generic;
using DataCallingFirefighters.DomainObjects;
using DataCallingFirefighters.DomainObjects.Ports;
using DataCallingFirefighters.ApplicationServices.Ports;

namespace DataCallingFirefighters.ApplicationServices.GetParkingTerminalListUseCase
{
    public class GetDataCallingFirefighterListUseCase : IGetDataCallingFirefighterListUseCase
    {
        private readonly IReadOnlyDataCallingFirefighterRepository _readOnlyDataCallingFirefighterRepository;

        public GetDataCallingFirefighterListUseCase(IReadOnlyDataCallingFirefighterRepository readOnlyParkingTerminalRepository) 
            => _readOnlyDataCallingFirefighterRepository = readOnlyParkingTerminalRepository;

        public async Task<bool> Handle(GetDataCallingFirefighterListUseCaseRequest request, IOutputPort<GetDataCallingFirefighterListUseCaseResponse> outputPort)
        {
            IEnumerable<DataCallingFirefighter> dataCallingFirefighters = null;
            if (request.DataCallingFirefighterId != null)
            {
                var dataCallingFirefighter = await _readOnlyDataCallingFirefighterRepository.GetDataCallingFirefighter(request.DataCallingFirefighterId.Value);
                dataCallingFirefighters = (dataCallingFirefighter != null) ? new List<DataCallingFirefighter>() { dataCallingFirefighter } : new List<DataCallingFirefighter>();
                
            }
            else if (request.District != null)
            {
                dataCallingFirefighters = await _readOnlyDataCallingFirefighterRepository.QueryDataCallingFirefighter(new DistrictCriteria(request.District));
            }
            else
            {
                dataCallingFirefighters = await _readOnlyDataCallingFirefighterRepository.GetAllDataCallingFirefighters();
            }
            outputPort.Handle(new GetDataCallingFirefighterListUseCaseResponse(dataCallingFirefighters));
            return true;
        }
    }
}
