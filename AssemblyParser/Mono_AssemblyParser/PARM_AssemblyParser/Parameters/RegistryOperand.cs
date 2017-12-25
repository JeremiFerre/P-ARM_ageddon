using P_ARM_AssemblyParser.Instructions;
using System;
using System.Text.RegularExpressions;

namespace P_ARM_AssemblyParser.Parameters
{
    public class RegistryOperand : IOperand
    {
        private bool optional;
        private bool hasToBeParsed;

        public RegistryOperand(bool optional, bool hasToBeParsed)
        {
            this.optional = optional;
            this.hasToBeParsed = hasToBeParsed;
        }

        public short GetDefaultValue()
        {
            return 0;
        }

        public int GetMaxLength()
        {
            return 3;
        }

        public string GetPattern()
        {
            return @"R\d";
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
            return Convert.ToInt16(Regex.Match(text, GetPattern(), InstructionParser.Options).Value.Split('R')[1]);
        }
    }
}
