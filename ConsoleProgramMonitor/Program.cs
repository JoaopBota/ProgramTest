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
                int maxLifetime;
                int monitoringFrequency;

                if (!int.TryParse(args[1], out maxLifetime))
                {
                    Console.WriteLine("Error: Second argument must be an integer!");
                    return;
                }

                if (!int.TryParse(args[2], out monitoringFrequency))
                {
                    Console.WriteLine("Error: Third argument must be an integer!");
                    return;
                }

                Process[] processes = Process.GetProcessesByName(processName);

                if (processes.Length > 0)
                {
                    Console.WriteLine($"Info: Process '{processName}' is running.");

                    Console.WriteLine($"Info: Program.exe  is currently monitoring '{processName}' with a max lifetime of : [ '{maxLifetime}' minute(s) ] and with a monitoring frequency of : [ '{monitoringFrequency}' minute(s) ]");

                    Console.Write("\n\nPress the key 'Q' to quit");

                    Console.CancelKeyPress += new ConsoleCancelEventHandler(clickHandler);
                    while (!_s_stop)
                    {
                        

                        if (Console.KeyAvailable)
                        {
                            cki = Console.ReadKey(true);
                            Console.WriteLine($"\n\nInfo: Exitting...");
                            if (cki.Key == ConsoleKey.Q) break;
                        }

                         foreach (var process in processes)
                        {
                            TimeSpan processLifetime = DateTime.Now - process.StartTime;
                            Console.WriteLine($"\n\nProcess '{processName}' lifetime: {processLifetime.TotalMinutes} minutes");
                            if (processLifetime.TotalMinutes > maxLifetime)
                            {
                                Console.WriteLine($"\n\nProcess '{processName}' has exceeded the maximum lifetime. Killing process...");
                                process.Kill();
                                return;
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