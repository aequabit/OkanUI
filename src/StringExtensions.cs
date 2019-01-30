namespace OkanUI
{
    public static class StringExtensions
    {
        /// <summary>
        /// Abbreviates a string to <c>length</c> and appends <c>appendix</c>.
        /// </summary>
        /// <returns>The abbreviated string.</returns>
        /// <param name="str">String to abbreviate.</param>
        /// <param name="length">Length of the output string including <c>appendix</c>.</param>
        /// <param name="appendix">Appendix.</param>
        public static string Abbreviate(this string str, int length = 8, string appendix = "...")
        {
            // String does not need to be abbreviated.
            if (str.Length <= length)
            {
                return str;
            }

            // Abbreviate the string
            return str.Substring(0, length - appendix.Length) + appendix;
        }
    }
}