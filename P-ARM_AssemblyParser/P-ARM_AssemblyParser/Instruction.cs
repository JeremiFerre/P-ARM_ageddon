using P_ARM_AssemblyParser.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_ARM_AssemblyParser
{
    public static class Instructions
    {
        public static readonly Instruction LSL = new Instruction("lsl", new List<IParameter> { });
        public static readonly Instruction LSR = new Instruction("lsr", new List<IParameter> { });
        public static readonly Instruction ASR = new Instruction("asr", new List<IParameter> { });
        public static readonly Instruction ADD = new Instruction("add", new List<IParameter> { });
        public static readonly Instruction SUB = new Instruction("sub", new List<IParameter> { });
        public static readonly Instruction MOV = new Instruction("mov", new List<IParameter> { });
        public static readonly Instruction AND = new Instruction("and", new List<IParameter> { });
        public static readonly Instruction EOR = new Instruction("eor", new List<IParameter> { });
        public static readonly Instruction ADC = new Instruction("adc", new List<IParameter> { });
        public static readonly Instruction SBC = new Instruction("sbc", new List<IParameter> { });
        public static readonly Instruction ROR = new Instruction("ror", new List<IParameter> { });
        public static readonly Instruction TST = new Instruction("tst", new List<IParameter> { });
        public static readonly Instruction RSB = new Instruction("rsb", new List<IParameter> { });
        public static readonly Instruction CMP = new Instruction("cmp", new List<IParameter> { });
        public static readonly Instruction CMN = new Instruction("cmn", new List<IParameter> { });
        public static readonly Instruction ORR = new Instruction("orr", new List<IParameter> { });
        public static readonly Instruction MUL = new Instruction("mul", new List<IParameter> { });
        public static readonly Instruction BIC = new Instruction("bic", new List<IParameter> { });
        public static readonly Instruction MVN = new Instruction("mvn", new List<IParameter> { });
        public static readonly Instruction STR = new Instruction("str", new List<IParameter> { });
        public static readonly Instruction LDR = new Instruction("ldr", new List<IParameter> { });
        public static readonly Instruction B   = new Instruction("b", new List<IParameter> { });

        public static IEnumerable<Instruction> Values
        {
            get
            {
                yield return LSL;
                yield return LSR;
                yield return ASR;
                yield return ADD;
                yield return SUB;
                yield return MOV;
                yield return AND;
                yield return EOR;
                yield return ADC;
                yield return SBC;
                yield return ROR;
                yield return TST;
                yield return RSB;
                yield return CMP;
                yield return CMN;
                yield return ORR;
                yield return MUL;
                yield return BIC;
                yield return MVN;
                yield return STR;
                yield return LDR;
                yield return B;
            }
        }
    }

    public class Instruction
    {
        public string Syntax { get; private set; }
        public List<IParameter> Parameters { get; private set; }

        internal Instruction(string syntax, List<IParameter> parameters)
        {
            Syntax = syntax;
            Parameters = parameters;
        }
    }
}
