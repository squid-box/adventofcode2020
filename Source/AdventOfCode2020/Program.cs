namespace AdventOfCode2020
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Threading.Tasks;

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

			Parallel.ForEach(problems, problem =>
			{
				Console.WriteLine($"Solving problem #{problem.Day}...");
				problem.CalculateSolution();
			});

			// Print results here, or they're disordered...
			foreach (var problem in problems)
			{
				Console.WriteLine(problem.Result);
				Console.WriteLine($"Day total: {problem.Result.FullTime}");
				Console.WriteLine();
			}
		}
	}
}
