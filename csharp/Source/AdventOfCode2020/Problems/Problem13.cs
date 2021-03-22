namespace AdventOfCode2020.Problems
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2020.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/13">Day 13</a>.
    /// </summary>
    public class Problem13 : ProblemBase
    {
        public Problem13() : base(13) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            return FindPartOne(Input.WithoutEmptyLines());
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            return "Unsolved";
        }

        internal static int FindPartOne(IEnumerable<string> input)
        {
            var startTime = input.First().ToInt();
            var (id, waitTime) = input
                .Last()
                .Split(',')
                .Where(i => !i.Equals("x"))
                .Select(i => i.ToInt())
                .Select(i => (Id: i, WaitTime: i - startTime % i))
                .OrderBy(bus => bus.WaitTime)
                .First();

            return id * waitTime;
        }

        internal static long FindPartTwo(string input)
        {
            return 0;
        }
    }
}
