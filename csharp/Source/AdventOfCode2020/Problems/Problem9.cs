namespace AdventOfCode2020.Problems
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2020.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/9">Day 9</a>.
    /// </summary>
    public class Problem9 : ProblemBase
    {
        public Problem9() : base(9) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            return FindFirstInvalidNumber(Input.ConvertToLong().ToList(), 25);
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
	        var target = FindFirstInvalidNumber(Input.ConvertToLong().ToList(), 25);
            return FindContiguousRangeMinMaxSum(Input.ConvertToLong().ToList(), target);
        }

        internal static long FindFirstInvalidNumber(IList<long> input, int preambleSize)
        {
            var currentStart = 0;

            while (currentStart + preambleSize < input.Count)
            {
                var target = input[currentStart + preambleSize];

                if (!RangeContainsTwoNumbersThatSumTo(input.Skip(currentStart).Take(preambleSize).ToList(), target))
                {
                    return target;
                }

                currentStart++;
            }

            return int.MinValue;
        }

        internal static long FindContiguousRangeMinMaxSum(IList<long> input, long target)
        {
            var currentStart = 0;
            var length = 1;

            while (currentStart + length < input.Count)
            {
                var range = input.Skip(currentStart).Take(length);
                var rangeSum = range.Sum();

                if (rangeSum == target)
                {
                    return range.Min() + range.Max();
                }
                
                if (rangeSum < target)
                {
                    length++;
                }
                else if (rangeSum > target)
                {
                    currentStart++;
                    length--;
                }
            }

            return int.MinValue;
        }

        private static bool RangeContainsTwoNumbersThatSumTo(IList<long> range, long target)
        {
            for (var i = 0; i < range.Count; i++)
            {
                for (var j = 0; j < range.Count; j++)
                {
                    if (range[i] == range[j])
                    {
                        continue;
                    }

                    if (range[i] + range[j] == target)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
