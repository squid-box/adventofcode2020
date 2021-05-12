namespace AdventOfCode2020.Problems
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
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
            return Input.WithoutEmptyLines().Sum(expression => EvaluateExpression(expression, false));
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            return Input.WithoutEmptyLines().Sum(expression => EvaluateExpression(expression, true));
        }

        internal static long EvaluateExpression(string expression, bool advanced)
        {
            // Start by resolving parentheses:
            while (expression.Contains('('))
            {
                // Find inner-most parentheses
                var innermostStart = expression.LastIndexOf('(');
                var innermostLength = expression.IndexOf(')', innermostStart) - innermostStart;

                // Replace them with the evaluated value.
                var tempExpression = expression.Remove(innermostStart, innermostLength + 1);
                var parenthesesValue =
                    EvaluateExpression(expression.Substring(innermostStart + 1, innermostLength - 1), advanced);
                tempExpression = tempExpression.Insert(innermostStart, parenthesesValue.ToString());

                expression = tempExpression;
            }

            if (advanced && expression.Contains('+'))
            {
                // TODO: Advanced Math!
            }

            // Then evaluate the expression left-to-right.
            var parts = expression.Split(' ');

            var result = parts[0].ToLong();

            for (var i = 1; i <= parts.Length - 2; i += 2)
            {
                var operand = parts[i];
                var value = parts[i + 1].ToInt();

                switch (operand)
                {
                    case "+":
                        result += value;
                        break;
                    case "*":
                        result *= value;
                        break;
                }
            }

            return result;
        }
    }
}
