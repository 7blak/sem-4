using OOD1.News;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD1.FTRObjects
{
    public abstract class Plane : FTRObject, IReportable
    {
        public string Serial { get; set; }
        public string Country { get; set; }
        public string Model { get; set; }
        public Plane(string[] _data) : base(_data)
        {
            Serial = _data[2];
            Country = _data[3];
            Model = _data[4];
        }
        public abstract string Report(INewsProviders provider);
    }
    public class CargoPlane : Plane
    {
        public float MaxLoad { get; set; }
        public CargoPlane(string[] _data) : base(_data)
        {
            MaxLoad = float.Parse(_data[5], CultureInfo.InvariantCulture);
        }
        public override string Report(INewsProviders provider)
        {
            return provider.reportCargoPlane(this);
        }
    }
    public class PassengerPlane : Plane
    {
        public ushort FirstClassSize { get; set; }
        public ushort BusinessClassSize { get; set; }
        public ushort EconomyClassSize { get; set; }
        public PassengerPlane(string[] _data) : base(_data)
        {
            FirstClassSize = ushort.Parse(_data[5]);
            BusinessClassSize = ushort.Parse(_data[6]);
            EconomyClassSize = ushort.Parse(_data[7]);
        }
        public override string Report(INewsProviders provider)
        {
            return provider.reportPassengerPlane(this);
        }
    }
}
