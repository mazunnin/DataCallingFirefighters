using DataCallingFirefighters.DomainObjects;
using DataCallingFirefighters.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataCallingFirefighters.ApplicationServices.GetParkingTerminalListUseCase
{
    public class DistrictCriteria : ICriteria<DataCallingFirefighter>
    {
        public string District { get; }

        public DistrictCriteria(string district)
            => District = district;

        public Expression<Func<DataCallingFirefighter, bool>> Filter
            => (pt => pt.District == District);
    }
}
