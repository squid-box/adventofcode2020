namespace AdventOfCode2020.Tests.Utils.Extensions
{
    using System;
    using AdventOfCode2020.Utils.Extensions;
    using NUnit.Framework;

    [TestFixture]
    public class StringExtensionsTests
    {
        [TestCase("0", 0)]
        [TestCase("-10", -10)]
        [TestCase("666", 666)]
        public void Test(string source, int expectedResult)
        {
            Assert.AreEqual(expectedResult, source.ToInt());
        }

        [Test]
        public void BadString_Throws()
        {
            Assert.Throws<FormatException>(() => "hello".ToInt());
        }
    }
}
