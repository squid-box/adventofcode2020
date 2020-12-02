namespace AdventOfCode2020.Utils.Extensions
{
    using System;

    /// <summary>
    /// Extensions for integers.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string into an int.
        /// </summary>
        /// <param name="source">The string to convert.</param>
        /// <returns>The string as an integer.</returns>
        public static int ToInt(this string source)
        {
            return Convert.ToInt32(source);
        }
    }
}
