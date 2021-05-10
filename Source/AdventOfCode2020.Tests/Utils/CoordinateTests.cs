namespace AdventOfCode2020.Tests.Utils
{
    using AdventOfCode2020.Utils;
    using NUnit.Framework;

    [TestFixture]
    public class CoordinateTests
    {
        [Test]
        public void CoordinateVectorInteraction()
        {
            var coordinate = new Coordinate(1, 2, 3);

            Assert.AreEqual(new Coordinate(1, 2, 4), coordinate + Vector.Up);
            Assert.AreEqual(new Coordinate(1, 2, 2), coordinate - Vector.Up);
        }
    }
}
