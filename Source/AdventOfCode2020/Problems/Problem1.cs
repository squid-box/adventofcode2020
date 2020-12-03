namespace AdventOfCode2020.Problems
{
    using System.Globalization;
    using AdventOfCode2020.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/1">Day 1</a>.
    /// </summary>
    public class Problem1 : ProblemBase
    {
        public Problem1() : base(1) { }

        protected override string SolvePartOne()
        {
            return FindAnswerOne(Input.ConvertToInt(), 2020).ToString(CultureInfo.InvariantCulture);
        }

        protected override string SolvePartTwo()
        {
            return FindAnswerTwo(Input.ConvertToInt(), 2020).ToString(CultureInfo.InvariantCulture);
        }

        internal static int FindAnswerOne(int[] input, int targetSum)
        {
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < input.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (input[i] + input[j] == targetSum)
                    {
                        return input[i] * input[j];
                    }
                }
            }

            return int.MinValue;
        }

        internal static int FindAnswerTwo(int[] input, int targetSum)
        {
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < input.Length; j++)
                {
                    for (var k = 0; k < input.Length; k++)
                    {
                        if (i == j || i == k || j == k)
                        {
                            continue;
                        }

                        if (input[i] + input[j] + input[k] == targetSum)
                        {
                            return input[i] * input[j] * input[k];
                        }
                    }
                }
            }

            return int.MinValue;
        }
    }
}