namespace AdventOfCode2020.Problems
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2020.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/15">Day 15</a>.
    /// </summary>
    public class Problem15 : ProblemBase
    {
        public Problem15() : base(15) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            return FindNthNumberSpoken(Input.WithoutEmptyLines().First().Split(',').ConvertToInt(), 2020);
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            return FindNthNumberSpoken(Input.WithoutEmptyLines().First().Split(',').ConvertToInt(), 30000000);
        }

        internal static int FindNthNumberSpoken(IEnumerable<int> input, int n)
        {
            var turnHistory = new Dictionary<int, int>();
            var turn = 0;

            // "Pre-load" input
            foreach (var i in input)
            {
                turn++;
                turnHistory[i] = turn;
            }

            var current = input.Last();
            var next = 0;

            // Step until we reach the nth step.
            while (turn < n)
            {
                turn++;
                current = next;

                if (!turnHistory.ContainsKey(current))
                {
                    // First time: Zero
                    next = 0;
                }
                else
                {
                    // Subsequent times: Turn difference from last time
                    next = turn - turnHistory[current];
                }

                turnHistory[current] = turn;
            }

            return current;
        }
    }
}
