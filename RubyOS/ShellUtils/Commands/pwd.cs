using System;
using System.Collections.Generic;
using System.Text;

namespace RubyOS.ShellUtils.Commands
{
    class pwd
    {
        public static void Run()
        {
            Console.WriteLine(Kernel.currentDirectory);
        }
    }
}
