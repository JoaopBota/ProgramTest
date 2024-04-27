using System;
using System.Diagnostics;

namespace GetProcess
{
    class Program
    {
        private static volatile bool _s_stop = false;
        static void Main(string[] args)
        {

            ConsoleKeyInfo cki;

            Console.Clear();

            if (args.Length == 3)
            {
                string processName = args[0];
                int maxLifetime = int.Parse(args[1]);
                int monitoringFrequency = int.Parse(args[2]);

                Process[] processes = Process.GetProcessesByName(processName);

                if (processes.Length > 0)
                {
                    Console.WriteLine($"Info: Process '{processName}' is running.");

                    Console.WriteLine($"Info: Program.exe  is currently monitoring '{processName}' with a max lifetime of : [ '{maxLifetime}' minute(s) ] and with a monitoring frequency of : [ '{monitoringFrequency}' minute(s) ]");

                    Console.CancelKeyPress += new ConsoleCancelEventHandler(clickHandler);
                    while (!_s_stop)
                    {
                        Console.Write("\n\nPress the key 'Q' to quit");
                        // Start a console read operation. Do not display the input.
                        cki = Console.ReadKey(true);

                        // Announce the name of the key that was pressed .
                        Console.WriteLine($"\n\nInfo:  Exitting...");

                        // Exit if the user pressed the 'X' key.
                        if (cki.Key == ConsoleKey.Q) break;

                        foreach (var process in processes)
                        {
                            TimeSpan processLifetime = DateTime.Now - process.StartTime;
                            if (processLifetime.TotalMinutes > maxLifetime)
                            {
                                Console.WriteLine($"Process '{processName}' has exceeded the maximum lifetime. Killing process...");
                                process.Kill();
                            }
                        }

                        Thread.Sleep(monitoringFrequency * 60 * 1000); // Convert minutes to milliseconds
                    }
                }

                else
                {
                    Console.WriteLine($"Error: The process '{processName}' is not running!");
                    return;
                }
            }

            else if (args.Length != 3)
            {
                Console.WriteLine("Error: Three arguments are required!");
                return;
            }
        }

        protected static void clickHandler(object sender, ConsoleCancelEventArgs args)
        {
            args.Cancel = true;
            _s_stop = true;
        }
    }
}