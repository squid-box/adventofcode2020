namespace AdventOfCode2020
{
	using System;
	using System.Linq;
	using System.Reflection;

	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Advent of Code 2020");
			Console.WriteLine("Joel \"Squid-Box\" Ahlgren");
			
			var problems = Assembly.GetExecutingAssembly().GetTypes()
				.Where(type => type.IsSubclassOf(typeof(ProblemBase)))
				.Select(problemType => (ProblemBase) Activator.CreateInstance(problemType))
				.ToList();

			Console.WriteLine($"Preparing to run {problems.Count} solutions.");

			foreach (var problem in problems)
			{
				Console.WriteLine($"Solving problem #{problem.Day}...");
				problem.CalculateSolution();

				Console.WriteLine(problem.Result);
				Console.WriteLine();
			}
		}
	}
}
