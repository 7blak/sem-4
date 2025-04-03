using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static OOD1.Util.Util;

namespace OOD1.Serialization
{
    public static class Serialization
    {
        public static void SerializeToJSON(List<FTRObjects.FTRObject> data, string filePath = $"{_rootDir}/Output/data.json")
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
            File.WriteAllText(filePath, json);
        }
    }
}
