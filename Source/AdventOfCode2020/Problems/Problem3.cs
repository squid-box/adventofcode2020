namespace AdventOfCode2020.Problems
{
	using System.Collections.Generic;
	using AdventOfCode2020.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/3">Day 3</a>.
    /// </summary>
    public class Problem3 : ProblemBase
    {
        public Problem3() : base(3) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            return CountHits(ParseInputToMap(Input.WithoutEmptyLines()), 3, 1);
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            var map = ParseInputToMap(Input.WithoutEmptyLines());

            long total = 1;

            total *= CountHits(map, 1, 1);
            total *= CountHits(map, 3, 1);
            total *= CountHits(map, 5, 1);
            total *= CountHits(map, 7, 1);
            total *= CountHits(map, 1, 2);

            return total;
        }

        internal static bool[,] ParseInputToMap(IList<string> input)
        {
            var result = new bool[input[0].Length, input.Count];

            for (var y = 0; y < input.Count; y++)
            {
                for (var x = 0; x < input[y].Length; x++)
                {
                    result[x, y] = input[y][x] == '#';
                }
            }

            return result;
        }

        internal static int CountHits(bool[,] map, int xSpeed, int ySpeed)
        {
            var (x, y) = (0, 0);

            var trees = 0;

            while (y < map.GetLength(1))
            {
                if (map[x%map.GetLength(0), y])
                {
                    trees++;
                }

                x += xSpeed;
                y += ySpeed;
            }

            return trees;
        }
    }
}
