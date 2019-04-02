using System;
using System.Collections.Generic;
using System.Text;

namespace RubyOS.ShellUtils.Commands
{
    class cd
    {
        public static void Run(string[] par)
        {
            string directoryToChangeTo = String.Join(" ", par);
            if(directoryToChangeTo.StartsWith(".."))
            {

            }
        }
    }
}
