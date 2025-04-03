using Microsoft.Win32.SafeHandles;
using NetworkSourceSimulator;
using OOD1.ByteParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using NetSim = NetworkSourceSimulator;
using static OOD1.Util.Util;
using static OOD1.Observer.Observer;
using static OOD1.FTRObjects.FTRObject;
using static OOD1.Logging.Logging;
using OOD1.Observer;
using Avalonia.Controls;
using OOD1.FTRObjects;
using Avalonia.Logging;
using NetTopologySuite.Geometries;
using System.Globalization;

namespace OOD1.NetworkSourceSimulation
{
    public class NetworkSourceProcessor : IIDUpdater, IPositionUpdater, IContactInfoUpdater
    {
        private NetSim.NetworkSourceSimulator dataSource;
        private Thread? dataSourceThread;
        private bool bRunning;
        private bool bLoopNetSource;
        public NetworkSourceProcessor(string ftrFilePath, int minOffsetInMs, int maxOffsetInMs)
        {
            dataSource = new NetSim.NetworkSourceSimulator(ftrFilePath, minOffsetInMs, maxOffsetInMs);
            bRunning = false;
            bLoopNetSource = false; // Disabled for now
            dataSourceThread = null;
            ConsoleUI.FTRObjectsMutex.WaitOne();
            if (ConsoleUI.currentFTRObjects == null)
                ConsoleUI.currentFTRObjects = new List<FTRObject>();
            ConsoleUI.FTRObjectsMutex.ReleaseMutex();
            SubToContactUpdater(this);
            SubToPosUpdater(this);
            SubToUpdater(this);
        }
        public void StartListening()
        {
            bRunning = true;
            dataSource.OnNewDataReady += HandleNewDataReady;
            dataSource.OnIDUpdate += HandleIDUpdate;
            dataSource.OnPositionUpdate += HandlePositionUpdate;
            dataSource.OnContactInfoUpdate += HandleContactInfoUpdate;
            dataSourceThread = new Thread(RunDataSource);
            dataSourceThread.Start();
        }
        public void HandleNewDataReady(object sender, NewDataReadyArgs args)
        {
            var message = dataSource.GetMessageAt(args.MessageIndex);
            if (message.MessageBytes == null)
                return;
            ConsoleUI.FTRObjectsMutex.WaitOne();
            ConsoleUI.currentFTRObjects!.Add(BytesParser.BytesToFTRObjectFactory.CreateFTRObject(message.MessageBytes));
            ConsoleUI.FTRObjectsMutex.ReleaseMutex();
        }
        public void HandleIDUpdate(object sender, IDUpdateArgs args)
        {
            NotifyIDUpdaters(args.ObjectID, args.NewObjectID);
        }
        public void HandlePositionUpdate(object sender, PositionUpdateArgs args)
        {
            NotifyPosUpdaters(args.ObjectID, FTRObjects.Location.Parse(args.Longitude.ToString(CultureInfo.InvariantCulture), args.Latitude.ToString(CultureInfo.InvariantCulture), args.AMSL.ToString(CultureInfo.InvariantCulture)));
        }
        public void HandleContactInfoUpdate(object sender, ContactInfoUpdateArgs args)
        {
            NotifyContactInfoUpdaters(args.ObjectID, args.PhoneNumber, args.EmailAddress);
        }
        public void DisableSourceLoop()
        {
            bLoopNetSource = false;
        }
        public bool IsRunning()
        {
            return bRunning;
        }
        private void RunDataSource()
        {
            do
            {
                dataSource.Run();
                if (bDEBUG)
                    Console.WriteLine($"DEBUG: DataSource reached the end of the file, bLoopNetSource is {bLoopNetSource}");
            } while (bLoopNetSource);
        }
        public void StopListening()
        {
            bRunning = false;
            if (dataSourceThread == null)
                return;
            DisableSourceLoop();
            Console.WriteLine("Waiting for thread to finish its task..."); // The DLL provided has no way to gracefully "exit" the worker function while it is being executed,
                                                                           // This is why I have command fexit to immediately exit the application if need be.
            dataSourceThread.Join();
            dataSource.OnNewDataReady -= HandleNewDataReady;
            dataSource.OnContactInfoUpdate -= HandleContactInfoUpdate;
            dataSource.OnPositionUpdate -= HandlePositionUpdate;
            dataSource.OnIDUpdate -= HandleIDUpdate;
            UnsubFromContactUpdater(this);
            UnsubFromPosUpdater(this);
            UnsubFromUpdater(this);
        }
        public void ForceQuit()
        {
            bRunning = false;
            dataSource.OnNewDataReady -= HandleNewDataReady;
            if (dataSourceThread == null)
                return;
            Console.WriteLine("DEBUG: fexit procedure detected an active thread, exiting immediately anyways...");
            dataSourceThread.Interrupt();
            return;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"IsRunning: {bRunning}".PadLeft(1));
            return sb.ToString();
        }

