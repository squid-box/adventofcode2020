namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem13Tests
    {
        private readonly string[] _testInput =
        {
            "939",
            "7,13,x,x,59,x,31,19"
        };

        [Test]
        public void TestPartOne()
        {
            Assert.AreEqual(295, Problem13.FindPartOne(_testInput));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.AreEqual(1068788, Problem13.FindPartTwo(_testInput[1]));
            Assert.AreEqual(3417, Problem13.FindPartTwo("17,x,13,19"));
            Assert.AreEqual(754018, Problem13.FindPartTwo("67,7,59,61"));
            Assert.AreEqual(779210, Problem13.FindPartTwo("67,x,7,59,61"));
            Assert.AreEqual(1261476, Problem13.FindPartTwo("67,7,x,59,61"));
            Assert.AreEqual(1202161486, Problem13.FindPartTwo("1789,37,47,1889"));
        }
    }
}
