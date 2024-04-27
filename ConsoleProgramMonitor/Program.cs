using System;
using System.Diagnostics;

namespace GetProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 3)
            {
                string processName = args[0];
                int maxLifetime = int.Parse(args[1]);
                int monitoringFrequency = int.Parse(args[2]);

                Process[] processes = Process.GetProcessesByName(processName);

                if (processes.Length > 0)
                {
                    Console.WriteLine($"Info: Process '{processName}' is running.");

                    Console.WriteLine($"Info: Program.exe  is currently monitoring '{processName}' with a max lifetime of : [ '{processName}' minute(s) ] and with a monitoring frequency of : [ '{processName}' minute(s) ]");
                    while (true)
                    {
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
    }
}