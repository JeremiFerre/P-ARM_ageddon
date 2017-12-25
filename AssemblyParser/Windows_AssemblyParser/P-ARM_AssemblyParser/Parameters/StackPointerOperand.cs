namespace P_ARM_AssemblyParser.Parameters
{
    public class StackPointerOperand : IOperand
    {
        private bool optional;

        public StackPointerOperand(bool optional)
        {
            this.optional = optional;
        }

        public short GetDefaultValue()
        {
            return 0;
        }

        public int GetMaxLength()
        {
            return 0;
        }

        public string GetPattern()
        {
            return @"SP";
        }

        public bool HasToBeParsed()
        {
            return false;
        }

        public bool IsOptional()
        {
            return optional;
        }

        public short Parse(string text)
        {
            return 0;
        }
    }
}
