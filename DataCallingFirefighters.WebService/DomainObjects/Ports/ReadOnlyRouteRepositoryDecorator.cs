using DataCallingFirefighters.DomainObjects;
using DataCallingFirefighters.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataCallingFirefighters.DomainObjects.Repositories
{
    public abstract class ReadOnlyRouteRepositoryDecorator : IReadOnlyDataCallingFirefighterRepository
    {
        private readonly IReadOnlyDataCallingFirefighterRepository _dataCallingFirefighterRepository;

        public ReadOnlyRouteRepositoryDecorator(IReadOnlyDataCallingFirefighterRepository routeRepository)
        {
            _dataCallingFirefighterRepository = routeRepository;
        }

        public virtual async Task<IEnumerable<DataCallingFirefighter>> GetAllDataCallingFirefighters()
        {
            return await _dataCallingFirefighterRepository?.GetAllDataCallingFirefighters();
        }

        public virtual async Task<DataCallingFirefighter> GetDataCallingFirefighter(long id)
        {
            return await _dataCallingFirefighterRepository?.GetDataCallingFirefighter(id);
        }

        public virtual async Task<IEnumerable<DataCallingFirefighter>> QueryDataCallingFirefighter(ICriteria<DataCallingFirefighter> criteria)
        {
            return await _dataCallingFirefighterRepository?.QueryDataCallingFirefighter(criteria);
        }
    }
}
