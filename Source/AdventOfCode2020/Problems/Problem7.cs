namespace AdventOfCode2020.Problems
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using AdventOfCode2020.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/7">Day 7</a>.
    /// </summary>
    public class Problem7 : ProblemBase
    {
        public Problem7() : base(7) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            var bags = ParseInput(Input.WithoutEmptyLines());

            return FindBagsThatCanHoldShinyGoldBag(bags);
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            var bags = ParseInput(Input.WithoutEmptyLines());

            return FindBagsWithinShinyGoldBag(bags);
        }

        internal static int FindBagsThatCanHoldShinyGoldBag(IDictionary<string, Bag> bags)
        {
            return bags["shiny gold"].ParentColors().ToHashSet().Count;
        }

        internal static long FindBagsWithinShinyGoldBag(IDictionary<string, Bag> bags)
        {
            return bags["shiny gold"].CountBags();
        }

        internal static IDictionary<string, Bag> ParseInput(IEnumerable<string> input)
        {
            var bags = new Dictionary<string, Bag>();

            foreach (var line in input)
            {
                // dark olive bags contain 3 faded blue bags, 4 dotted black bags.

                var firstRegex = 
                    Regex.Match(line, @"^(?<container>[\w ]+?) bags contain (?<contained>(?<none>no other bags)|(.*))\.$",
                    RegexOptions.ExplicitCapture);
                var color = firstRegex.Groups["container"].Value;

                if (!bags.ContainsKey(color))
                {
                    bags.Add(color, new Bag(color));
                }

                // This bag contains no other bags.
                if (firstRegex.Groups["none"].Success)
                {
                    continue;
                }

                var bag = bags[color];
                var contains = firstRegex.Groups["contained"].Value.Split(",");

                foreach (var contained in contains)
                {
                    var containsRegex = Regex.Match(contained, @"^\s*(?<amount>\d+) (?<color>[\w ]+?) (bag|bags)$", RegexOptions.ExplicitCapture);
                    var containedColor = containsRegex.Groups["color"].Value;

                    var otherBag = bags.GetValueOrDefault(containedColor) ?? new Bag(containedColor);
                    if (!bags.ContainsKey(containedColor))
                    {
                        bags[containedColor] = otherBag;
                    }

                    otherBag.Parents.Add(bag);
                    bag.Children.Add((otherBag, containsRegex.Groups["amount"].Value.ToInt()));
                }
            }

            return bags;
        }
    }

    internal class Bag
    {
        public Bag(string color)
        {
            Color = color;
            Children = new List<(Bag, int)>();
            Parents = new List<Bag>();
        }

        public IList<(Bag, int)> Children { get; }
        
        public IList<Bag> Parents { get; }

        public string Color { get; }

        public IEnumerable<string> ParentColors() => Parents.SelectMany(p => p.ParentColors().Concat(new[] { p.Color }));

        public long CountBags() => Children.Sum(child => child.Item2) + Children.Sum(child => child.Item1.CountBags() * child.Item2);
    }
}
