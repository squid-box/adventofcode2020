namespace AdventOfCode2020.Tests.Problems
{
    using System.Collections.Generic;
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem9Tests
    {
        private readonly List<long> _testInput = new List<long>
        {
            35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576
        };

        [Test]
        public void FindFirstInvalidNumberTest()
        {
            Assert.AreEqual(127, Problem9.FindFirstInvalidNumber(_testInput, 5));
        }

        [Test]
        public void FindContiguousRangeMinMaxSumTest()
        {
            Assert.AreEqual(62, Problem9.FindContiguousRangeMinMaxSum(_testInput, 127));
        }
    }
}
