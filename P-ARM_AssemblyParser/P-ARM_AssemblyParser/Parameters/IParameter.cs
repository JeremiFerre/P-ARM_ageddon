namespace P_ARM_AssemblyParser
{
    public interface IParameter
    {
        /// <summary>
        /// Get the max length of this parameter
        /// </summary>
        /// <returns>The max value of the parameter</returns>
        int GetMaxLength();

        /// <summary>
        /// Get the converted value of the parameter's text
        /// </summary>
        /// <param name="text">The text to parse, it must match the parameter syntax</param>
        /// <returns>The hexadecimal value of the parameter's text</returns>
        int Parse(string text);
    }
}