using DataCallingFirefighters.DomainObjects;
using DataCallingFirefighters.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCallingFirefighters.ApplicationServices.GetDataCallingFirefighterListUseCase
{
    public class GetDataCallingFirefighterListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<DataCallingFirefighter> DataCallingFirefighters { get; }

        public GetDataCallingFirefighterListUseCaseResponse(IEnumerable<DataCallingFirefighter> dataCallingFirefighters) => DataCallingFirefighters = dataCallingFirefighters;
    }
}
