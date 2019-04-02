using System;
using System.Collections.Generic;
using System.Text;

namespace RubyOS.ShellUtils.Commands
{
    class Restart
    {
        public static void Run()
        {
            Cosmos.System.Power.Reboot();
        }
    }
}
