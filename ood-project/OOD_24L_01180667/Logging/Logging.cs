using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOD1.Util.Util;

namespace OOD1.Logging
{
    public static class Logging
    {
        public static void Log(string message)
        {
            File.AppendAllText(currentLogFile, $"{ DateTime.Now.ToString("HH_mm_ss")}: {message}\n");
        }
    }
}
