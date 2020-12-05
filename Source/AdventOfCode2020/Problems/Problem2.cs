namespace AdventOfCode2020.Problems
{
	using System.Collections.Generic;
	using System.Globalization;
    using System.Linq;
	using System.Text.RegularExpressions;
	using AdventOfCode2020.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/2">Day 2</a>.
    /// </summary>
    public class Problem2 : ProblemBase
    {
        public Problem2() : base(2) { }

        /// <inheritdoc />
        protected override string SolvePartOne()
        {
            return FindValidPasswords(Input.WithoutEmptyLines()).ToString(CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        protected override string SolvePartTwo()
        {
            return FindOtherValidPasswords(Input.WithoutEmptyLines()).ToString(CultureInfo.InvariantCulture);
        }

        internal static IEnumerable<PasswordPolicy> ParseInput(ICollection<string> input)
        {
	        return input.Select(data => new PasswordPolicy(data));
        }

        internal static int FindValidPasswords(ICollection<string> input)
        {
	        return ParseInput(input).Count(p => p.IsValid);
        }

        internal static int FindOtherValidPasswords(ICollection<string> input)
        {
	        return ParseInput(input).Count(p => p.IsValidTwo);
        }
    }

    internal class PasswordPolicy
    {
	    public PasswordPolicy(string input)
	    {
            var regexMatches = Regex.Matches(input, @"(\d+)-(\d+) (\w): (\w*)");

            LowerRange = regexMatches[0].Groups[1].Value.ToInt();
            UpperRange = regexMatches[0].Groups[2].Value.ToInt();
            TargetCharacter = regexMatches[0].Groups[3].Value[0];
            Password = regexMatches[0].Groups[4].Value;
        }

        public string Password { get; }

        public char TargetCharacter { get; }

        public int LowerRange { get; }

        public int UpperRange { get; }

        public bool IsValid => Password.Count(c => c.Equals(TargetCharacter)).IsWithin(LowerRange, UpperRange);

        public bool IsValidTwo
        {
	        get
	        {
		        var firstPosContainsTarget = Password[LowerRange-1].Equals(TargetCharacter);
		        var secondPosContainsTarget = Password[UpperRange-1].Equals(TargetCharacter);

		        return firstPosContainsTarget && !secondPosContainsTarget ||
		               secondPosContainsTarget && !firstPosContainsTarget;
	        }
        }
    }
}
