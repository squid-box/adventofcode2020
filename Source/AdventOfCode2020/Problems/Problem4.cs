namespace AdventOfCode2020.Problems
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using AdventOfCode2020.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/4">Day 4</a>.
    /// </summary>
    public class Problem4 : ProblemBase
    {
        public Problem4() : base(4) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            var passports = ParseInput(Input.ToList());

            return FindValidPassports(passports);
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            var passports = ParseInput(Input.ToList());

            return passports.Count(passport => passport.IsStrictlyValid);
        }

        internal static int FindValidPassports(IEnumerable<Passport> passports)
        {
            return passports.Count(passport => passport.IsValid);
        }

        internal static IEnumerable<Passport> ParseInput(IList<string> input)
        {
            var results = new List<Passport>();
            var passportData = new List<string>();

            foreach (var line in input)
            {
	            if (string.IsNullOrEmpty(line))
	            {
		            results.Add(new Passport(passportData));
		            passportData.Clear();
		            continue;
	            }

	            passportData.Add(line);
            }

            if (passportData.Count != 0)
            {
                results.Add(new Passport(passportData));
            }

            return results;
        }
    }

    internal class Passport
    {
        public Passport(IEnumerable<string> input)
        {
            foreach (var field in string.Join(' ', input).Split(" "))
            {
                var fieldSplit = field.Split(':');

                switch (fieldSplit[0])
                {
                    case "byr":
                        BirthYear = fieldSplit[1].ToInt();
                    break;
                    case "iyr":
                        IssueYear = fieldSplit[1].ToInt();
                        break;
                    case "eyr":
                        ExpirationYear = fieldSplit[1].ToInt();
                        break;
                    case "hgt":
                        Height = fieldSplit[1];
                        break;
                    case "hcl":
                        HairColor = fieldSplit[1];
                        break;
                    case "ecl":
                        EyeColor = fieldSplit[1];
                        break;
                    case "pid":
                        PassportId = fieldSplit[1];
                        break;
                    case "cid":
                        CountryId = fieldSplit[1];
                        break;
                }
            }
        }

        public int? BirthYear { get; }

        public int? IssueYear { get; }

        public int? ExpirationYear { get; }

        public string Height { get; }

        public string HairColor { get; }

        public string EyeColor { get; }

        public string PassportId { get; }

        public string CountryId { get; }

        public bool IsValid =>
            BirthYear != null &&
            IssueYear != null &&
            ExpirationYear != null &&
            !string.IsNullOrWhiteSpace(Height) &&
            !string.IsNullOrWhiteSpace(HairColor) &&
            !string.IsNullOrWhiteSpace(EyeColor) &&
            PassportId != null;

        public bool IsStrictlyValid =>
            IsValid &&
            BirthYear.Value.IsWithin(1920, 2002) &&
            IssueYear.Value.IsWithin(2010, 2020) &&
            ExpirationYear.Value.IsWithin(2020, 2030) &&
            IsHeightValid() &&
            Regex.IsMatch(HairColor, @"^#[a-z0-9]{6}$") &&
            Regex.IsMatch(EyeColor, @"^(amb|blu|brn|gry|grn|hzl|oth)$") &&
            Regex.IsMatch(PassportId, @"^[0-9]{9}$");

        private bool IsHeightValid()
        {
            if (!string.IsNullOrWhiteSpace(Height))
            {
                if (Height.Contains("cm"))
                {
                    return Height.Substring(0, Height.Length - 2).ToInt().IsWithin(150, 193);
                }

                if (Height.Contains("in"))
                {
                    return Height.Substring(0, Height.Length - 2).ToInt().IsWithin(59, 76);
                }
            }

            return false;
        }
    }
}
