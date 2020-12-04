namespace AdventOfCode2020
{
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>
	/// Base class for Problems.
	/// </summary>
	public abstract class ProblemBase
	{
		/// <summary>
		/// Creates a new <see cref="ProblemBase"/>.
		/// </summary>
		/// <param name="day">Day this problem belongs to.</param>
		protected ProblemBase(int day)
		{
			Day = day;
			Result = new Result(Day);
		}

		/// <summary>
		/// Day this problem belongs to.
		/// </summary>
		public int Day { get; }

        /// <summary>
        /// Gets the input for this problem.
        /// </summary>
        public string[] Input => File
            .ReadAllLines($"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}Inputs{Path.DirectorySeparatorChar}{Day}.input")
            .ToArray();

		/// <summary>
		/// The <see cref="Result"/> of solving this problem.
		/// </summary>
		public Result Result { get; }

        /// <summary>
        /// Calculate the solution(s) to this problem.
        /// </summary>
        public void CalculateSolution()
        {
            var start = DateTime.Now;
            Result.AnswerPartOne = SolvePartOne();
            Result.TimePartOne = DateTime.Now - start;

            start = DateTime.Now;
            Result.AnswerPartTwo = SolvePartTwo();
            Result.TimePartTwo = DateTime.Now - start;
        }

        /// <summary>
        /// Calculates the first part of this problem.
        /// </summary>
        /// <returns>The answer for this part.</returns>
        protected abstract string SolvePartOne();
        
        /// <summary>
        /// Calculates the second part of this problem.
        /// </summary>
        /// <returns>The answer for this part.</returns>
        protected abstract string SolvePartTwo();
    }
}
