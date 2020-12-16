namespace AdventOfCode2020.Tests.Problems
{
    using System.Linq;
    using AdventOfCode2020.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem16Tests
    {
        private readonly string[] _firstTestInput =
        {
            "class: 1-3 or 5-7",
            "row: 6-11 or 33-44",
            "seat: 13-40 or 45-50",
            "",
            "your ticket:",
            "7,1,14",
            "",
            "nearby tickets:",
            "7,3,47",
            "40,4,50",
            "55,2,20",
            "38,6,12"
        };

        [Test]
        public void TestInputParsing()
        {
            var (rules, myTicket, otherTickets) = Problem16.ParseInput(_firstTestInput);

            Assert.AreEqual(3, rules.Count());
            Assert.AreEqual(4, otherTickets.Count());

            Assert.AreEqual(3, myTicket.Fields.Count);

            Assert.AreEqual("class", rules.First().Name);
        }

        [Test]
        public void TestScanErrorRate()
        {
            var (rules, myTicket, otherTickets) = Problem16.ParseInput(_firstTestInput);

            Assert.AreEqual(71, Problem16.FindErrorScanRate(rules, otherTickets.Append(myTicket)));
        }

        [Test]
        public void TestFindDepartureValueProduct()
        {
            string[] testInput =
            {
                "class: 0-1 or 4-19",
                "row: 0-5 or 8-19",
                "seat: 0-13 or 16-19",
                "",
                "your ticket:",
                "11,12,13",
                "",
                "nearby tickets:",
                "3,9,18",
                "15,1,5",
                "5,14,9"
            };

            var (rules, myTicket, otherTickets) = Problem16.ParseInput(testInput);

            Assert.AreEqual(11, Problem16.FindDepartureValueProduct(rules, myTicket, otherTickets, "row"));
            Assert.AreEqual(12, Problem16.FindDepartureValueProduct(rules, myTicket, otherTickets, "class"));
            Assert.AreEqual(13, Problem16.FindDepartureValueProduct(rules, myTicket, otherTickets, "seat"));
        }
    }
}
