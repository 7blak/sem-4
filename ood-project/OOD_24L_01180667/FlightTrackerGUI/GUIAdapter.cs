using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightTrackerGUI;
using static OOD1.Util.Util;
using static OOD1.ByteParsers.BytesParser;
using static OOD1.Observer.Observer;
using OOD1.FTRObjects;
using ExCSS;
using OOD1.ByteParsers;
using Mapsui.Providers.Wfs.Utilities;
using Avalonia.Markup.Xaml.MarkupExtensions;
using System.Reactive.Joins;
using Mapsui.Projections;
using System.Collections.Concurrent;
using Mapsui;
using Avalonia.Rendering.Composition;
using OOD1.Observer;

namespace OOD1.FlightTrackerGUI
{
    public class GUIAdapter : FlightsGUIData, IIDUpdater, IPositionUpdater
    {
        private ConcurrentDictionary<UInt64, Airport> AirportDictionary;
        private ConcurrentDictionary<UInt64, FlightGUIData> FlightsDictionary;
        private ConcurrentDictionary<UInt64, FlightGUIData> flightsData;
        public GUIAdapter()
        {
            AirportDictionary = new();
            FlightsDictionary = new();
            flightsData = new();
            ConsoleUI.FTRObjectsMutex.WaitOne();
            foreach (var @object in ConsoleUI.currentFTRObjects!)
            {
                if (@object is Airport)
                {
                    if (!AirportDictionary.TryAdd(@object.ID, (Airport)@object) && bDEBUG)
                        Console.WriteLine("DEBUG: Adding new airport to GUI Adapter Flight Dictionary, key already exists");
                }
                else if(@object is Flight)
                {
                    if (!FlightsDictionary.TryAdd(@object.ID, new(@object.ID, new WorldPosition(0, 0), 0, (Flight)@object)) && bDEBUG)
                        Console.WriteLine("DEBUG: Adding new flight to GUI Adapter Flight Dictionary, key already exists");
                }
            }
            ConsoleUI.FTRObjectsMutex.ReleaseMutex();
            SubToUpdater(this);
            SubToPosUpdater(this);
        }
        public override int GetFlightsCount()
        {
            return flightsData.Count;
        }
        public override UInt64 GetID(int index)
        {
            return flightsData.ElementAt(index).Value.ID;
        }
        public override WorldPosition GetPosition(int index)
        {
            return flightsData.ElementAt(index).Value.WorldPosition;
        }
        public override double GetRotation(int index)
        {
            return flightsData.ElementAt(index).Value.MapCoordRotation;
        }
        public void UpdateFlightData()
        {
            DateTime currentTime = DateTime.Now;
            if (overridenTime.HasValue) // DEBUG: Time hack
                currentTime = overridenTime.Value;
            foreach (FlightGUIData flight in FlightsDictionary.Values)
            {
                WorldPosition currentWorldPosition = CalculateCurrentPosition(flight.Flight, flight.SourcePosition, AirportDictionary[flight.DestinationID], currentTime);
                double rotation = CalculateRotation(currentWorldPosition, AirportDictionary[flight.DestinationID]);
                if (IsInAir(flight.Flight))
                {
                    if (!flightsData.TryAdd(flight.ID, new(flight.ID, currentWorldPosition, rotation, flight.Flight)))
                    {
                        flightsData[flight.ID].WorldPosition = currentWorldPosition;
                        flightsData[flight.ID].MapCoordRotation = rotation;
                    }
                }
            }
        }
        private WorldPosition CalculateCurrentPosition(Flight flight, WorldPosition? origin, Airport DestinationAirport, DateTime currentTime)
        {
            WorldPosition originWorldPos = new WorldPosition(AirportDictionary[flight.OriginID].Location.Latitude, AirportDictionary[flight.OriginID].Location.Longitude);
            if (origin != null)
            {
                originWorldPos = new WorldPosition(origin.Value.Longitude, origin.Value.Latitude);
            }
            if (DateTime.Parse(flight.TakeoffTime) > DateTime.Parse(flight.LandingTime)) // Case when the plane flies during midnight
            {
                if (currentTime <= DateTime.Parse(flight.TakeoffTime) && currentTime >= DateTime.Parse(flight.LandingTime)) // The plane is either after just landing or is about to take off - no information, so I interpret the second scenario
                {
                    return originWorldPos;
                }
            }
            else
            {
                if (currentTime <= DateTime.Parse(flight.TakeoffTime))
                {
                    return originWorldPos;
                }
                if (currentTime >= DateTime.Parse(flight.LandingTime))
                {
                    return new WorldPosition(DestinationAirport.Location.Latitude, DestinationAirport.Location.Longitude);
                }
            }
            TimeSpan currentAirTime = currentTime - DateTime.Parse(flight.TakeoffTime);
            if (currentAirTime < TimeSpan.Zero)
            {
                currentAirTime = currentAirTime + new TimeSpan(24, 0, 0);
            }
            TimeSpan totalFlightDuration = DateTime.Parse(flight.LandingTime) - DateTime.Parse(flight.TakeoffTime);
            if (totalFlightDuration < TimeSpan.Zero)
            {
                totalFlightDuration = totalFlightDuration + new TimeSpan(24, 0, 0);
            }
            double fractionElapsed = currentAirTime.TotalMilliseconds / totalFlightDuration.TotalMilliseconds;
            double currentLat = Double.Lerp(originWorldPos.Latitude, DestinationAirport.Location.Latitude, fractionElapsed);
            double currentLon = Double.Lerp(originWorldPos.Longitude, DestinationAirport.Location.Longitude, fractionElapsed);
            return new WorldPosition(currentLat, currentLon);
        }
        private double CalculateRotation(WorldPosition currentWorldPosition, Airport DestinationAirport)
        {
            (double y, double x) curr = SphericalMercator.FromLonLat(currentWorldPosition.Longitude, currentWorldPosition.Latitude);
            (double y, double x) tmep = SphericalMercator.FromLonLat(DestinationAirport.Location.Longitude, DestinationAirport.Location.Latitude);
            double dx = tmep.x - curr.x;
            double dy = tmep.y - curr.y;
            return Math.Atan2(dy, dx);
        }
        public void Quit()
        {
            Console.WriteLine("GUI Adapter terminated, close the GUI window to close the application");
        }

        public void UpdateID(ulong ID, ulong NewObjectID)
        {
            ConsoleUI.FTRObjectsMutex.WaitOne();
            FlightGUIData? objToUpdate = FlightsDictionary.FirstOrDefault(obj => obj.Key == ID).Value;
            if (objToUpdate == null)
            {
                Console.WriteLine($"GUIAdapter@UpdatePosition: Object to update was null");
            }
            else
            {
                objToUpdate.ID = NewObjectID;
            }
            ConsoleUI.FTRObjectsMutex.ReleaseMutex();
        }

        public void UpdatePosition(ulong ID, Location location)
        {
            ConsoleUI.FTRObjectsMutex.WaitOne();
            FlightGUIData? objToUpdate = FlightsDictionary.FirstOrDefault(obj => obj.Key == ID).Value;
            if (objToUpdate == null)
            {
                Console.WriteLine($"GUIAdapter@UpdatePosition: Object to update was null");
            }
            else
            {
                objToUpdate.SourcePosition = new WorldPosition(location.Latitude, location.Longitude);
            }
            ConsoleUI.FTRObjectsMutex.ReleaseMutex();
        }
    }
}
