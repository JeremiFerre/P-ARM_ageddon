using P_ARM_AssemblyParser.Instructions;
using System;
using System.Text.RegularExpressions;

namespace P_ARM_AssemblyParser.Parameters
{
    public class ImmediateOperand : IOperand
    {
        private int length;
        private bool optional;
        private bool hasToBeParsed;

        public ImmediateOperand(int length, bool optional, bool hasToBeParsed)
        {
            this.length = length;
            this.optional = optional;
            this.hasToBeParsed = hasToBeParsed;
        }

        public short GetDefaultValue()
        {
            return 0;
        }

        public int GetMaxLength()
        {
            return length;
        }

        public string GetPattern()
        {
            return @"#\d+";
        }

        public bool HasToBeParsed()
        {
            return hasToBeParsed;
        }

        public bool IsOptional()
        {
            return optional;
        }

        public short Parse(string text)
        {
            return Convert.ToInt16(Regex.Match(text, GetPattern(), InstructionParser.Options).Value.Split('#')[1]);
        }
    }
}
