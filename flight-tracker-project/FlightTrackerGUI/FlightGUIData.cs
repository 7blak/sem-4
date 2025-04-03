using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD1.FlightTrackerGUI
{
    public interface IFlight
    {
        public UInt64 ID { get; set; }
        public ulong OriginID { get; set; }
        public ulong DestinationID { get; set; }
        public string TakeoffTime { get; set; }
        public string LandingTime { get; set; }
        public FTRObjects.Location Location { get; set; }
        public ulong PlaneID { get; set; }
        public ulong[] CrewList { get; set; }
        public ulong[] LoadList { get; set; }
    }
    public class FlightGUIData : IFlight
    {
        public UInt64 ID { get; set; }
        public WorldPosition WorldPosition { get; set; }
        public WorldPosition? SourcePosition { get; set; }
        public double MapCoordRotation { get; set; }
        public FTRObjects.Flight Flight { get; set; }
        public ulong OriginID { get => Flight.OriginID; set => Flight.OriginID = value; }
        public ulong DestinationID { get => Flight.DestinationID; set => Flight.DestinationID = value; }
        public string TakeoffTime { get => Flight.TakeoffTime; set => Flight.TakeoffTime = value; }
        public string LandingTime { get => Flight.LandingTime; set => Flight.LandingTime = value; }
        public FTRObjects.Location Location { get => Flight.Location; set => Flight.Location = value; }
        public ulong PlaneID { get => Flight.PlaneID; set => Flight.PlaneID = value; }
        public ulong[] CrewList { get => Flight.CrewList; set => Flight.CrewList = value; }
        public ulong[] LoadList { get => Flight.LoadList; set => Flight.LoadList = value; }
        public FlightGUIData(UInt64 _ID, WorldPosition _WorldPosition, double _MapCoordRotation, FTRObjects.Flight flight)
        {
            ID = _ID;
            WorldPosition = _WorldPosition;
            MapCoordRotation = _MapCoordRotation;
            Flight = flight;
        }
    }
}
