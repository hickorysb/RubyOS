using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RubyOS.System
{
    class FileSys
    {
        public static string[] GetFsFadr(string Adr) // Get Files From Address
        {
            string[] Files = new string[256];
            if (Directory.GetFiles(Adr).Length > 0)
                Files = Directory.GetFiles(Adr);
            else
                Files[0] = "No files found.";
            return Files;
        }
        public static string[] GetDirFadr(string Adr) // Get Directories From Address
        {
            var Dirs = Directory.GetDirectories(Adr);
            return Dirs;
        }
        public static string[] ReadLines(string FileAdr) //Returns the lines of text in string[].
        {
            string[] FileRead;
            FileRead = File.ReadAllLines(FileAdr);
            return FileRead;
        }

        public static string ReadText(string FileAddr) //Returns the file in a single string.
        {
            string f_contents = "";
            f_contents = File.ReadAllText(FileAddr);
            return f_contents;
        }

        public static byte[] ReadByte(string FileAdr) //Returns the read file in bytes.
        {
            byte[] FileRead;
            FileRead = File.ReadAllBytes(FileAdr);
            return FileRead;
        }
    }
}
