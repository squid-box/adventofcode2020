namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem5Tests
    {
        [TestCase("FBFBBFFRLR", 44, 5, 357)]
        [TestCase("BFFFBBFRRR", 70, 7, 567)]
        [TestCase("FFFBBBFRRR", 14, 7, 119)]
        [TestCase("BBFFBBFRLL", 102, 4, 820)]
	    public void BoardingPass_VerifyParsing(string input, int expectedRow, int expectedColumn, int expectedId)
	    {
            var boardingPass = new BoardingPass(input);
            Assert.AreEqual(expectedRow, boardingPass.Row);
            Assert.AreEqual(expectedColumn, boardingPass.Column);
            Assert.AreEqual(expectedId, boardingPass.Id);
	    }
    }
}
