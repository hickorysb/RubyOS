using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Security = RubyOS.System.Security;
using RubySys = RubyOS.System;
using System.IO;

namespace RubyOS
{
    public class Kernel : Sys.Kernel
    {
        public static string currentUser;
        public static Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        public static string systemName;
        public static string currentDirectory;

        protected override void BeforeRun()
        {
            Console.Clear();
            //Console.Beep();
        }

        protected override void Run()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            fs.Initialize();
            RubySys.FileSystemInit.Init();
            Security.Login.Run();
        }
    }
}
