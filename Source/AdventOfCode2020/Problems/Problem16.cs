namespace AdventOfCode2020.Problems
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using AdventOfCode2020.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/16">Day 16</a>.
    /// </summary>
    public class Problem16 : ProblemBase
    {
        public Problem16() : base(16) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            var (rules, myTicket, otherTickets) = ParseInput(Input);

            return FindErrorScanRate(rules, otherTickets.Append(myTicket));
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            var (rules, myTicket, otherTickets) = ParseInput(Input);

            return FindDepartureValueProduct(rules, myTicket, otherTickets, "departure");
        }

        internal static int FindErrorScanRate(IEnumerable<Rule> rules, IEnumerable<Ticket> tickets)
        {
            return tickets.Select(ticket => ticket.ErrorRate(rules)).Sum();
        }

        internal static int FindDepartureValueProduct(IEnumerable<Rule> rules, Ticket myTicket, IEnumerable<Ticket> tickets, string target)
        {
            var validTickets = tickets.Where(ticket => ticket.Valid(rules)).Append(myTicket);
            var potentialFieldValues = new Dictionary<string, HashSet<int>>();

            foreach (var rule in rules)
            {
                var potential = new HashSet<int>();

                for (var i = 0; i < myTicket.Fields.Count; i++)
                {
                    if (tickets.All(ticket => rule.Validate(ticket.Fields[i])))
                    {
                        potential.Add(i);
                    }
                }

                potentialFieldValues.Add(rule.Name, potential);
            }

            // Name: Index
            var knownFields = new Dictionary<string, int>();

            while (knownFields.Count < myTicket.Fields.Count)
            {
                var knowns = potentialFieldValues.Where(p => p.Value.Count == 1);

                foreach (var known in knowns)
                {
                    var knownIndex = known.Value.First();
                    knownFields.Add(known.Key, knownIndex);
                    
                    foreach (var remainingPotential in potentialFieldValues)
                    {
                        remainingPotential.Value.Remove(knownIndex);
                    }
                }
            }

            var departureIndexes = knownFields.Where(rule => rule.Key.StartsWith(target));

            var product = 1;
            
            foreach (var (_, value) in departureIndexes)
            {
                product *= myTicket.Fields[value];
            }

            return product;
        }

        internal static (IEnumerable<Rule> Rules, Ticket MyTicket, IEnumerable<Ticket> OtherTickets) ParseInput(IEnumerable<string> input)
        {
            var state = "rules";

            var rules = new List<Rule>();
            Ticket myTicket = null;
            var otherTickets = new List<Ticket>();

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (line.Equals("your ticket:"))
                {
                    state = "ticket";
                    continue;
                }

                if (line.Equals("nearby tickets:"))
                {
                    state = "tickets";
                    continue;
                }

                switch (state)
                {
                    case "rules":
                        rules.Add(new Rule(line));
                        break;
                    case "ticket":
                        myTicket = new Ticket(line);
                        break;
                    case "tickets":
                        otherTickets.Add(new Ticket(line));
                        break;
                }
            }

            return (rules, myTicket, otherTickets);
        }
    }

    internal class Rule
    {
        private readonly int _firstLowerRange;
        private readonly int _firstUpperRange;
        private readonly int _secondLowerRange;
        private readonly int _secondUpperRange;

        public Rule(string input)
        {
            var matches = Regex.Match(input, @"(?<name>.+): (?<firstLowerRange>\d+)-(?<firstUpperRange>\d+) or (?<secondLowerRange>\d+)-(?<secondUpperRange>\d+)", RegexOptions.ExplicitCapture);
            Name = matches.Groups["name"].Value;

            _firstLowerRange = matches.Groups["firstLowerRange"].Value.ToInt();
            _firstUpperRange = matches.Groups["firstUpperRange"].Value.ToInt();

            _secondLowerRange = matches.Groups["secondLowerRange"].Value.ToInt();
            _secondUpperRange = matches.Groups["secondUpperRange"].Value.ToInt();
        }

        public string Name { get; }

        public bool Validate(int val)
        {
            return val.IsWithin(_firstLowerRange, _firstUpperRange) ||
                   val.IsWithin(_secondLowerRange, _secondUpperRange);
        }
    }

    internal class Ticket
    {
        public Ticket(string input)
        {
            Fields = new List<int>();

            foreach (var field in input.Split(','))
            {
                Fields.Add(field.ToInt());
            }
        }

        public bool Valid(IEnumerable<Rule> rules) => Fields.All(field => IsFieldValid(field, rules));

        private static bool IsFieldValid(int field, IEnumerable<Rule> rules)
        {
            return rules.Any(rule => rule.Validate(field));
        }

        public int ErrorRate(IEnumerable<Rule> rules)
        {
            var sum = 0;

            foreach (var field in Fields)
            {
                if (!IsFieldValid(field, rules))
                {
                    sum += field;
                }
            }

            return sum;
        }

        public List<int> Fields { get; }
    }
}
