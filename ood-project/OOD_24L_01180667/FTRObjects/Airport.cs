using OOD1.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD1.FTRObjects
{
    public class Airport : FTRObject, IReportable
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Location Location { get; set; }
        public string Country { get; set; }
        public Airport(string[] _data) : base(_data)
        {
            Name = _data[2];
            Code = _data[3];
            Location = Location.Parse(_data[4], _data[5], _data[6]);
            Country = _data[7];
        }
        public string Report(INewsProviders provider)
        {
            return provider.reportAirport(this);
        }
    }
}
