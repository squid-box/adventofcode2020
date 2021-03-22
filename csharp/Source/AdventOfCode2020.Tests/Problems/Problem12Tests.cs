namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem12Tests
    {
        private readonly string[] _testInput =
        {
            "F10",
            "N3",
            "F7",
            "R90",
            "F11"
        };

        [Test]
        public void PartOneTest()
        {
            Assert.AreEqual(25, Problem12.FindPartOne(_testInput));
        }

        [Test]
        public void PartTwoTest()
        {
            Assert.AreEqual(286, Problem12.FindPartTwo(_testInput));
        }
    }
}
