namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem17Tests
    {
        private readonly string[] _testInput =
        {
            ".#.",
            "..#",
            "###"
        };

        [Test]
        public void ParseInput()
        {
            var space3d = new Space(_testInput, 3);
            var space4d = new Space(_testInput, 4);

            Assert.AreEqual(5, space3d.ActiveCubes);
            Assert.AreEqual(5, space4d.ActiveCubes);
        }

        [Test]
        public void TestCycles()
        {
            var space = new Space(_testInput, 3);

            Assert.AreEqual(5, space.ActiveCubes);

            space.Cycle();

            Assert.AreEqual(11, space.ActiveCubes);

            space.Cycle();

            Assert.AreEqual(21, space.ActiveCubes);
        }

        [Test]
        public void Test4dCycles()
        {
            var space4d = new Space(_testInput, 4);

            Assert.AreEqual(5, space4d.ActiveCubes);

            space4d.Cycle();

            Assert.AreEqual(29, space4d.ActiveCubes);

            space4d.Cycle();

            Assert.AreEqual(60, space4d.ActiveCubes);
        }

        [Test]
        public void TestPartOne()
        {
            var space = new Space(_testInput, 3);

            space.Cycle();

            Assert.AreEqual(112, space.ActiveCubes);
        }

        [Test]
        public void TestPartTwo()
        {
            var space = new Space(_testInput, 4);

            space.Cycle();

            Assert.AreEqual(848, space.ActiveCubes);
        }
    }
}
