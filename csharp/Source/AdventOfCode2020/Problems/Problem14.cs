namespace AdventOfCode2020.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using AdventOfCode2020.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/14">Day 14</a>.
    /// </summary>
    public class Problem14 : ProblemBase
    {
        public Problem14() : base(14) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            return FindAnswer(Input.WithoutEmptyLines(), true);
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            return FindAnswer(Input.WithoutEmptyLines(), false);
        }

        internal static long FindAnswer(IEnumerable<string> input, bool isPartOne)
        {
            var bitmask = string.Empty;
            var registers = new Dictionary<long, long>();

            foreach (var line in input)
            {
                var matches = Regex.Match(line, @"^((?<mask>mask)|(mem\[(?<mem>\d+)\])) = (?<content>.+)$", RegexOptions.ExplicitCapture);

                if (matches.Groups["mask"].Success)
                {
                    bitmask = matches.Groups["content"].Value;
                }
                else if (matches.Groups["mem"].Success)
                {
                    var value = matches.Groups["content"].Value.ToInt();
                    var register = matches.Groups["mem"].Value.ToInt();

                    if (isPartOne)
                    {
                        registers[register] = Convert.ToInt64(ApplyBitmask(value, bitmask, true), 2);
                    }
                    else
                    {
                        var targetBitmask = ApplyBitmask(register, bitmask, false);
                        var targetRegisters = GetBitmaskPermutations(targetBitmask);

                        foreach (var targetRegister in targetRegisters)
                        {
                            registers[Convert.ToInt64(targetRegister, 2)] = value;
                        }
                    }
                }
            }

            return registers.Sum(k => k.Value);
        }

        private static string ApplyBitmask(long value, string bitmask, bool isPartOne)
        {
            var valueAsBinary = Convert.ToString(value, 2).PadLeft(36, '0').ToArray();
            var bitmaskArray = bitmask.ToArray();

            var targetChar = isPartOne ? 'X' : '0';

            for (var i = 0; i < bitmask.Length; i++)
            {
                if (!bitmaskArray[i].Equals(targetChar))
                {
                    valueAsBinary[i] = bitmaskArray[i];
                }
            }

            return string.Join(null, valueAsBinary);
        }

        private static IEnumerable<string> GetBitmaskPermutations(string bitmask)
        {
            if (!bitmask.Any(c => c.Equals('X')))
            {
                return new[] { bitmask };
            }

            var firstX = bitmask.IndexOf('X');

            var one = bitmask.ToCharArray();
            var zero = bitmask.ToCharArray();

            one[firstX] = '1';
            zero[firstX] = '0';

            return GetBitmaskPermutations(string.Join(null, one))
                .Concat(GetBitmaskPermutations(string.Join(null, zero)));
        }
    }
}
