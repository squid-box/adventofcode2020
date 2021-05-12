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
            return FindPartTwo(Input.WithoutEmptyLines().Last());
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
            var buses = new List<(long Id, long Time)>();

            var timeTable = input.Split(',');

            for (long i = 0; i < timeTable.Length; i++)
            {
                if (!timeTable[i].Equals("x"))
                {
                    buses.Add((i, long.Parse(timeTable[i])));
                }
            }

            var firstBus = buses[0];
            long first = default;

            for (var n = 0; n < buses.Count - 1; n++)
            {
                first = FindFirst(buses, n, firstBus, firstBus.Id);
                var next = FindFirst(buses, n, firstBus, first) - first;
                firstBus = (first, next);
            }

            return first;
        }

        private static long FindFirst(IReadOnlyList<(long Id, long Time)> buses, int i, (long Id, long Time) currentBus, long start)
        {
            var multiplier = 1;

            while (true)
            {
                if ((currentBus.Time * multiplier + buses[i + 1].Id + start) % buses[i + 1].Time == 0)
                {
                    break;
                };

                multiplier++;
            }

            return currentBus.Time * multiplier + start;
        }
    }
}
