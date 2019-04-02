using System;
using System.Collections.Generic;
using System.Text;

namespace RubyOS.ShellUtils.Commands
{
    class ls
    {
        public static void Run(string[] par)
        {
            bool showHidden = false;
            foreach (string p in par)
            {
                switch (p)
                {
                    case "-a":
                        showHidden = true;
                        break;
                }
            }
            foreach (string s in System.FileSys.GetDirFadr(Kernel.currentDirectory))
            {
                if (!s.StartsWith(".") || showHidden)
                {
                    Console.WriteLine(s);
                }
            }
            foreach (string s in System.FileSys.GetFsFadr(Kernel.currentDirectory))
            {
                if (!s.StartsWith(".") || showHidden)
                {
                    Console.WriteLine(s);
                }
            }
        }

    }
}
