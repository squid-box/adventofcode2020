namespace AdventOfCode2020
{
	using System;
	using System.Linq;

	/// <summary>
	/// Represents the results from calculating a days problem(s).
	/// </summary>
	public class Result
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="day"></param>
		public Result(int day)
		{
			Day = day;
		}

		/// <summary>
		/// Gets the day this <see cref="Result"/> belongs to.
		/// </summary>
		public int Day { get; }

		/// <summary>
		/// Gets the answer to part one of this <see cref="Result"/>.
		/// </summary>
		public string AnswerPartOne { get; set; }

		/// <summary>
		/// Gets the answer to part two of this <see cref="Result"/>.
		/// </summary>
		public string AnswerPartTwo { get; set; }

		/// <summary>
		/// Gets the full answer of this <see cref="Result"/>.
		/// </summary>
		public string FullAnswer => string.Join(" | ", new []{AnswerPartOne, AnswerPartTwo}.Where(str => !string.IsNullOrWhiteSpace(str)));

		/// <summary>
		/// Gets the time it took to calculate part one of this <see cref="Result"/>.
		/// </summary>
		public TimeSpan TimePartOne { get; set; }

		/// <summary>
		/// Gets the time it took to calculate part two of this <see cref="Result"/>.
		/// </summary>
		public TimeSpan TimePartTwo { get; set; }

		/// <summary>
		/// Gets the time it took to calculate both parts of this <see cref="Result"/>.
		/// </summary>
		public TimeSpan FullTime => TimePartOne + TimePartTwo;
	}
}