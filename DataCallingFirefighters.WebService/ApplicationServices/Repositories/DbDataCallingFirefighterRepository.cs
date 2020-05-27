using DataCallingFirefighters.ApplicationServices.Ports.Gateways.Database;
using DataCallingFirefighters.DomainObjects;
using DataCallingFirefighters.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataCallingFirefighters.ApplicationServices.Repositories
{
    public class DbDataCallingFirefighterRepository : IReadOnlyDataCallingFirefighterRepository,
                                               IDataCallingFirefighterRepository
    {
        private readonly IDataCallingFirefighterDatabaseGateway _databaseGateway;

        public DbDataCallingFirefighterRepository(IDataCallingFirefighterDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<DataCallingFirefighter> GetDataCallingFirefighter(long id)
            => await _databaseGateway.GetDataCallingFirefighter(id);

        public async Task<IEnumerable<DataCallingFirefighter>> GetAllDataCallingFirefighters()
            => await _databaseGateway.GetAllDataCallingFirefighters();

        public async Task<IEnumerable<DataCallingFirefighter>> QueryDataCallingFirefighter(ICriteria<DataCallingFirefighter> criteria)
            => await _databaseGateway.QueryDataCallingFirefighter(criteria.Filter);

        public async Task AddDataCallingFirefighter(DataCallingFirefighter dataCallingFirefighter)
            => await _databaseGateway.AddDataCallingFirefighter(dataCallingFirefighter);

        public async Task RemoveDataCallingFirefighter(DataCallingFirefighter dataCallingFirefighter)
            => await _databaseGateway.RemoveDataCallingFirefighter(dataCallingFirefighter);

        public async Task UpdateDataCallingFirefighter(DataCallingFirefighter dataCallingFirefighter)
            => await _databaseGateway.UpdateDataCallingFirefighter(dataCallingFirefighter);
    }
}
