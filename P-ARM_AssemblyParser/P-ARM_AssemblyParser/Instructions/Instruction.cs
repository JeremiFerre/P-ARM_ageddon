using P_ARM_AssemblyParser.Parameters;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P_ARM_AssemblyParser.Instructions
{
    /// <summary>
    /// Instruction class
    /// </summary>
    public class Instruction
    {
        public string Syntax { get; private set; }
        public List<Tuple<IOperand, int>> Operands { get; private set; }
        public Int16 HexaSyntax { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="syntax"></param>
        /// <param name="parameters"></param>
        internal Instruction(string syntax, List<Tuple<IOperand, int>> operands, Int16 hexaSyntax)
        {
            Syntax = syntax;
            Operands = operands;
            HexaSyntax = hexaSyntax;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private Match IsValid(string text)
        {
            string tabsOrSpaces = @"((\s*\t*\s*)|(\t*\s*\t*))";
            string betweenParameters = "(" + tabsOrSpaces + "," + tabsOrSpaces + ")";

            string operandsPattern = "";
            IOperand operand;
            for (int i = 0; i < Operands.Count; i++)
            {
                operand = Operands[i].Item1;
                if (operand.GetType() == typeof(ConditionOperand))
                    operandsPattern += operand.GetPattern() + "?" + tabsOrSpaces;
                else
                {
                    if (operand.IsOptional())
                        operandsPattern += "(" + operand.GetPattern() + (i == Operands.Count - 1 ? "" : betweenParameters) + ")?";
                    else
                        operandsPattern += operand.GetPattern() + (i == Operands.Count - 1 ? "" : betweenParameters);
                }
            }

            string pattern = "^" + tabsOrSpaces + Syntax + tabsOrSpaces + operandsPattern;

            Match match = Regex.Match(text, pattern, InstructionParser.Options);

            return match.Success ? match : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Int16 Parse(string text)
        {
            Match match;
            if ((match = IsValid(text)) == null)
                throw new Exception("Intruction cannot be parsed: " + text);

            // Séparation des éléments de la chaine
            Int16 hexaConverted;
            string regexedText = match.Value;
            hexaConverted = HexaSyntax;
            
            Regex toMatch;
            Match operandIsPresent;
            string matchedSyntax = Regex.Match(regexedText, Syntax, InstructionParser.Options).Value;
            toMatch = new Regex(matchedSyntax);
            string currentText = toMatch.Replace(regexedText, "");
            string currentOperand;
            Int16 parsedOperand;
            List<Tuple<int, Tuple<Int16, int>>> operandsConverted = new List<Tuple<int, Tuple<Int16, int>>>();

            // Parse each operand in the array
            foreach (Tuple<IOperand, int> op in Operands)
            {
                if (op.Item1.HasToBeParsed())
                {
                    operandIsPresent = Regex.Match(currentText, op.Item1.GetPattern(), InstructionParser.Options);

                    if (operandIsPresent.Success)
                    {
                        currentOperand = operandIsPresent.Value;
                        parsedOperand = op.Item1.Parse(currentOperand);
                        toMatch = new Regex(Regex.Match(currentText, currentOperand, InstructionParser.Options).Value);
                        currentText = toMatch.Replace(currentText, "", 1);
                    }
                    else
                    {
                        parsedOperand = op.Item1.GetDefaultValue();
                    }

                    operandsConverted.Add(new Tuple<int, Tuple<Int16, int>>(op.Item1.GetMaxLength(), new Tuple<short, int>(parsedOperand, op.Item2)));
                }
            }

            // Sort operands by their byte order
            operandsConverted.Sort(delegate (Tuple<int, Tuple<Int16, int>> t1, Tuple<int, Tuple<Int16, int>> t2)
            {
                return t1.Item2.Item2.CompareTo(t2.Item2.Item2);
            });

            // Add operands binary values to the final value
            foreach (Tuple<int, Tuple<Int16, int>> binOp in operandsConverted)
            {
                hexaConverted <<= binOp.Item1;
                hexaConverted |= binOp.Item2.Item1;
            }

            return hexaConverted;
        }
    }
}
