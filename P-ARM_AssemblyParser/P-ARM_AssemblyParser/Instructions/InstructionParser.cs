using System;
using System.Text.RegularExpressions;

namespace P_ARM_AssemblyParser.Instructions
{
    public class InstructionParser
    {
        public static readonly RegexOptions Options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
        private string instruction;

        /// <summary>
        /// Normal constructor
        /// </summary>
        /// <param name="instruction">The line to parse</param>
        public InstructionParser(string instruction)
        {
            string cleanInstruction = instruction;
            if (Regex.IsMatch(instruction, @"\["))
                cleanInstruction = cleanInstruction.Replace("[", "");
            if (Regex.IsMatch(instruction, @"\]"))
                cleanInstruction = cleanInstruction.Replace("]", "");

            this.instruction = cleanInstruction;
        }

        /// <summary>
        /// Parse the line instruction to an hexadecimal integer
        /// </summary>
        /// <returns>The hexadecimal value of the instruction</returns>
        public Int16 ParseInstruction()
        {
            Int16 convertedInstruction = -1;

            foreach (Instruction instruction in Instructions.Values)
            {
                try
                {
                    convertedInstruction = instruction.Parse(this.instruction);
                    break;
                } catch (Exception) {}
            }

            if (convertedInstruction == -1) 
                throw new Exception("IntructionParser error: " + this.instruction);

            return convertedInstruction;
        }
    }
}
