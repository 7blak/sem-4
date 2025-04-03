using OOD1.FTRObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD1.Util
{
    public static class Util
    {
        public const string _rootDir = "../../..";
        public static bool bDEBUG = false;
        public static DateTime? overridenTime = null;
        public static string currentLogFile = $"{_rootDir}/Output/log_{DateTime.Now.ToString("M_dd_HH_mm_ss")}.txt";
        public static bool IsInAir(Flight flight)
        {
            if (DateTime.Parse(flight.TakeoffTime) >= DateTime.Parse(flight.LandingTime))
            {
                if (DateTime.Now <= DateTime.Parse(flight.TakeoffTime) && DateTime.Now >= DateTime.Parse(flight.LandingTime))
                {
                    return false;
                }
            }
            else
            {
                if (DateTime.Now <= DateTime.Parse(flight.TakeoffTime))
                {
                    return false;
                }
                if (DateTime.Now >= DateTime.Parse(flight.LandingTime))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
