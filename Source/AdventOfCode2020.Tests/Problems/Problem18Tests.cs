namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem18Tests
    {
        [TestCase("1 + 2 * 3 + 4 * 5 + 6", 71)]
        [TestCase("2 * 3 + (4 * 5)", 26)]
        [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public void EvaluateExpressionTests(string expression, int expectedResult)
        {
            Assert.AreEqual(expectedResult, Problem18.EvaluateExpression(expression));
        }
    }
}
