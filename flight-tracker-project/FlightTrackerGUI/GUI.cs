using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FlightTrackerGUI;
using OOD1.FTRObjects;
using static OOD1.Util.Util;

namespace OOD1.FlightTrackerGUI
{
    public class GUI
    {
        private GUIAdapter GUIAdapter;
        private Thread? GUIThread;
        private bool bRunning;
        private Timer Timer;
        public GUI()
        {
            GUIAdapter = new GUIAdapter();
            GUIThread = null;
            bRunning = false;
            Timer = new Timer(UpdateGUI, null, 0, 1000);
        }
        public void Start()
        {
            if (GUIThread != null || bRunning)
            {
                Console.WriteLine("ERROR: GUI window was already started!");
                return;
            }
            bRunning = true;
            GUIThread = new Thread(Runner.Run);
            GUIThread.Start();
        }
        private void UpdateGUI(object? _)
        {
            GUIAdapter.UpdateFlightData();
            Runner.UpdateGUI(GUIAdapter);
        }
        public void Quit(bool bForced = false)
        {
            GUIAdapter.Quit();
            bRunning = false;
            Timer.Dispose();
            if (GUIThread == null)
                return;
            if (bForced)
                GUIThread.Interrupt();
            else
                GUIThread.Join();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"IsRunning: {bRunning}".PadLeft(1));
            return sb.ToString();
        }
    }
}
