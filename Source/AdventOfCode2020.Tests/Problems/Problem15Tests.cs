namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem15Tests
    {
        [Test]
        public void TestPartOne()
        {
            Assert.AreEqual(436, Problem15.FindNthNumberSpoken(new[] { 0, 3, 6 }, 2020));
            Assert.AreEqual(1, Problem15.FindNthNumberSpoken(new[] { 1, 3, 2 }, 2020));
            Assert.AreEqual(10, Problem15.FindNthNumberSpoken(new[] { 2, 1, 3 }, 2020));
            Assert.AreEqual(27, Problem15.FindNthNumberSpoken(new[] { 1, 2, 3 }, 2020));
            Assert.AreEqual(78, Problem15.FindNthNumberSpoken(new[] { 2, 3, 1 }, 2020));
            Assert.AreEqual(438, Problem15.FindNthNumberSpoken(new[] { 3, 2, 1 }, 2020));
            Assert.AreEqual(1836, Problem15.FindNthNumberSpoken(new[] { 3, 1, 2 }, 2020));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.AreEqual(175594, Problem15.FindNthNumberSpoken(new[] { 0, 3, 6 }, 30000000));
            Assert.AreEqual(2578, Problem15.FindNthNumberSpoken(new[] { 1, 3, 2 }, 30000000));
            Assert.AreEqual(3544142, Problem15.FindNthNumberSpoken(new[] { 2, 1, 3 }, 30000000));
            Assert.AreEqual(261214, Problem15.FindNthNumberSpoken(new[] { 1, 2, 3 }, 30000000));
            Assert.AreEqual(6895259, Problem15.FindNthNumberSpoken(new[] { 2, 3, 1 }, 30000000));
            Assert.AreEqual(18, Problem15.FindNthNumberSpoken(new[] { 3, 2, 1 }, 30000000));
            Assert.AreEqual(362, Problem15.FindNthNumberSpoken(new[] { 3, 1, 2 }, 30000000));
        }
    }
}
