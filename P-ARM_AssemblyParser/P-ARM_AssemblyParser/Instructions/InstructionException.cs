using System;

namespace P_ARM_AssemblyParser.Instructions
{
    public class InstructionException : Exception
    {
        /// <summary>
        /// Normal constructor of an InstructionException
        /// </summary>
        /// <param name="message">The Exception message</param>
        public InstructionException(string message) : base(message) { }
    }
}
