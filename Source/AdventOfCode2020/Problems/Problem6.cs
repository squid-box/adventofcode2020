namespace AdventOfCode2020.Problems
{
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/6">Day 6</a>.
    /// </summary>
    public class Problem6 : ProblemBase
    {
        public Problem6() : base(6) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            return FindSumOfYesAnswers(Input);
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            return FindSumOfYesAnswersPartTwo(Input);
        }

        internal static int FindSumOfYesAnswers(IEnumerable<string> input)
        {
	        var sum = 0;

	        var groupAnswers = new HashSet<char>();

	        foreach (var line in input)
	        {
		        if (string.IsNullOrWhiteSpace(line))
		        {
			        sum += groupAnswers.Count;
                    groupAnswers.Clear();

			        continue;
		        }

		        foreach (var c in line)
		        {
			        groupAnswers.Add(c);
		        }
	        }

	        if (groupAnswers.Count > 0)
	        {
                sum += groupAnswers.Count;
	        }

	        return sum;
        }

        internal static int FindSumOfYesAnswersPartTwo(IEnumerable<string> input)
        {
	        var group = new List<string>();
	        var sum = 0;

			foreach (var line in input)
			{
				if (string.IsNullOrWhiteSpace(line))
				{
					sum += CountGroupSum(group);
					group.Clear();

					continue;
				}

				group.Add(line);
			}

			if (group.Count != 0)
			{
				sum += CountGroupSum(group);
			}

			return sum;
        }

        private static int CountGroupSum(ICollection<string> group)
        {
	        var groupSize = group.Count;
	        var results = new Dictionary<char, int>();

			foreach (var person in group)
			{
				foreach (var answer in person)
				{
					results[answer] = results.ContainsKey(answer) ? results[answer] + 1 : 1;
				}
			}

			return results.Count(res => res.Value == groupSize);
        }

	}
}
