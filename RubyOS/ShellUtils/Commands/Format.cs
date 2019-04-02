using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RubyOS.ShellUtils.Commands
{
    class Format
    {
        public static void Run()
        {
            File.Delete(@"\setupcomplete.sys");
            Restart.Run();
        }
    }
}
