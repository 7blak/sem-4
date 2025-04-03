using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD1.FTRObjects;

namespace OOD1.ByteParsers
{
    public abstract class BytesCreateAirport
    {
        public static FTRObject CreateObject(byte[] bytes)
        {
            if (bytes.Length < 35)
                throw new InvalidDataException("The message for creating an Airport was too short!");
            string[] constructorArgs = new string[8];

            constructorArgs[0] = "AI";
            uint messageLength = BitConverter.ToUInt32(bytes, 3);
            constructorArgs[1] = BitConverter.ToUInt64(bytes, 7).ToString();
            ushort nameLength = BitConverter.ToUInt16(bytes, 15);
            constructorArgs[2] = Encoding.UTF8.GetString(bytes, 17, nameLength);
            constructorArgs[3] = Encoding.UTF8.GetString(bytes, 17 + nameLength, 3);
            constructorArgs[4] = BitConverter.ToSingle(bytes, 20 + nameLength).ToString(CultureInfo.InvariantCulture);
            constructorArgs[5] = BitConverter.ToSingle(bytes, 24 + nameLength).ToString(CultureInfo.InvariantCulture);
            constructorArgs[6] = BitConverter.ToSingle(bytes, 28 + nameLength).ToString(CultureInfo.InvariantCulture);
            constructorArgs[7] = Encoding.UTF8.GetString(bytes, 32 + nameLength, 3);
            
            return FTRObject.CreateFTRObject(constructorArgs);
        }
    }
}
