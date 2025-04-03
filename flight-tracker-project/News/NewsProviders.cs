using OOD1.FTRObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD1.News
{
    public interface INewsProviders
    {
        public string reportAirport(Airport airport);
        public string reportCargoPlane(CargoPlane cargoPlane);
        public string reportPassengerPlane(PassengerPlane passengerPlane);
    }
    public class Television(string name) : INewsProviders
    {
        private string Name { get; set; } = name;
        public string reportAirport(Airport airport)
        {
            return $"<An image of {airport.Name} airport>";
        }
        public string reportCargoPlane(CargoPlane cargoPlane)
        {
            return $"<An image of {cargoPlane.Model} airport>";
        }
        public string reportPassengerPlane(PassengerPlane passengerPlane)
        {
            return $"<An image of {passengerPlane.Model} airport>";
        }
    }
    public class Radio(string name) : INewsProviders
    {
        private string Name { get; set; } = name;
        public string reportAirport(Airport airport)
        {
            return $"Reporting for {Name}, Ladies and Gentlemen, we are at the {airport.Name} airport.";
        }
        public string reportCargoPlane(CargoPlane cargoPlane)
        {
            return $"Reporting for {Name}, Ladies and Gentlemen, we are seeing the {cargoPlane.Serial} aircraft fly above us.";
        }
        public string reportPassengerPlane(PassengerPlane passengerPlane)
        {
            return $"Reporting for {Name}, Ladies and Gentlemen, we've just witnessed {passengerPlane.Serial} take off.";
        }
    }
    public class Newspaper(string name) : INewsProviders
    {
        private string Name { get; set; } = name;
        public string reportAirport(Airport airport)
        {
            return $"{Name} - A report from the {airport.Name} airport, {airport.Country}.";
        }
        public string reportCargoPlane(CargoPlane cargoPlane)
        {
            return $"{Name} - An interview with the crew of {cargoPlane.Serial}.";
        }
        public string reportPassengerPlane(PassengerPlane passengerPlane)
        {
            return $"{Name} - Breaking news! {passengerPlane.Model} aircraft loses EASA fails certification after inspection of {passengerPlane.Serial}.";
        }
    }
}
