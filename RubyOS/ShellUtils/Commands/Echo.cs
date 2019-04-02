using System;
using System.Collections.Generic;
using System.Text;

namespace RubyOS.ShellUtils.Commands
{
    class Echo
    {
        public static void Run(string parameters)
        {
            Console.WriteLine(parameters);
        }
    }
}
