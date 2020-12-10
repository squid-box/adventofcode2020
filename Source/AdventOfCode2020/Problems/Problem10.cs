namespace AdventOfCode2020.Problems
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2020.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/10">Day 10</a>.
    /// </summary>
    public class Problem10 : ProblemBase
    {
        public Problem10() : base(10) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            return FindPartOne(Input.WithoutEmptyLines().ConvertToInt());
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            return FindPartTwo(Input.WithoutEmptyLines().ConvertToInt());
        }

        internal static int FindPartOne(IEnumerable<int> input)
        {
            var joltDifferences = new Dictionary<int, int>();

            // Outlet has rating 0 jolts.
            var previousAdapter = 0;

            foreach (var adapter in input.OrderBy(i => i))
            {
                var diff = adapter - previousAdapter;

                joltDifferences.TryAdd(diff, 0);
                joltDifferences[diff] = joltDifferences[diff] + 1;

                previousAdapter = adapter;
            }

            // My device has a jolt rating of 3 jolts higher than the highest adapter.
            var lastDiff = input.Max()+3 - previousAdapter;
            joltDifferences.TryAdd(lastDiff, 0);
            joltDifferences[lastDiff] = joltDifferences[lastDiff] + 1;

            return joltDifferences[1] * joltDifferences[3];
        }

        internal static int FindPartTwo(IEnumerable<int> input)
        {
            var valid = 0;

            

            return valid;
        }
    }
}
