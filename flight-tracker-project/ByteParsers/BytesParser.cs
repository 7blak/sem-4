using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD1.FTRObjects;

namespace OOD1.ByteParsers
{
    public class BytesParser
    {
        public abstract class BytesToFTRObjectFactory
        {
            private static readonly Dictionary<string, Func<byte[], FTRObject>> Constructors = new Dictionary<string, Func<byte[], FTRObject>>
        {
                {"NCR", BytesCreatePerson.CreateObject },
                {"NPA", BytesCreatePerson.CreateObject },
                {"NCA", BytesCreateCargo.CreateObject },
                {"NCP", BytesCreatePlane.CreateObject },
                {"NPP", BytesCreatePlane.CreateObject },
                {"NAI", BytesCreateAirport.CreateObject },
                {"NFL", BytesCreateFlight.CreateObject }
        };
            public static FTRObject CreateFTRObject(byte[] data)
            {
                string type = ConvertFirstNBytesToString(data, 3);
                if (!Constructors.TryGetValue(type, out Func<byte[], FTRObject>? constructor))
                    throw new Exception("Invalid data!");
                return constructor.Invoke(data);
            }
        }
        public static string ConvertFirstNBytesToString(byte[] byteArray, int n)
        {
            if (byteArray.Length < n)
            {
                throw new ArgumentException("Byte array did not have at least n elements!");
            }
            Encoding encoding = Encoding.UTF8;
            byte[] bytes = new byte[n];
            Array.Copy(byteArray, bytes, n);
            return encoding.GetString(bytes);
        }
    }
}
