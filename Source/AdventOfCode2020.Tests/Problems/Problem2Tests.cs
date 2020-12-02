namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem2Tests
    {
        [Test]
        public void TestPartOne()
        {
            var input = new[] {"1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc"};

            Assert.AreEqual(2, Problem2.FindValidPasswords(input));
        }

        [Test]
        public void TestPartTwo()
        {
            var input = new[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };

            Assert.AreEqual(1, Problem2.FindOtherValidPasswords(input));
        }
    }
}
