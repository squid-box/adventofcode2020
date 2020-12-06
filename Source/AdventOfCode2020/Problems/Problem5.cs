namespace AdventOfCode2020.Problems
{
	using System.Collections.Generic;
	using System.Linq;
	using AdventOfCode2020.Utils.Extensions;

	/// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/5">Day 5</a>.
    /// </summary>
    public class Problem5 : ProblemBase
    {
        public Problem5() : base(5) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            return ParseInput(Input.WithoutEmptyLines()).Max(p => p.Id);
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
	        var boardingPasses = 
		        ParseInput(Input.WithoutEmptyLines())
		        .OrderBy(p => p.Id)
		        .ToList();
			
	        var ids = new HashSet<int>(Enumerable.Range(boardingPasses.First().Id, boardingPasses.Last().Id));
			ids.ExceptWith(boardingPasses.Select(p => p.Id));

			// TODO: Actually ensure there's just one (correct) ID in 'ids'.
            return ids.First();
        }

        internal static IEnumerable<BoardingPass> ParseInput(IList<string> input)
        {
            return input.Select(line => new BoardingPass(line));
        }
    }

    internal class BoardingPass
    {
	    public BoardingPass(string input)
	    {
		    RawData = input;
		    Row = BinarySearch(Enumerable.Range(0, 128).ToList(), input.Substring(0, 7).ToList());
		    Column = BinarySearch(Enumerable.Range(0, 8).ToList(), input.Substring(7, 3).ToList());

		    Id = Row * 8 + Column;
	    }

        public string RawData { get; }

        public int Row { get; }

        public int Column { get; }

        public int Id { get; }

        private static int BinarySearch(IList<int> list, IList<char> instructions)
        {
	        if (instructions.Count == 0)
	        {
		        return list[0];
	        }

	        if (instructions[0].Equals('F') || instructions[0].Equals('L'))
	        {
		        list = list.Take(list.Count / 2).ToList();
	        }
	        else
	        {
		        list = list.Skip(list.Count / 2).ToList();
	        }

	        instructions.RemoveAt(0);

	        return BinarySearch(list, instructions);
        }
    }
}
