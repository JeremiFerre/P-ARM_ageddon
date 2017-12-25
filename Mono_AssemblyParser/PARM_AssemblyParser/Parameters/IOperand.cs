namespace P_ARM_AssemblyParser
{
    public interface IOperand
    {
        /// <summary>
        /// Get the max length of this parameter
        /// </summary>
        /// <returns>The max value of the parameter</returns>
        int GetMaxLength();

        /// <summary>
        /// Is this parameter optional in its container
        /// </summary>
        /// <returns>true if this parameter is optional, false otherwise</returns>
        bool IsOptional();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool HasToBeParsed();

        /// <summary>
        /// Get the converted value of the parameter's text
        /// </summary>
        /// <param name="text">The text to parse, it must match the parameter syntax</param>
        /// <returns>The hexadecimal value of the parameter's text</returns>
        string GetPattern();

        /// <summary>
        /// Parse a parameter
        /// </summary>
        /// <param name="text">The parameter text to parse</param>
        /// <param name="labelsLines">The association of the labels to the lines numbers</param>
        /// <returns>The hexadecimal value of the parsed text</returns>
        short Parse(string text);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        short GetDefaultValue();
    }
}