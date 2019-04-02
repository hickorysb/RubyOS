using System;
using System.Collections.Generic;
using System.Text;

namespace RubyOS.System.Security
{
    class Login
    {
        public static void Run()
        {
            Console.Clear();
            bool correctPass = false;
            bool firstAttempt = true;
            string username = "";
            string[] passwd = FileSys.ReadLines(@"0:\etc\passwd");
            while (!correctPass)
            {
                if (!firstAttempt)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The username and/or password you provided was invalid.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                string password = "";
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        password += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                        {
                            password = password.Substring(0, (password.Length - 1));
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            Console.Write(" ");
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                } while (true);

                foreach(string s in passwd)
                {
                    if(username.Trim() == s.Split(":")[0] && Sha256.hash(password) == s.Split(":")[1])
                    {
                        correctPass = true;
                    }
                }

                if(!correctPass)
                {
                    firstAttempt = false;
                }
            }
            Kernel.currentUser = username;
            Kernel.currentDirectory = @"0:\home\" + username + @"\";
            Console.Clear();
            Console.WriteLine("RubyOS Beta v0.0.1a");
            Console.WriteLine("Developed By: Jackson Abney");
            Console.WriteLine("Made Using: COSMOS, https://github.com/cosmosos/cosmos");
            Console.WriteLine("Welcome back " + Kernel.currentUser + ".");
            Shell.Run();
        }
    }
}
