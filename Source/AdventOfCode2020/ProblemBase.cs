namespace AdventOfCode2020
{
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
		}

		/// <summary>
		/// Day this problem belongs to.
		/// </summary>
		public int Day { get; }

		public Result Result { get; protected set; }

		/// <summary>
		/// 
		/// </summary>
		public abstract void CalculatePartOne();
	}
}