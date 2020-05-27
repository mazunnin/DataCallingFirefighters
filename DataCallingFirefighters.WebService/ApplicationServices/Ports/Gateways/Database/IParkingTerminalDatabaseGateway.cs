using DataCallingFirefighters.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataCallingFirefighters.ApplicationServices.Ports.Gateways.Database
{
    public interface IDataCallingFirefighterDatabaseGateway
    {
        Task AddDataCallingFirefighter(DataCallingFirefighter dataCallingFirefighter);

        Task RemoveDataCallingFirefighter(DataCallingFirefighter dataCallingFirefighter);

        Task UpdateDataCallingFirefighter(DataCallingFirefighter dataCallingFirefighter);

        Task<DataCallingFirefighter> GetDataCallingFirefighter(long id);

        Task<IEnumerable<DataCallingFirefighter>> GetAllDataCallingFirefighters();

        Task<IEnumerable<DataCallingFirefighter>> QueryDataCallingFirefighter(Expression<Func<DataCallingFirefighter, bool>> filter);

    }
}