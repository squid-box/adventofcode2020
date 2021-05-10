namespace AdventOfCode2020.Tests.Problems
{
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem8Tests
    {
        private readonly string[] _testInput =
        {
            "nop +0",
            "acc +1",
            "jmp +4",
            "acc +3",
            "jmp -3",
            "acc -99",
            "acc +1",
            "jmp -4",
            "acc +6"
        };

        [Test]
        public void FindAccumulatorValueAfterExecution()
        {
            Assert.AreEqual(5, Problem8.FindAccumulatorValueOnRepeat(_testInput));
        }

        [Test]
        public void FindAccumulatorValueAfterModification()
        {
            Assert.AreEqual(8, Problem8.FindAccumulatorValueAfterModification(_testInput));
        }
    }
}
