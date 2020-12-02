namespace AdventOfCode2020.ProblemCollector
{
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Net;
	using System.Text;

	public class Program
	{
		private static readonly int Day = DateTime.UtcNow.Day;

		public static void Main(string[] args)
        {
	        if (args.Length != 4)
            {
                Console.Error.WriteLine("You need to provide a session cookie, repository URL, repository path, and repository branch.");
                Environment.Exit(1);
            }

            var sessionCookie = args[0];
            var repoUrl = args[1];
            var repoPath = args[2];
            var branchName = args[3];

			var pathToInputFile = Path.Combine("Inputs", $"{Day}.input");
			var pathToProblemFile = Path.Combine("Source", "AdventOfCode2020", "Problems", $"Problem{Day}.cs");
			var pathToProblemTestFile = Path.Combine("Source", "AdventOfCode2020.Tests", "Problems", $"Problem{Day}Tests.cs");

            if (DateTime.UtcNow.Year != 2020 && DateTime.UtcNow.Month != 12 || Day > 25)
            {
                Console.Error.WriteLine("It's not time yet.");
                Environment.Exit(2);
            }

            if (!Directory.Exists(repoPath))
            {
	            if (!CloneRepository(repoUrl, repoPath))
	            {
                    Console.Error.WriteLine("Could not clone repository.");
                    Environment.Exit(3);
	            }
            }

            var originalWorkingDir = Environment.CurrentDirectory;
            Environment.CurrentDirectory = repoPath;

            if (!PullLatestBranch(branchName))
            {
                Console.Error.WriteLine($"Couldn't pull latest {branchName}.");
	            Environment.Exit(4);
            }

            if (File.Exists(pathToInputFile))
            {
                Console.Out.WriteLine("Today's problem is already downloaded.");
                Environment.Exit(5);
            }

            if (!DownloadDailyInput(sessionCookie, pathToInputFile))
            {
                Environment.Exit(6);
            }

            if (!CreateDailyProblemCodeFiles(pathToProblemFile, pathToProblemTestFile))
            {
                Environment.Exit(7);
            }

            if (!CommitAndPushChanges(pathToInputFile, pathToProblemFile, pathToProblemTestFile))
            {
                Environment.Exit(8);
            }

            Environment.CurrentDirectory = originalWorkingDir;
            Console.Out.WriteLine("Done, exiting.");
        }

        private static bool DownloadDailyInput(string sessionCookie, string pathToInputFile)
        {
            Console.Out.WriteLine("Downloading daily input.");

            Directory.CreateDirectory(Path.GetDirectoryName(pathToInputFile));

            try
            {
                var request = WebRequest.CreateHttp($"https://adventofcode.com/2020/day/{Day}/input");
                request.CookieContainer = new CookieContainer(1);
                request.CookieContainer.Add(new Cookie("session", sessionCookie, "/", "adventofcode.com"));

                var response = request.GetResponse();

                using var receiveStream = response.GetResponseStream();
                using var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                
                var documentContents = readStream.ReadToEnd();

                File.WriteAllText(pathToInputFile, documentContents);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private static bool CreateDailyProblemCodeFiles(string pathToProblemFile, string pathToProblemTestFile)
        {
            Console.Out.WriteLine("Create daily problem code files.");

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(pathToProblemFile));
                File.WriteAllText(Path.Combine(pathToProblemFile), string.Format("namespace AdventOfCode2020.Problems{0}{{{0}    /// <summary>{0}    /// Solution for <a href=\"https://adventofcode.com/2020/day/{1}\">Day {1}</a>.{0}    /// </summary>{0}    public class Problem{1} : ProblemBase{0}    {{{0}        public Problem{1}() : base({1}){0}        {{{0}        }}{0}{0}        public override void CalculateSolution(){0}        {{{0}            // TODO{0}        }}{0}    }}{0}}}{0}", Environment.NewLine, Day));

                Directory.CreateDirectory(Path.GetDirectoryName(pathToProblemTestFile));
                File.WriteAllText(pathToProblemTestFile, string.Format("namespace AdventOfCode2020.Tests.Problems{0}{{{0}    using AdventOfCode2020.Problems;{0}    using NUnit.Framework;{0}{0}    [TestFixture]{0}    public class Problem{1}Tests{0}    {{{0}{0}    }}{0}}}{0}", Environment.NewLine, Day));

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return false;
            }
        }

        private static bool CloneRepository(string repoUrl, string repoPath)
        {
            Console.Out.WriteLine($"Cloning repository \"{repoUrl}\" to \"{repoPath}\".");

            return ExecuteGitCommand($"clone {repoUrl} {repoPath}");
        }

        private static bool PullLatestBranch(string branchName)
        {
            Console.Out.WriteLine($"Check out and pull branch {branchName}.");

            return ExecuteGitCommand($"checkout -B {branchName} --track origin/{branchName}") &&
                   ExecuteGitCommand("pull");
        }

        private static bool CommitAndPushChanges(string pathToInputFile, string pathToProblemFile, string pathToProblemTestFile)
        {
            Console.Out.WriteLine("Commit and push created files.");

            return ExecuteGitCommand($"add {pathToInputFile} {pathToProblemFile} {pathToProblemTestFile}") &&
                   ExecuteGitCommand($"commit -m \"Problem Collector: Adding input and boilerplate for {Day}\".") &&
                   ExecuteGitCommand("push");
        }

        private static bool ExecuteGitCommand(string arguments)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo("git", arguments)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };

            process.Start();

            process.WaitForExit(30 * 1000);

            if (process.ExitCode != 0)
            {
                Console.Error.WriteLine($"\"git {arguments}\" failed, exit code {process.ExitCode}.");

                return false;
            }

            return true;
        }
    }
}
