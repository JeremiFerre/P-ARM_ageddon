using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P_ARM_AssemblyParser.Instructions.Tests
{
    [TestClass()]
    public class InstructionParserTests
    {

        [TestMethod()]
        public void ParseInstructionTest()
        {
            /* Shift, add, sub, mov */

            // LSL immediate
            string lsl_imm = "\t   \tLSLS \t R2,  R7  ,#18    \t ";
            InstructionParser lsl_imm_parser = new InstructionParser(lsl_imm);
            Assert.AreEqual(0x04BA, lsl_imm_parser.ParseInstruction());
        }
    }
}