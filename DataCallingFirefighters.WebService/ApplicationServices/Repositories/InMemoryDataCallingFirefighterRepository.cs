using DataCallingFirefighters.DomainObjects;
using DataCallingFirefighters.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataCallingFirefighters.ApplicationServices.Repositories
{
    public class InMemoryDataCallingFirefighterRepository : IReadOnlyDataCallingFirefighterRepository,
                                                            IDataCallingFirefighterRepository 
    {
        private readonly List<DataCallingFirefighter> _dataCallingFirefighters = new List<DataCallingFirefighter>();

        public InMemoryDataCallingFirefighterRepository(IEnumerable<DataCallingFirefighter> dataCallingFirefighters = null)
        {
            if (dataCallingFirefighters != null)
            {
                _dataCallingFirefighters.AddRange(dataCallingFirefighters);
            }
        }

        public Task AddDataCallingFirefighter(DataCallingFirefighter dataCallingFirefighter)
        {
            _dataCallingFirefighters.Add(dataCallingFirefighter);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<DataCallingFirefighter>> GetAllDataCallingFirefighters()
        {
            return Task.FromResult(_dataCallingFirefighters.AsEnumerable());
        }

        public Task<DataCallingFirefighter> GetDataCallingFirefighter(long id)
        {
            return Task.FromResult(_dataCallingFirefighters.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<DataCallingFirefighter>> QueryDataCallingFirefighter(ICriteria<DataCallingFirefighter> criteria)
        {
            return Task.FromResult(_dataCallingFirefighters.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveDataCallingFirefighter(DataCallingFirefighter dataCallingFirefighter)
        {
            _dataCallingFirefighters.Remove(dataCallingFirefighter);
            return Task.CompletedTask;
        }

        public Task UpdateDataCallingFirefighter(DataCallingFirefighter dataCallingFirefighter)
        {
            var foundDataCallingFirefighter = GetDataCallingFirefighter(dataCallingFirefighter.Id).Result;
            if (foundDataCallingFirefighter == null)
            {
                AddDataCallingFirefighter(dataCallingFirefighter);
            }
            else
            {
                if (foundDataCallingFirefighter != dataCallingFirefighter)
                {
                    _dataCallingFirefighters.Remove(foundDataCallingFirefighter);
                    _dataCallingFirefighters.Add(dataCallingFirefighter);
                }
            }
            return Task.CompletedTask;
        }
    }
}
