namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem10Tests
    {
        private readonly int[] _testInput1 =
        {
            16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4
        };

        private readonly int[] _testInput2 =
        {
            28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49, 45, 19, 38, 39, 11, 1, 32, 25, 35, 8, 17, 7, 9, 4, 2, 34, 10, 3
        };

        [Test]
        public void FindPartOne()
        {
            Assert.AreEqual(35, Problem10.FindPartOne(_testInput1));
            Assert.AreEqual(220, Problem10.FindPartOne(_testInput2));
        }

        [Test]
        public void FindPartTwo()
        {
            Assert.AreEqual(8, Problem10.FindPartTwo(_testInput1));
            Assert.AreEqual(19208, Problem10.FindPartTwo(_testInput2));
        }
    }
}
