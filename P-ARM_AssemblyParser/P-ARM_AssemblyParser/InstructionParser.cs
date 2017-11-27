using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P_ARM_AssemblyParser
{
    public class InstructionParser
    {
        private string instruction;

        public InstructionParser(string instruction)
        {
            this.instruction = instruction;
        }

        public Int16 ParseInstruction()
        {
            Regex.IsMatch(instruction, "");

            return 0x0;
        }
    }
}
