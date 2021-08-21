namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem22Tests
    {
        private readonly string[] _testInput =
        {
            "Player 1:",
            "9",
            "2",
            "6",
            "3",
            "1",
            "",
            "Player 2:",
            "5",
            "8",
            "4",
            "7",
            "10"
        };

        [Test]
        public void FindWinnerScoreTest()
        {
            Assert.AreEqual(306, Problem22.FindWinnerScore(_testInput));
        }

        [Test]
        public void ParseInputTest()
        {
            var (playerOneDeck, playerTwoDeck) = Problem22.ParseInput(_testInput);

            Assert.AreEqual(new []{9, 2, 6, 3, 1}, playerOneDeck);
            Assert.AreEqual(new []{5, 8, 4, 7, 10}, playerTwoDeck);
        }

        [Test]
        public void CalculateScoreTest()
        {
            var deck = new[] {3, 2, 10, 6, 8, 5, 9, 4, 7, 1};

            Assert.AreEqual(306, Problem22.CalculateScore(deck));
        }
    }
}
