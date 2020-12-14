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
            return FindPartOne(Input.WithoutEmptyLines());
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            // 482290840416548 is too high
            return FindPartTwo(Input.WithoutEmptyLines());
        }

        internal static long FindPartOne(IEnumerable<string> input)
        {
            var bitmask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

            var registers = new Dictionary<int, long>();

            foreach (var line in input)
            {
                var matches = Regex.Match(line, @"^((?<mask>mask)|(mem\[(?<mem>\d+)\])) = (?<content>.+)$", RegexOptions.ExplicitCapture);

                if (matches.Groups["mask"].Success)
                {
                    bitmask = matches.Groups["content"].Value;
                }
                else if (matches.Groups["mem"].Success)
                {
                    var register = matches.Groups["mem"].Value.ToInt();
                    var val = ApplyBitmask(matches.Groups["content"].Value.ToInt(), bitmask);

                    // Write value with bitmask
                    if (!registers.ContainsKey(register))
                    {
                        registers.Add(register, val);
                    }
                    else
                    {
                        registers[register] = val;
                    }
                }
                else
                {
                    throw new Exception("ohno");
                }
            }

            return registers.Sum(k => k.Value);
        }

        internal static long FindPartTwo(IEnumerable<string> input)
        {
            var bitmask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

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
                    var bitmasks = GetBitmaskPermutations(bitmask);
                    var targetRegister = matches.Groups["mem"].Value.ToInt();
                    var val = ApplyBitmask(matches.Groups["content"].Value.ToInt(), bitmask);

                    foreach (var mask in bitmasks)
                    {
                        var actualTarget = ApplyBitmask(targetRegister, mask);

                        if (!registers.ContainsKey(actualTarget))
                        {
                            registers.Add(actualTarget, val);
                        }
                        else
                        {
                            registers[actualTarget] = val;
                        }
                    }
                }
                else
                {
                    throw new Exception("ohno");
                }
            }

            return registers.Sum(k => k.Value);
        }

        private static long ApplyBitmask(long value, string bitmask)
        {
            var valueAsBinary = Convert.ToString(value, 2).PadLeft(36, '0').ToArray();
            var bitmaskArray = bitmask.ToArray();

            for (var i = 0; i < bitmask.Length; i++)
            {
                if (bitmaskArray[i].Equals('0'))
                {
                    valueAsBinary[i] = bitmaskArray[i];
                }
                else if (bitmaskArray[i].Equals('1'))
                {
                    valueAsBinary[i] = bitmaskArray[i];
                }
            }

            return Convert.ToInt64(string.Join(null, valueAsBinary), 2);
        }

        private static IEnumerable<string> GetBitmaskPermutations(string bitmask)
        {
            if (!bitmask.Any(c => c.Equals('X')))
            {
                return new[] {bitmask};
            }

            var bitmaskArray = bitmask.ToCharArray();
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
