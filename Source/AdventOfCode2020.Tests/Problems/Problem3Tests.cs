namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem3Tests
    {
        private static readonly string[] Input = 
        {
            "..##.......",
            "#...#...#.." ,
            ".#....#..#." ,
            "..#.#...#.#" ,
            ".#...##..#." ,
            "..#.##....." ,
            ".#.#.#....#" ,
            ".#........#" ,
            "#.##...#..." ,
            "#...##....#" ,
            ".#..#...#.#"
        };

        [Test]
        public void ParseInput_MapSize()
        {
            var map = Problem3.ParseInputToMap(Input);

            Assert.AreEqual(11, map.GetLength(0));
            Assert.AreEqual(11, map.GetLength(1));
        }

        [Test]
        public void ParseInput_MapParsing()
        {
            var map = Problem3.ParseInputToMap(Input);

            Assert.IsFalse(map[0,0]);
            Assert.IsTrue(map[0,1]);
            Assert.IsTrue(map[10, 10]);
        }

        [TestCase(1, 1, 2)]
        [TestCase(3, 1, 7)]
        [TestCase(5, 1, 3)]
        [TestCase(7, 1, 4)]
        [TestCase(1, 2, 2)]
        public void TestSlope(int xSpeed, int ySpeed, int expectedTrees)
        {
            Assert.AreEqual(expectedTrees , Problem3.CountHits(Problem3.ParseInputToMap(Input), xSpeed, ySpeed));
        }

        [Test]
        public void PartTwoTest()
        {
            var map = Problem3.ParseInputToMap(Input);

            var total = Problem3.CountHits(map, 1, 1);

            total *= Problem3.CountHits(map, 3, 1);
            total *= Problem3.CountHits(map, 5, 1);
            total *= Problem3.CountHits(map, 7, 1);
            total *= Problem3.CountHits(map, 1, 2);

            Assert.AreEqual(336, total);
        }
    }
}
