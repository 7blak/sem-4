using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD1.FTRObjects;
using static OOD1.Util.Util;

namespace OOD1.ByteParsers
{
    public abstract class BytesCreateFlight
    {
        public static FTRObject CreateObject(byte[] bytes)
        {
            if (bytes.Length < 59)
                throw new InvalidDataException("The message for creating a Flight was too short!");
            string[] constructorArgs = new string[12];

            constructorArgs[0] = "FL";
            uint messageLength = BitConverter.ToUInt32(bytes, 3);
            constructorArgs[1] = BitConverter.ToUInt64(bytes, 7).ToString();
            constructorArgs[2] = BitConverter.ToUInt64(bytes, 15).ToString();
            constructorArgs[3] = BitConverter.ToUInt64(bytes, 23).ToString();
            constructorArgs[4] = DateTimeOffset.FromUnixTimeMilliseconds(BitConverter.ToInt64(bytes, 31)).UtcDateTime.ToString("HH:mm");
            constructorArgs[5] = DateTimeOffset.FromUnixTimeMilliseconds(BitConverter.ToInt64(bytes, 39)).UtcDateTime.ToString("HH:mm");
            constructorArgs[9] = BitConverter.ToUInt64(bytes, 47).ToString();
            constructorArgs[6] = "0"; constructorArgs[7] = "0"; constructorArgs[8] = "0"; // No Location data for Flights; Default behaviour will show it as (0, 0).
            ushort crewCount = BitConverter.ToUInt16(bytes, 55);
            string[] crewArray = new string[crewCount];
            for (int i = 0; i < crewCount; i++)
                crewArray[i] = BitConverter.ToUInt64(bytes, 57 + i * 8).ToString();
            constructorArgs[10] = $"[{string.Join(';', crewArray)}]";
            ushort extraCount = BitConverter.ToUInt16(bytes, 57 + 8 * crewCount);
            string[] extraArray = new string[extraCount];
            for (int i = 0; i < extraCount; i++)
                extraArray[i] = BitConverter.ToUInt64(bytes, 59 + 8 * crewCount + i * 8).ToString();
            constructorArgs[11] = $"[{string.Join(';', extraArray)}]";

            return FTRObject.CreateFTRObject(constructorArgs);
        }
    }
}
