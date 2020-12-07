namespace AdventOfCode2020.Tests.Problems
{
    using System.Linq;
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem7Tests
    {
        private readonly string[] _testInputOne =
        {
            "light red bags contain 1 bright white bag, 2 muted yellow bags.",
            "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
            "bright white bags contain 1 shiny gold bag.",
            "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
            "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
            "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
            "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
            "faded blue bags contain no other bags.",
            "dotted black bags contain no other bags."
        };

        private readonly string[] _testInputTwo =
        {
            "shiny gold bags contain 2 dark red bags.",
            "dark red bags contain 2 dark orange bags.",
            "dark orange bags contain 2 dark yellow bags.",
            "dark yellow bags contain 2 dark green bags.",
            "dark green bags contain 2 dark blue bags.",
            "dark blue bags contain 2 dark violet bags.",
            "dark violet bags contain no other bags."
        };

        [Test]
        public void FindGoldenBagPossibilities()
        {
            var bags = Problem7.ParseInput(_testInputOne);
            Assert.AreEqual(4, Problem7.FindBagsThatCanHoldShinyGoldBag(bags));
        }

        [Test]
        public void FindBagsInsideGoldenBag()
        {
            var bags = Problem7.ParseInput(_testInputOne);
            Assert.AreEqual(32, Problem7.FindBagsWithinShinyGoldBag(bags));

            var moreBags = Problem7.ParseInput(_testInputTwo);
            Assert.AreEqual(126, Problem7.FindBagsWithinShinyGoldBag(moreBags));
        }

        [Test]
        public void Parsing_CreatesAllBags()
        {
            var bags = Problem7.ParseInput(_testInputOne);

            Assert.AreEqual(9, bags.Count);
            Assert.IsTrue(bags.Any(bag => bag.Value.Color.Equals("vibrant plum")));
            Assert.IsFalse(bags.Any(bag => bag.Value.Color.Equals("bright yellow")));
        }

        [Test]
        public void Parsing_BagsContainCorrect()
        {
            var bags = Problem7.ParseInput(_testInputOne);

            var lightRedBag = bags.First(b => b.Value.Color.Equals("light red")).Value;
            Assert.AreEqual(1, lightRedBag.Children.First(b => b.Item1.Color.Equals("bright white")).Item1.Children.Count);
            Assert.AreEqual(2, lightRedBag.Children.First(b => b.Item1.Color.Equals("muted yellow")).Item1.Children.Count);

            Assert.AreEqual(0, bags.First(b => b.Value.Color.Equals("faded blue")).Value.Children.Count);
        }
    }
}
