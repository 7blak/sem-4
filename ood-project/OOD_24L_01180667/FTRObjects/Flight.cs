using OOD1.FlightTrackerGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD1.FTRObjects
{
    public class Flight : FTRObject, IFlight
    {
        public ulong OriginID { get; set; }
        public ulong DestinationID { get; set; }
        public string TakeoffTime { get; set; }
        public string LandingTime { get; set; }
        public Location Location { get; set; }
        public ulong PlaneID { get; set; }
        public ulong[] CrewList { get; set; }
        public ulong[] LoadList { get; set; }
        public Flight(string[] _data) : base(_data)
        {
            OriginID = ulong.Parse(_data[2]);
            DestinationID = ulong.Parse(_data[3]);
            TakeoffTime = _data[4];
            LandingTime = _data[5];
            Location = Location.Parse(_data[6], _data[7], _data[8]);
            PlaneID = ulong.Parse(_data[9]);
            ulong[] temp = FTRFieldToUInt64Array(_data[10]);
            CrewList = new ulong[temp.Length];
            Array.Copy(temp, CrewList, temp.Length);
            temp = FTRFieldToUInt64Array(_data[11]);
            LoadList = new ulong[temp.Length];
            Array.Copy(temp, LoadList, temp.Length);
        }
        public static ulong[] FTRFieldToUInt64Array(string _data)
        {
            _data = _data.Substring(1, _data.Length - 2);
            string[] temp = _data.Split(';');
            ulong[] temp2 = new ulong[temp.Length];
            for (int i = 0; i < temp.Length; i++)
                temp2[i] = ulong.Parse(temp[i]);
            return temp2;
        }
    }
}
