using System;
using System.Collections.Generic;
using System.Text;

namespace RubyOS.ShellUtils.Commands
{
    class Shutdown
    {
        public static void Run()
        {
            Cosmos.System.Power.Shutdown();
        }
    }
}
