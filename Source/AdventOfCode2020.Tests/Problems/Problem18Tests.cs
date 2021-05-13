namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem18Tests
    {
        [TestCase("1 + 2 * 3 + 4 * 5 + 6", 71)]
        [TestCase("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [TestCase("2 * 3 + (4 * 5)", 26)]
        [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public void EvaluateExpressionTestsPartOne(string expression, int expectedResult)
        {
            Assert.AreEqual(expectedResult, Problem18.EvaluateExpression(expression, false));
        }

        [TestCase("1 + 2 * 3 + 4 * 5 + 6", 231)]
        [TestCase("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [TestCase("2 * 3 + (4 * 5)", 46)]
        [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
        [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
        [TestCase("7 + 7 + 7 + (4 + 7)", 32)]
        [TestCase("2 + 3 * 4 * 2 + 3 * 7", 700)]
        [TestCase("2 * (3 + 5) + (2 * 3)", 28)]
        [TestCase("6 + 7 * 16 + 7", 299)]
        public void EvaluateExpressionTestsPartTwo(string expression, int expectedResult)
        {
            Assert.AreEqual(expectedResult, Problem18.EvaluateExpression(expression, true));
        }
    }
}
