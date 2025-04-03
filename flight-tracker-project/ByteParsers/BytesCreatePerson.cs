using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD1.FTRObjects;

namespace OOD1.ByteParsers
{
    public abstract class BytesCreatePerson
    {
        public static FTRObject CreateObject(byte[] bytes)
        {
            string type = BytesParser.ConvertFirstNBytesToString(bytes, 3);
            switch (type)
            {
                case "NCR":
                    {
                        if (bytes.Length < 36)
                            throw new InvalidDataException("The message for creating a Crew was too short!");
                        string[] constructorArgs = new string[8];

                        constructorArgs[0] = "C";
                        uint messageLength = BitConverter.ToUInt32(bytes, 3);
                        constructorArgs[1] = BitConverter.ToUInt64(bytes, 7).ToString();
                        ushort nameLength = BitConverter.ToUInt16(bytes, 15);
                        constructorArgs[2] = Encoding.UTF8.GetString(bytes, 17, nameLength);
                        constructorArgs[3] = BitConverter.ToUInt16(bytes, 17 + nameLength).ToString();
                        constructorArgs[4] = Encoding.UTF8.GetString(bytes, 19 + nameLength, 12);
                        ushort emailLength = BitConverter.ToUInt16(bytes, 31 + nameLength);
                        constructorArgs[5] = Encoding.UTF8.GetString(bytes, 33 + nameLength, emailLength);
                        constructorArgs[6] = BitConverter.ToUInt16(bytes, 33 + nameLength + emailLength).ToString();
                        constructorArgs[7] = Encoding.UTF8.GetString(bytes, 35 + nameLength + emailLength, 1);
                        return FTRObject.CreateFTRObject(constructorArgs);
                    }
                case "NPA":
                    {
                        if (bytes.Length < 42)
                            throw new InvalidDataException("The message for creating a Passenger was too short!");
                        string[] constructorArgs = new string[8];

                        constructorArgs[0] = "P";
                        uint messageLength = BitConverter.ToUInt32(bytes, 3);
                        constructorArgs[1] = BitConverter.ToUInt64(bytes, 7).ToString();
                        ushort nameLength = BitConverter.ToUInt16(bytes, 15);
                        constructorArgs[2] = Encoding.UTF8.GetString(bytes, 17, nameLength);
                        constructorArgs[3] = BitConverter.ToUInt16(bytes, 17 + nameLength).ToString();
                        constructorArgs[4] = Encoding.UTF8.GetString(bytes, 19 + nameLength, 12);
                        ushort emailLength = BitConverter.ToUInt16(bytes, 31 + nameLength);
                        constructorArgs[5] = Encoding.UTF8.GetString(bytes, 33 + nameLength, emailLength);
                        constructorArgs[6] = Encoding.UTF8.GetString(bytes, 33 + nameLength + emailLength, 1);
                        constructorArgs[7] = BitConverter.ToUInt64(bytes, 34 + nameLength + emailLength).ToString();
                        return FTRObject.CreateFTRObject(constructorArgs);
                    }
                default:
                    throw new InvalidDataException("The message for creating a Person was wrong!");
            }
        }
    }
}
