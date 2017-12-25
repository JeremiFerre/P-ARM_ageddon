using P_ARM_AssemblyParser.Parameters;
using System;
using System.Collections.Generic;

namespace P_ARM_AssemblyParser.Instructions
{
    /// <summary>
    /// Instruction enumeration class
    /// </summary>
    public static class Instructions
    {
        public static readonly Instruction LSL_imm = new Instruction("lsls", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 3),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new ImmediateOperand(5, false, true), 1)
        }, Convert.ToInt16("00000", 2));
        public static readonly Instruction LSR_imm = new Instruction("lsrs", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 3),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new ImmediateOperand(5, false, true), 1)
        }, Convert.ToInt16("00001", 2));
        public static readonly Instruction ASR_imm = new Instruction("asrs", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 3),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new ImmediateOperand(5, false, true), 1)
        }, Convert.ToInt16("00010", 2));
        public static readonly Instruction ADD_reg = new Instruction("adds", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 3),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0001100", 2));
        public static readonly Instruction SUB_reg = new Instruction("subs", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 3),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0001101", 2));
        public static readonly Instruction ADD_imm = new Instruction("adds", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 3),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new ImmediateOperand(3, false, true), 1)
        }, Convert.ToInt16("0001110", 2));
        public static readonly Instruction SUB_imm = new Instruction("subs", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 3),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new ImmediateOperand(3, false, true), 1)
        }, Convert.ToInt16("0001111", 2));
        public static readonly Instruction MOV_imm = new Instruction("movs", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1),
            new Tuple<IOperand, int>(new ImmediateOperand(8, false, true), 2)
        }, Convert.ToInt16("00100", 2));
        public static readonly Instruction AND_reg = new Instruction("ands", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0100000000", 2));
        public static readonly Instruction EOR_reg = new Instruction("eors", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0100000001", 2));
        public static readonly Instruction LSL_reg = new Instruction("lsls", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0100000010", 2));
        public static readonly Instruction LSR_reg = new Instruction("lsrs", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0100000011", 2));
        public static readonly Instruction ASR_reg = new Instruction("asrs", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0100000100", 2));
        public static readonly Instruction ADC_reg = new Instruction("adcs", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0100000101", 2));
        public static readonly Instruction SBC_reg = new Instruction("sbcs", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0100000110", 2));
        public static readonly Instruction ROR_reg = new Instruction("rors", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0100000111", 2));
        public static readonly Instruction TST_reg = new Instruction("tst", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0100001000", 2));
        public static readonly Instruction RSB_imm = new Instruction("rsbs", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1),
            new Tuple<IOperand, int>(new ImmediateOperand(0, false, false), 3)
        }, Convert.ToInt16("0100001001", 2));
        public static readonly Instruction CMP_reg = new Instruction("cmp", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0100001010", 2));
        public static readonly Instruction CMN_reg = new Instruction("cmn", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0100001011", 2));
        public static readonly Instruction ORR_reg = new Instruction("orrs", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0100001100", 2));
        public static readonly Instruction MUL_reg = new Instruction("muls", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1),
            new Tuple<IOperand, int>(new RegistryOperand(false, false), 3)
        }, Convert.ToInt16("0100001101", 2));
        public static readonly Instruction BIC_reg = new Instruction("bics", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0100001110", 2));
        public static readonly Instruction MVN_reg = new Instruction("mvns", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 2),
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1)
        }, Convert.ToInt16("0100001111", 2));
        public static readonly Instruction STR_imm = new Instruction("str", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1),
            new Tuple<IOperand, int>(new StackPointerOperand(true), 3),
            new Tuple<IOperand, int>(new ImmediateOperand(8, true, true), 2)
        }, Convert.ToInt16("10010", 2));
        public static readonly Instruction LDR_imm = new Instruction("ldr", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new RegistryOperand(false, true), 1),
            new Tuple<IOperand, int>(new StackPointerOperand(true), 3),
            new Tuple<IOperand, int>(new ImmediateOperand(8, true, true), 2)
        }, Convert.ToInt16("10011", 2));
        public static readonly Instruction ADD_sp = new Instruction("add", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new StackPointerOperand(true), 2),
            new Tuple<IOperand, int>(new StackPointerOperand(false), 3),
            new Tuple<IOperand, int>(new ImmediateOperand(7, false, true), 1)
        }, Convert.ToInt16("101100000", 2));
        public static readonly Instruction SUB_sp = new Instruction("sub", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new StackPointerOperand(true), 2),
            new Tuple<IOperand, int>(new StackPointerOperand(false), 3),
            new Tuple<IOperand, int>(new ImmediateOperand(7, false, true), 1)
        }, Convert.ToInt16("101100001", 2));
        public static readonly Instruction B = new Instruction("b", new List<Tuple<IOperand, int>> {
            new Tuple<IOperand, int>(new ConditionOperand(), 1),
            new Tuple<IOperand, int>(new LabelOperand(), 2)
        }, Convert.ToInt16("1101", 2));

        public static IEnumerable<Instruction> Values
        {
            get
            {
                yield return LSL_imm;
                yield return LSR_imm;
                yield return ASR_imm;
                yield return ADD_reg;
                yield return SUB_reg;
                yield return ADD_imm;
                yield return SUB_imm;
                yield return MOV_imm;
                yield return AND_reg;
                yield return EOR_reg;
                yield return LSL_reg;
                yield return LSR_reg;
                yield return ASR_reg;
                yield return ADC_reg;
                yield return SBC_reg;
                yield return ROR_reg;
                yield return TST_reg;
                yield return RSB_imm;
                yield return CMP_reg;
                yield return CMN_reg;
                yield return ORR_reg;
                yield return MUL_reg;
                yield return BIC_reg;
                yield return MVN_reg;
                yield return STR_imm;
                yield return LDR_imm;
                yield return ADD_sp;
                yield return SUB_sp;
                yield return B;
            }
        }
    }
}
