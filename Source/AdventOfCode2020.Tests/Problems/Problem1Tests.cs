namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem1Tests
    {
        [Test]
        public void TestFindValuesToSum()
        {
            var input = new []{ 1721, 979, 366, 299, 675, 1456 };
            Assert.AreEqual(514579, Problem1.FindAnswerOne(input, 2020));
            Assert.AreEqual(241861950, Problem1.FindAnswerTwo(input, 2020));
        }
    }
}
