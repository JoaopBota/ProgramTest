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
                string ProcessName = args[0];

                Process[] processes = Process.GetProcessesByName(ProcessName);

                if(processes.Length > 0){
                    Console.WriteLine("Process " + ProcessName + " is running.");

                }

                else{
                    Console.WriteLine("Error: The process " + ProcessName +" is not running!");
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