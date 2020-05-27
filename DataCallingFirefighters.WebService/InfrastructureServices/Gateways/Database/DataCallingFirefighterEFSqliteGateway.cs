using DataCallingFirefighters.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using DataCallingFirefighters.ApplicationServices.Ports.Gateways.Database;

namespace DataCallingFirefighters.InfrastructureServices.Gateways.Database
{
    public class DataCallingFirefighterEFSqliteGateway : IDataCallingFirefighterDatabaseGateway
    {
        private readonly DutaCallingFirefighter _dataCallingFirefighterContext;

        public DataCallingFirefighterEFSqliteGateway(DutaCallingFirefighter dataCallingContext)
            => _dataCallingFirefighterContext = dataCallingContext;

        public async Task<DataCallingFirefighter> GetDataCallingFirefighter(long id)
           => await _dataCallingFirefighterContext.DataCallingFirefighters.Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<DataCallingFirefighter>> GetAllDataCallingFirefighters()
            => await _dataCallingFirefighterContext.DataCallingFirefighters.ToListAsync();
          
        public async Task<IEnumerable<DataCallingFirefighter>> QueryDataCallingFirefighter(Expression<Func<DataCallingFirefighter, bool>> filter)
            => await _dataCallingFirefighterContext.DataCallingFirefighters.Where(filter).ToListAsync();

        public async Task AddDataCallingFirefighter(DataCallingFirefighter dataCallingFirefighter)
        {
            _dataCallingFirefighterContext.DataCallingFirefighters.Add(dataCallingFirefighter);
            await _dataCallingFirefighterContext.SaveChangesAsync();
        }

        public async Task UpdateDataCallingFirefighter(DataCallingFirefighter dataCallingFirefighter)
        {
            _dataCallingFirefighterContext.Entry(dataCallingFirefighter).State = EntityState.Modified;
            await _dataCallingFirefighterContext.SaveChangesAsync();
        }

        public async Task RemoveDataCallingFirefighter(DataCallingFirefighter dataCallingFirefighter)
        {
            _dataCallingFirefighterContext.DataCallingFirefighters.Remove(dataCallingFirefighter);
            await _dataCallingFirefighterContext.SaveChangesAsync();
        }

    }
}
