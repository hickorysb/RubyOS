using System;
using System.Collections.Generic;
using System.Text;
using RubyOS.ShellUtils.Commands;

namespace RubyOS.System
{
    class Shell
    {
        public static void Run()
        {
            string[] commandHistory = { "", "", "", "", "", "", "", "", "", "" };
            while (true)
            {
                if (Kernel.currentDirectory.StartsWith(@"0:\home\" + Kernel.currentUser))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("~" + Kernel.currentDirectory.Replace(@"0:\home\" + Kernel.currentUser, "") + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(Kernel.currentDirectory);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                string command = "";
                int currentHistoricalPosition = 10;
                string tempCommand = "";
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.DownArrow)
                    {
                        command += key.KeyChar;
                        Console.Write(key.KeyChar);
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && command.Length > 0)
                        {
                            command = command.Substring(0, (command.Length - 1));
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            Console.Write(" ");
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("");
                            break;
                        }
                        else if (key.Key == ConsoleKey.UpArrow)
                        {
                            if (currentHistoricalPosition == 10)
                            {
                                tempCommand = command;
                            }
                            if (currentHistoricalPosition > 0)
                            {
                                currentHistoricalPosition--;
                                for (int i = 0; i < command.Length; i++)
                                {
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                }
                                command = commandHistory[currentHistoricalPosition];
                                Console.Write(commandHistory[currentHistoricalPosition]);
                            }
                        }
                        else if (key.Key == ConsoleKey.DownArrow)
                        {
                            if (currentHistoricalPosition < 9)
                            {
                                currentHistoricalPosition++;
                                for (int i = 0; i < command.Length; i++)
                                {
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                }
                                command = commandHistory[currentHistoricalPosition];
                                Console.Write(commandHistory[currentHistoricalPosition]);
                            }
                            else if (currentHistoricalPosition == 9)
                            {
                                currentHistoricalPosition++;
                                for (int i = 0; i < command.Length; i++)
                                {
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                }
                                command = tempCommand;
                                Console.Write(tempCommand);
                            }
                        }
                    }
                } while (true);
                Array.Copy(commandHistory, 1, commandHistory, 0, commandHistory.Length - 1);
                command = command.Trim();
                commandHistory[9] = command;
                string commandOnly = command.Split()[0];
                commandOnly = commandOnly.ToLower();
                string[] parameters = command.Split();
                Array.Copy(parameters, 1, parameters, 0, parameters.Length - 1);
                if (commandOnly == "clear")
                {
                    Clear.Run();
                }
                else if (commandOnly == "echo")
                {
                    if (parameters[0] == "")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Command \"echo\" requires at least one argument.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Echo.Run(String.Join(" ", parameters));
                    }
                }
                else if (commandOnly == "shutdown")
                {
                    Shutdown.Run();
                }
                else if (commandOnly == "restart" || commandOnly == "reboot")
                {
                    Restart.Run();
                }
                else if (commandOnly == "format")
                {
                    Format.Run();
                }
                else if (commandOnly == "logout" || commandOnly == "exit")
                {
                    Logout.Run();
                }
                else if(commandOnly == "ls")
                {
                    ls.Run(parameters);
                }
                else if(commandOnly == "mkdir")
                {
                    mkdir.Run(parameters);
                }
                else if (commandOnly != "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command: " + command.Split()[0]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
