using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD1.FTRObjects;

namespace OOD1.ByteParsers
{
    public abstract class BytesCreateCargo
    {
        public static FTRObject CreateObject(byte[] bytes)
        {
            if (bytes.Length < 27)
                throw new InvalidDataException("The message for creating a Cargo was too short!");
            string[] constructorArgs = new string[5];

            constructorArgs[0] = "CA";
            uint messageLength = BitConverter.ToUInt32(bytes, 3);
            constructorArgs[1] = BitConverter.ToUInt64(bytes, 7).ToString();
            constructorArgs[2] = BitConverter.ToSingle(bytes, 15).ToString(CultureInfo.InvariantCulture);
            constructorArgs[3] = Encoding.UTF8.GetString(bytes, 19, 6);
            ushort descriptionLength = BitConverter.ToUInt16(bytes, 25);
            constructorArgs[4] = Encoding.UTF8.GetString(bytes, 27, descriptionLength);

            return FTRObject.CreateFTRObject(constructorArgs);
        }
    }
}
