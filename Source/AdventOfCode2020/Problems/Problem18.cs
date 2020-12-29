namespace AdventOfCode2020.Problems
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2020.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/18">Day 18</a>.
    /// </summary>
    public class Problem18 : ProblemBase
    {
        public Problem18() : base(18) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            return Input.WithoutEmptyLines().Sum(EvaluateExpression);
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            return "Unsolved";
        }

        internal static int EvaluateExpression(string expression)
        {
            return 0;
        }
    }
}
