using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RubyOS.System.Security;

namespace RubyOS.System
{
    class FileSystemInit
    {
        public static void Init()
        {
            if (File.Exists(@"0:\setupcomplete.sys"))
            {
                return;
            }
            else
            {
                try
                {
                    Console.Clear();
                    foreach (string s in FileSys.GetDirFadr(@"0:\"))
                    {
                        if (s != "Dir Testing" && s != "TEST")
                        {
                            Directory.Delete(@"0:\" + s, true);
                        }
                    }
                    bool passwordsMatch = false;
                    string username = "";
                    string password = "";
                    string passwordConfirm = "";
                    Console.WriteLine("Welcome to RubyOS.");
                    Console.Write("Username: ");
                    username = Console.ReadLine();
                    while (!passwordsMatch)
                    {
                        Console.Write("Please Pick a Password: ");
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
                                    Console.WriteLine();
                                    break;
                                }
                            }
                        } while (true);

                        Console.Write("Please Comfirm Your Password: ");
                        do
                        {
                            ConsoleKeyInfo key = Console.ReadKey(true);
                            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                            {
                                passwordConfirm += key.KeyChar;
                                Console.Write("*");
                            }
                            else
                            {
                                if (key.Key == ConsoleKey.Backspace && passwordConfirm.Length > 0)
                                {
                                    passwordConfirm = passwordConfirm.Substring(0, (passwordConfirm.Length - 1));
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                }
                                else if (key.Key == ConsoleKey.Enter)
                                {
                                    Console.WriteLine();
                                    break;
                                }
                            }
                        } while (true);
                        if (password == passwordConfirm) passwordsMatch = true;
                    }
                    string line = username.Trim() + ":" + Sha256.hash(password);
                    string[] data = { line };
                    Directory.CreateDirectory(@"0:\etc\");
                    File.WriteAllLines(@"0:\etc\passwd", data);
                    Directory.CreateDirectory(@"0:\home\" + username + @"\");
                    File.Create(@"0:\setupcomplete.sys");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