        public void UpdateID(ulong ID, ulong NewObjectID)
        {
            ConsoleUI.FTRObjectsMutex.WaitOne();
            FTRObject? objToUpdate = ConsoleUI.currentFTRObjects!.FirstOrDefault(obj => obj.ID == ID);
            if (objToUpdate == null)
            {
                Console.WriteLine($"NetworkSourceProcessor@UpdateID: Object to update was null");
                Log($"ERROR: Object with ID [{ID}] does not exist, can't update ID");
            }
            else
            {
                Log($"Object with ID [{objToUpdate.ID}] changed ID from [{objToUpdate.ID}] to [{NewObjectID}]");
                objToUpdate.ID = NewObjectID;
            }
            ConsoleUI.FTRObjectsMutex.ReleaseMutex();
        }

        public void UpdatePosition(ulong ID, FTRObjects.Location location)
        {
            ConsoleUI.FTRObjectsMutex.WaitOne();
            FTRObject? objToUpdate = ConsoleUI.currentFTRObjects!.FirstOrDefault(obj => obj.ID == ID);
            if (objToUpdate == null)
            {
                Console.WriteLine($"NetworkSourceProcessor@UpdatePosition: Object to update was null");
                Log($"ERROR: Object with ID [{ID}] does not exist, can't update position");
            }
            else if (objToUpdate is Flight)
            {
                Flight flight = (Flight)objToUpdate;
                Log($"Object with ID [{flight.ID}] changed location from [{flight.Location}] to [{location}]");
                flight.Location = location;
            }
            else if (objToUpdate is Airport)
            {
                Airport airport = (Airport)objToUpdate;
                Log($"Object with ID [{airport.ID}] changed location from [{airport.Location}] to [{location}]");
                airport.Location = location;
            }
            else
            {
                Log($"ERROR: Object with ID [{ID}] is of wrong type, can't update position");
            }
            ConsoleUI.FTRObjectsMutex.ReleaseMutex();
        }

        public void UpdateContactInfo(ulong ID, string phoneNumber, string emailAddress)
        {
            ConsoleUI.FTRObjectsMutex.WaitOne();
            FTRObject? objToUpdate = ConsoleUI.currentFTRObjects!.FirstOrDefault(obj => obj.ID == ID);
            if (objToUpdate == null)
            {
                Console.WriteLine($"NetworkSourceProcessor@UpdateContactInfo: Object to update was null");
                Log($"ERROR: Object with ID [{ID}] does not exist, can't update contact info");
            }
            else if (objToUpdate is Person)
            {
                Person person = (Person)objToUpdate;
                Log($"Object with ID [{person.ID}] changed phone number and email from [{person.Phone}, {person.Email}] to [{phoneNumber}, {emailAddress}]");
                person.Phone = phoneNumber;
                person.Email = emailAddress;
            }
            else
            {
                Log($"ERROR: Object with ID [{ID}] is of wrong type, can't update contact info");
            }
            ConsoleUI.FTRObjectsMutex.ReleaseMutex();
        }
    }
}
