namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem6Tests
    {
	    private string[] TestInput = { "abc", "", "a", "b", "c", "", "ab", "ac", "", "a", "a", "a", "a", "", "b" };

        [Test]
	    public void SumOfYesResponses()
	    {
            Assert.AreEqual(11, Problem6.FindSumOfYesAnswers(TestInput));
	    }

	    [Test]
	    public void SumOfYesResponsesPartTwo()
	    {
		    Assert.AreEqual(6, Problem6.FindSumOfYesAnswersPartTwo(TestInput));
	    }
    }
}
