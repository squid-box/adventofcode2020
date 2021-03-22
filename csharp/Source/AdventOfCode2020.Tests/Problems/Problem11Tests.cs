namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem11Tests
    {
        private readonly string[] _testInput =
        {
            "L.LL.LL.LL",
            "LLLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLLL",
            "L.LLLLLL.L",
            "L.LLLLL.LL"
        };

        [Test]
        public void SeatingParsingTest()
        {
            var seating = new Seating(_testInput);

            Assert.AreEqual('L', seating.GetSeat(0,0));
            Assert.AreEqual('L', seating.GetSeat(0,1));
            Assert.AreEqual('.', seating.GetSeat(1,0));
            Assert.AreEqual('L', seating.GetSeat(9,9));
        }

        [Test]
        public void TestPartOne()
        {
            Assert.AreEqual(37, Problem11.FindPartOne(_testInput));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.AreEqual(26, Problem11.FindPartTwo(_testInput));
        }
    }
}
