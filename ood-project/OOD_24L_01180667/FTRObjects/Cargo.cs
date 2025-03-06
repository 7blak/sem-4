using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD1.FTRObjects
{
    public class Cargo : FTRObject
    {
        public float Weight { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Cargo(string[] _data) : base(_data)
        {
            Weight = float.Parse(_data[2], CultureInfo.InvariantCulture);
            Code = _data[3];
            Description = _data[4];
        }
    }
}
