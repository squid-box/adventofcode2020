namespace AdventOfCode2020.Tests.Problems
{
    using System.Linq;
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem19Tests
    {
        private readonly string[] _testInput =
        {
            "0: 4 1 5",
            "1: 2 3 | 3 2",
            "2: 4 4 | 5 5",
            "3: 4 5 | 5 4",
            "4: a",
            "5: b",
            "",
            "ababbb",
            "bababa",
            "abbbab",
            "aaabbb",
            "aaaabbb"
        };

        [Test]
        public void FindValidMessagesTest()
        {
            Assert.AreEqual(2, Problem19.FindValidMessages(_testInput).Count());
        }
    }
}