using System;
using System.Collections.Generic;
using System.Text;

namespace DataCallingFirefighters.DomainObjects
{
    public class DataCallingFirefighter : DomainObject
    {
        public string NumberOfCalls { get; set; }

        public string Month { get; set; }

        public string Year { get; set; }

        public string District { get; set; }


    }
}
