using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD1.NetworkSourceSimulation;
using OOD1.FlightTrackerGUI;
using static OOD1.Serialization.Serialization;
using static OOD1.Util.Util;
using OOD1.FTRObjects;
using BruTile.Tms;
using OOD1.News;

namespace OOD1
{
    public static class ConsoleUI
    {
        private static bool bUserInterrupt = false;
        private static NetworkSourceProcessor? processor;
        private static GUI? gui;
        private static NewsGenerator? newsGenerator;
        private static string currentInputFile = "example.ftre";
        public static List<FTRObject>? currentFTRObjects;
        public static Mutex FTRObjectsMutex { get; private set; } = new Mutex();
        private static List<IReportable>? reportableObjects;
        private static int minOffsetMs = 1;
        private static int maxOffsetMs = 1;
        private static List<INewsProviders> newsProviders = new List<INewsProviders>
                        {
                            new Television("Abelian Television"),
                            new Television("Channel TV-Tensor"),
                            new Radio("Quantifier radio"),
                            new Radio("Shmem radio"),
                            new Newspaper("Categories Journal"),
                            new Newspaper("Polytechnical Gazette")
                        };
        private static void SetUserInterrupt()
        {
            bUserInterrupt = true;
        }
        public static void DisplayAvaiableCommands()
        {
            Console.WriteLine("Avaiable commands:\n");
            Console.WriteLine("start - start listening to messages");
            Console.WriteLine("stop - stops and terminates the message processor");
            Console.WriteLine("input filename - selects the specified file named filename in /Input as the input for the app");
            Console.WriteLine("print - take snapshot");
            Console.WriteLine("pexit - print just before exiting the app");
            Console.WriteLine("exit - exit the application");
            Console.WriteLine("help - display avaiable commands");
            Console.WriteLine("clear - clear the screen");
            Console.WriteLine("show - run and show the GUI");
            Console.WriteLine("hide - unloads and hides the GUI");
            Console.WriteLine("report [-all] - prints out a news overview");
            Console.WriteLine("status - prints the current status of the application components");
            Console.WriteLine("---DEBUG COMMANDS---");
            Console.WriteLine("fexit - abort the application immediately | [DBG]");
            Console.WriteLine("debug - toggle debug messages | [DBG]");
            Console.WriteLine("timehack time - overrides current time with the time specified | [DBG]");
            Console.WriteLine();
        }
        public static void ParseCommand(string? _command)
        {
            if (_command == null)
            {
                Console.WriteLine("The read command was null, try again or use 'help' to view all avaiable commands.");
                return;
            }
            string[] commandArgs = _command.Trim().Split(' ');
            switch (commandArgs[0].ToLower())
            {
                case "start":
                    {
                        if (processor == null)
                            CreateNetworkSource($"{_rootDir}/Input/{currentInputFile}", minOffsetMs, maxOffsetMs);
                        if (processor!.IsRunning())
                            Console.WriteLine("Data source was already started!");
                        else
                            processor.StartListening();
                        break;
                    }
                case "stop":
                    {
                        if (processor == null)
                        {
                            Console.WriteLine("No message processor detected");
                            break;
                        }
                        processor.StopListening();
                        processor = null;
                        break;
                    }
                case "input":
                    {
                        if (commandArgs.Length != 2)
                        {
                            Console.WriteLine($"Invalid file name, provide only the name of the file in /Input");
                            break;
                        }
                        currentInputFile = commandArgs[1];
                        if (!File.Exists($"{_rootDir}/Input/{currentInputFile}"))
                            Console.WriteLine($"WARNING: No file named {currentInputFile} found in /Input, the app might not work until you add it");
                        else if (commandArgs[1].Substring(Math.Max(0, currentInputFile.Length - 4)) != ".ftr" && commandArgs[1].Substring(Math.Max(0, currentInputFile.Length - 5)) != ".ftre")
                            Console.WriteLine($"WARNING: The file {currentInputFile} seems to not be a ftr/ftre file, but if it follows ftr/ftre specification it will still work");
                        else
                            Console.WriteLine("Input data successfully set");
                        break;
                    }
                case "print":
                    {
                        FTRObjectsMutex.WaitOne();
                        if (currentFTRObjects == null)
                        {
                            Console.WriteLine("No list with FTR Objects exists, create one using 'start'");
                            FTRObjectsMutex.ReleaseMutex();
                            break;
                        }
                        SerializeToJSON(currentFTRObjects, $"{_rootDir}/Output/snapshot_{DateTime.Now.ToString("HH_mm_ss")}.json");
                        FTRObjectsMutex.ReleaseMutex();
                        break;
                    }
                case "pexit":
                    {
                        ExitProcedure(true);
                        break;
                    }
                case "exit":
                    {
                        ExitProcedure();
                        break;
                    }
                case "help":
                    {
                        DisplayAvaiableCommands();
                        break;
                    }
                case "clear":
                    {
                        Console.Clear();
                        break;
                    }
                case "show":
                    {
                        if (gui != null)
                        {
                            Console.WriteLine("GUI is already running!");
                            break;
                        }
                        gui = new GUI();
                        gui.Start();
                        break;
                    }
                case "hide":
                    {
                        if (gui == null)
                        {
                            Console.WriteLine("Nothing to hide, GUI not running");
                            break;
                        }
                        gui.Quit();
                        gui = null;
                        break;
                    }
                case "report":
                    {
                        FTRObjectsMutex.WaitOne();
                        bool bReturn = commandArgs.Length < 2 ? false : commandArgs[1] == "-all";
                        bool bReset = commandArgs.Length < 2 ? false : commandArgs[1] == "-reset";
                        if (currentFTRObjects == null)
                        {
                            Console.WriteLine($"ConsoleUI@cmd-report: No FTR Objects list, initializing one with the set input file...");
                            currentFTRObjects = FTRObject.CreateObjectsFromFTRFile($"{_rootDir}/Input/{currentInputFile}");
                        }
                        if (reportableObjects == null)
                        {
                            reportableObjects = new List<IReportable>();
                            foreach (var item in currentFTRObjects)
                                if (item is IReportable)
                                    reportableObjects.Add((IReportable)item);
                        }
                        if (newsGenerator == null || bReset)
                            newsGenerator = new NewsGenerator(newsProviders, reportableObjects);
                        do
                        {
                            string? output = newsGenerator.GenerateNextNews();
                            if (output != null)
                                Console.WriteLine(output);
                            else
                                break;
                        } while (bReturn);
                        FTRObjectsMutex.ReleaseMutex();
                        break;
                    }
                case "status":
                    {
                        if (processor == null)
                            Console.WriteLine("No processor detected");
                        else
                            Console.WriteLine($"Status of the processor: {processor}");
                        if (gui == null)
                            Console.WriteLine("No GUI detected");
                        else
                            Console.WriteLine($"Status of the GUI: {gui}");
                        Console.WriteLine($"Current Input file: {currentInputFile}");
                        Console.WriteLine($"Current min and max message offset: {minOffsetMs} {maxOffsetMs}");
                        if (overridenTime.HasValue)
                            Console.WriteLine($"Overriden time is {overridenTime}");
                        else
                            Console.WriteLine($"Current time is {DateTime.UtcNow}");
                        FTRObjectsMutex.WaitOne();
                        if (currentFTRObjects == null)
                            Console.WriteLine($"No FTR Objects Loaded");
                        else
                            Console.WriteLine($"{currentFTRObjects.Count} FTR Objects loaded");
                        FTRObjectsMutex.ReleaseMutex();
                        break;
                    }
                case "fexit":
                    {
                        ExitProcedure(false, true);
                        break;
                    }
                case "debug":
                    {
                        if (bDEBUG)
                        {
                            bDEBUG = false;
                            Console.WriteLine("DEBUG: Disabled debug messages");
                        }
                        else
                        {
                            bDEBUG = true;
                            Console.WriteLine("DEBUG: Enabled debug messages");
                        }
                        break;
                    }
                case "timehack":
                    {
                        if (commandArgs.Length == 1)
                        {
                            overridenTime = null;
                            Console.WriteLine($"DEBUG: overridenTime is now null");
                            break;
                        }
                        try
                        {
                            overridenTime = DateTime.Parse(commandArgs[1]);
                        }
                        catch
                        {
                            Console.WriteLine($"DEBUG: The given time could not be parsed to DateTime ({commandArgs[1]})");
                            break;
                        }
                        Console.WriteLine($"DEBUG: The overridenTime is now equal to {overridenTime}");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("This command does not exist, write 'help' to view all avaiable commands.");
                        break;
                    }
            }
        }
        public static void StartListeningForCommands()
        {
            while (!bUserInterrupt)
            {
                string? readCommand;
                Console.Write("Enter command:");
                readCommand = Console.ReadLine();
                Console.WriteLine();
                Console.Clear();
                ParseCommand(readCommand);
            }
            Console.WriteLine("The loop was interrupted by an external function");
        }
        private static void CreateNetworkSource(string ftrFilePath, int minOffsetInMs, int maxOffsetInMs)
        {
            if (!File.Exists(ftrFilePath))
            {
                Console.WriteLine("The currently selected input file does not exist, change it using the 'input' command");
                return;
            }
            if (processor == null)
                processor = new NetworkSourceProcessor(ftrFilePath, minOffsetInMs, maxOffsetInMs);
        }
        public static void StartProcedure()
        {
            currentFTRObjects = FTRObject.CreateObjectsFromFTRFile($"{_rootDir}/Input/example_data.ftr");
            DisplayAvaiableCommands();
            StartListeningForCommands();
        }
        private static void ExitProcedure(bool bPrint = false, bool bForced = false)
        {
            if (bForced)
            {
                gui?.Quit(bForced);
                processor?.ForceQuit();
                System.Environment.Exit(0);
            }
            gui?.Quit();
            processor?.StopListening();
            FTRObjectsMutex.WaitOne();
            if (bPrint && currentFTRObjects != null)
                SerializeToJSON(currentFTRObjects!, $"{_rootDir}/Output/snapshot_{DateTime.Now.ToString("HH_mm_ss")}.json");
            FTRObjectsMutex.ReleaseMutex();
            System.Environment.Exit(0);
        }
    }
}
