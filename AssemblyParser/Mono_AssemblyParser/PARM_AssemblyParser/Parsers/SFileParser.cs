using P_ARM_AssemblyParser.Instructions;
using P_ARM_AssemblyParser.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P_ARM_AssemblyParser.Parsers
{
    public static class SFileParser
    {
        public static Dictionary<string, short> CurrentFileLabelsLines { get; private set; }

        public static string ParseFile(string filePath)
        {
            List<string> allLines = System.IO.File.ReadAllLines(filePath).ToList();
            InitializeData(allLines);

            InstructionParser parser;
            short convertedIntruction;
            string convertedFile = "", line;

            for (int i = 0; i < allLines.Count; i++)
            {
                line = allLines[i];

                try
                {
                    parser = new InstructionParser(line);
                    convertedIntruction = parser.ParseInstruction();
                    convertedFile += convertedIntruction.ToString("X2") + (i == allLines.Count - 1 ? "" : " ");
                }
                catch (Exception) {}
            }

            return convertedFile.ToLower();
        }

        private static void InitializeData(List<string> wholeFile)
        {
            Dictionary<string, short> labelsLines = new Dictionary<string, short>();
            Dictionary<string, int> constants = new Dictionary<string, int>();
            string pattern = new LabelOperand().GetPattern();
            string tabsOrSpaces = @"((\s*\t*\s*)|(\t*\s*\t*))";
            string dataPattern = "^" + tabsOrSpaces + @".data\s+";
            string endDataPattern = "^" + tabsOrSpaces + @".end\s+";
            string constantPattern = "^" + tabsOrSpaces + new LabelOperand().GetPattern() + @":\s+";

            Match match;
            short numLine = 1;
            string line, currentDataLine;
            InstructionParser parser;
            for (int j, i = 0; i < wholeFile.Count; i++)
            {
                line = wholeFile[i];
                if (Regex.IsMatch(line, dataPattern, InstructionParser.Options))
                {
                    for (j = i + 1; j < wholeFile.Count && !Regex.IsMatch((currentDataLine = wholeFile[j]), endDataPattern, InstructionParser.Options); j++)
                    {

                    }

                    i = j;
                    continue;
                }

                try
                {
                    match = Regex.Match(line, "^" + tabsOrSpaces + pattern + ":", InstructionParser.Options);
                    if (match.Success)
                        labelsLines.Add(Regex.Match(match.Value, pattern + ":").Value.Replace(":", "").ToUpper(), numLine);
                    else
                    {
                        parser = new InstructionParser(line);
                        try
                        {
                            parser.ParseInstruction();
                            numLine++;
                        }
                        catch (InstructionException) {}
                    }
                }
                catch (Exception) {}
            }

            // Initialisation des attributs
            CurrentFileLabelsLines = labelsLines;
        }
    }
}
