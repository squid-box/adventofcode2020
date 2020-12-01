namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem1Tests
    {
        public void TestFindValuesToSum()
        {
            var input = new []{ 1721, 979, 366, 299, 675, 1456 };

            var (first, second) = Problem1.FindValuesToSum(input, 2020);

            Assert.AreEqual(2020, first + second);
        }
    }
}