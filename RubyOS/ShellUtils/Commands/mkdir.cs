using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RubyOS.ShellUtils.Commands
{
    class mkdir
    {
        public static void Run(string [] par)
        {
            string directoryName = String.Join(" ", par);
            if (!Directory.Exists(Kernel.currentDirectory + directoryName))
            {
                Directory.CreateDirectory(Kernel.currentDirectory + directoryName);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Directory already exists");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
