namespace AdventOfCode2020.Problems
{
    using System.Globalization;
    using System.Linq;
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

        internal static int FindValidPasswords(string[] input)
        {
            var valid = 0;

            foreach (var line in input)
            {
                var lineTemp = line.Split(" ");
                var rangeTemp = lineTemp[0].Split("-");
                var rangeLower = rangeTemp[0].ToInt();
                var rangeUpper = rangeTemp[1].ToInt();

                if (lineTemp[2].Count(c => c.Equals(lineTemp[1][0])).IsWithin(rangeLower, rangeUpper))
                {
                    valid++;
                }
            }

            return valid;
        }

        internal static int FindOtherValidPasswords(string[] input)
        {
            var valid = 0;

            foreach (var line in input)
            {
                var lineTemp = line.Split(" ");
                var positionsTemp = lineTemp[0].Split("-");
                var positionOne = positionsTemp[0].ToInt() - 1;
                var positionTwo = positionsTemp[1].ToInt() - 1;
                var target = lineTemp[1][0];

                var firstPosContainsTarget = lineTemp[2][positionOne].Equals(target);
                var secondPosContainsTarget = lineTemp[2][positionTwo].Equals(target);

                if (firstPosContainsTarget && !secondPosContainsTarget ||
                    secondPosContainsTarget && !firstPosContainsTarget)
                {
                    valid++;
                }
            }

            return valid;
        }
    }
}
