namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;
    using NUnit.Framework.Internal;

    [TestFixture]
    public class Problem14Tests
    {
        [Test]
        public void FindPartOneTest()
        {
            var testInput = new []
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "mem[8] = 11",
                "mem[7] = 101",
                "mem[8] = 0"
            };

            Assert.AreEqual(165, Problem14.FindAnswer(testInput, true));
        }

        [Test]
        public void FindPartTwoTest()
        {
            var testInput = new []
            {
                "mask = 000000000000000000000000000000X1001X",
                "mem[42] = 100",
                "mask = 00000000000000000000000000000000X0XX",
                "mem[26] = 1"
            };

            Assert.AreEqual(208, Problem14.FindAnswer(testInput, false));
        }
    }
}
