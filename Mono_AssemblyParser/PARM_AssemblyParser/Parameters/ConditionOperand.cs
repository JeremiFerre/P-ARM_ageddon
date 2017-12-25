using System;
using System.Text.RegularExpressions;

namespace P_ARM_AssemblyParser.Parameters
{
    public class ConditionOperand : IOperand
    {
        public short GetDefaultValue()
        {
            return (short)Conditions.AL;
        }

        public int GetMaxLength()
        {
            return 4;
        }

        public string GetPattern()
        {
            string pattern = "(";

            Conditions[] possibleConditions = (Conditions[]) Enum.GetValues(typeof(Conditions));
            foreach (var condition in possibleConditions)
            {
                pattern += condition.ToString() + (condition.Equals(possibleConditions[possibleConditions.Length - 1]) ? ")" : "|");
            }

            return pattern;
        }

        public bool HasToBeParsed()
        {
            return true;
        }

        public bool IsOptional()
        {
            return true;
        }

        public short Parse(string text)
        {
            short convertedValue = 0;

            Conditions[] possibleConditions = (Conditions[])Enum.GetValues(typeof(Conditions));
            foreach (var condition in possibleConditions)
            {
                if (Regex.Match(text, condition.ToString()).Success)
                {
                    convertedValue = (short) condition;
                    break;
                }
            }

            return convertedValue;
        }
    }
}
