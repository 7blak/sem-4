using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OOD1.FTRObjects;

namespace OOD1.ByteParsers
{
    public abstract class BytesCreatePlane
    {
        public static FTRObject CreateObject(byte[] bytes)
        {
            string type = BytesParser.ConvertFirstNBytesToString(bytes, 3);
            switch (type)
            {
                case "NCP":
                    {
                        if (bytes.Length < 34)
                            throw new InvalidDataException("The message for creating a Cargo Plane was too short!");
                        string[] constructorArgs = new string[6];

                        constructorArgs[0] = "CP";
                        uint messageLength = BitConverter.ToUInt32(bytes, 3);
                        constructorArgs[1] = BitConverter.ToUInt64(bytes, 7).ToString();
                        constructorArgs[2] = Encoding.UTF8.GetString(bytes, 15, 10).Trim('\0'); // Data has weird trailing null characters, trimming them
                        constructorArgs[3] = Encoding.UTF8.GetString(bytes, 25, 3);
                        ushort modelLength = BitConverter.ToUInt16(bytes, 28);
                        constructorArgs[4] = Encoding.UTF8.GetString(bytes, 30, modelLength);
                        constructorArgs[5] = BitConverter.ToSingle(bytes, 30 + modelLength).ToString();

                        return FTRObject.CreateFTRObject(constructorArgs);
                    }
                case "NPP":
                    {
                        if (bytes.Length < 36)
                            throw new InvalidDataException("The message for creating an Passenger Plane was too short!");
                        string[] constructorArgs = new string[8];

                        constructorArgs[0] = "PP";
                        uint messageLength = BitConverter.ToUInt32(bytes, 3);
                        constructorArgs[1] = BitConverter.ToUInt64(bytes, 7).ToString();
                        constructorArgs[2] = Encoding.UTF8.GetString(bytes, 15, 10).Trim('\0'); // Data has weird trailing null characters, trimming them
                        constructorArgs[3] = Encoding.UTF8.GetString(bytes, 25, 3);
                        ushort modelLength = BitConverter.ToUInt16(bytes, 28);
                        constructorArgs[4] = Encoding.UTF8.GetString(bytes, 30, modelLength);
                        constructorArgs[5] = BitConverter.ToUInt16(bytes, 30 + modelLength).ToString();
                        constructorArgs[6] = BitConverter.ToUInt16(bytes, 32 + modelLength).ToString();
                        constructorArgs[7] = BitConverter.ToUInt16(bytes, 34 + modelLength).ToString();

                        return FTRObject.CreateFTRObject(constructorArgs);
                    }
                default:
                    throw new InvalidDataException("The message for creating a Plane was wrong!");
            }
        }
    }
}
