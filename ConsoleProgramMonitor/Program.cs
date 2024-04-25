using System;
using System.Diagnostics;

namespace GetProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] list = Process.GetProcessesByName("test");
        
            foreach (var process in list)
            {
                Console.Out.WriteLine(process.ProcessName);
            }
            Console.ReadLine();
        }
    }
}