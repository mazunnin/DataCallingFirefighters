using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataCallingFirefighters.DomainObjects.Ports
{
    public interface IReadOnlyDataCallingFirefighterRepository
    {
        Task<DataCallingFirefighter> GetDataCallingFirefighter(long id);

        Task<IEnumerable<DataCallingFirefighter>> GetAllDataCallingFirefighters();

        Task<IEnumerable<DataCallingFirefighter>> QueryDataCallingFirefighter(ICriteria<DataCallingFirefighter> criteria);

    }

    public interface IDataCallingFirefighterRepository
    {
        Task AddDataCallingFirefighter(DataCallingFirefighter parkingTerminal);

        Task RemoveDataCallingFirefighter(DataCallingFirefighter parkingTerminal);

        Task UpdateDataCallingFirefighter(DataCallingFirefighter parkingTerminal);
    }
}
