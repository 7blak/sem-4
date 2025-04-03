using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static OOD1.Util.Util;

namespace OOD1.FTRObjects
{
    [JsonDerivedType(typeof(Crew))]
    [JsonDerivedType(typeof(Passenger))]
    [JsonDerivedType(typeof(Cargo))]
    [JsonDerivedType(typeof(CargoPlane))]
    [JsonDerivedType(typeof(PassengerPlane))]
    [JsonDerivedType(typeof(Airport))]
    [JsonDerivedType(typeof(Flight))]
    public abstract class FTRObject
    {
        
        public ulong ID { get; set; }
        private static readonly Dictionary<string, Func<string[], FTRObject>> Constructors = new Dictionary<string, Func<string[], FTRObject>>
        {
            {"C", (args) => new Crew(args) },
            {"P", (args) => new Passenger(args) },
            {"CA", (args) => new Cargo(args) },
            {"CP", (args) => new CargoPlane(args) },
            {"PP", (args) => new PassengerPlane(args) },
            {"AI", (args) => new Airport(args) },
            {"FL", (args) => new Flight(args) }
        };
        public FTRObject(string[] _data)
        {
            ID = ulong.Parse(_data[1]);
        }
        public static FTRObject CreateFTRObject(string[] fields)
        {
            if (!Constructors.TryGetValue(fields[0], out Func<string[], FTRObject>? constructor))
                throw new Exception("Invalid data!");
            return constructor.Invoke(fields);
        }
        public static List<FTRObject> CreateObjectsFromFTRFile(string filepath)
        {
            List<FTRObject> FTRObjects = new List<FTRObject>();
            string[] lines = File.ReadAllLines(filepath);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                FTRObjects.Add(CreateFTRObject(fields));
            }
            return FTRObjects;
        }
    }
    public struct Location
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float AMSL { get; set; }
        public Location(float _latitude, float _longitude, float _AMSL)
        {
            Latitude = _latitude;
            Longitude = _longitude;
            AMSL = _AMSL;
        }
        public static Location Parse(params string[] _args)
        {
            Location location = new Location();
            location.Longitude = float.Parse(_args[0], CultureInfo.InvariantCulture);
            location.Latitude = float.Parse(_args[1], CultureInfo.InvariantCulture);
            location.AMSL = float.Parse(_args[2], CultureInfo.InvariantCulture);
            return location;
        }
        public override string ToString()
        {
            return $"Latitude: {Latitude}, Longituude: {Longitude}, AMSL: {AMSL}";
        }
    }
}
