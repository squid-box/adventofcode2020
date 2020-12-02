﻿namespace AdventOfCode2020
{
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
            .Where(line => !string.IsNullOrEmpty(line))
            .ToArray();

		/// <summary>
		/// The <see cref="Result"/> of solving this problem.
		/// </summary>
		public Result Result { get; }

		/// <summary>
		/// Calculate the solution(s) to this problem.
		/// </summary>
		public abstract void CalculateSolution();
	}
}
