using System;
using System.Collections.Generic;
using System.Text;
using RubyOS.System.Security;
namespace RubyOS.ShellUtils.Commands
{
    class Logout
    {
        public static void Run()
        {
            Login.Run();
            Kernel.currentDirectory = @"0:\";
            Kernel.currentUser = "";
        }
    }
}
