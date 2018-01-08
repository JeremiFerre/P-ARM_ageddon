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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wholeFile"></param>
        private static void InitializeData(List<string> wholeFile)
        {
            CurrentFileLabelsLines = new Dictionary<string, short>();
            Dictionary<string, int> constants = new Dictionary<string, int>();
            string pattern = new LabelOperand().GetPattern();
            string tabsOrSpaces = @"((\s*\t*\s*)|(\t*\s*\t*))";
            string dataPattern = "^" + tabsOrSpaces + @".data\s*";
            string endDataPattern = "^" + tabsOrSpaces + @".end\s*";
            string constantPattern = "^" + tabsOrSpaces + pattern + ":" + tabsOrSpaces + "+.word" + tabsOrSpaces + @"+0x[\d\w]+\s*";

            Match match;
            short numLine = 1;
            string line, newLine, currentDataLine, key, value;
            InstructionParser parser;
            for (int j, i = 0; i < wholeFile.Count; i++)
            {
                line = wholeFile[i];

                // Parser les variables du bloc .data / .end
                if (Regex.IsMatch(line, dataPattern, InstructionParser.Options))
                {
                    for (j = i + 1; j < wholeFile.Count && !Regex.IsMatch((currentDataLine = wholeFile[j]), endDataPattern, InstructionParser.Options); j++)
                    {
                        if ((match = Regex.Match(currentDataLine, constantPattern, InstructionParser.Options)).Success)
                        {
                            key = Regex.Match(match.Value, pattern + ":", InstructionParser.Options).Value.Split(':')[0];
                            value = Regex.Match(new Regex(key).Replace(match.Value, "", 1), @"0x[\d\w]+", InstructionParser.Options).Value;
                            constants.Add(key, Convert.ToInt32(value, 16));
                        }
                    }

                    i = j;
                    continue;
                }

                try
                {
                    // Parser un label
                    match = Regex.Match(line, "^" + tabsOrSpaces + pattern + ":", InstructionParser.Options);
                    if (match.Success)
                        CurrentFileLabelsLines.Add(Regex.Match(match.Value, pattern + ":", InstructionParser.Options).Value.Replace(":", "").ToUpper(), numLine);
                    else
                    {
                        // Changer les variables en leur valeur
                        foreach (string name in constants.Keys)
                        {
                            if ((Regex.IsMatch(line, @",((\s*)|(\t*))" + name + @"((\s*)|(\t*))", InstructionParser.Options)))
                            {
                                newLine = new Regex(@",((\s*)|(\t*))" + name + @"((\s*)|(\t*))").Replace(line, ", #" + constants[name] + " ", 1);
                                wholeFile[i] = newLine;
                                break;
                            }
                        }

                        line = wholeFile[i];
                        parser = new InstructionParser(line);
                        try
                        {
                            parser.ParseInstruction();
                            numLine++;
                        }
                        catch (Exception e)
                        {
                            if (e.GetType() != typeof(InstructionException))
                            {
                                numLine++;
                            }
                        }
                    }
                }
                catch (Exception) {}
            }
        }
    }
}
