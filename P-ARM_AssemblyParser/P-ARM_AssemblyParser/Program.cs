using P_ARM_AssemblyParser.Parsers;
using System;
using System.IO;

namespace P_ARM_AssemblyParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1) throw new Exception("Argument error: syntax <file_path>");
            if (!File.Exists(args[0])) throw new Exception("Argument error: file doesn't exists");

            // Read and parse file
            string parsedFile = SFileParser.ParseFile(args[0]);

            // Write into the new logisim file
            string logisimHeader = "v2.0 raw";
            
            File.WriteAllLines(Path.GetDirectoryName(Path.GetFullPath(args[0])) + @"\" + Path.GetFileNameWithoutExtension(args[0]) + "_logisim.txt", new string[] { logisimHeader, parsedFile });
            
            Console.WriteLine("\n" + (parsedFile.Length > 0 ? parsedFile.Split(' ').Length : 0) + " instructions were correctly parsed.\n");
        }
    }
}
