namespace AdventOfCode2020.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/22">Day 22</a>.
    /// </summary>
    public class Problem22 : ProblemBase
    {
        public Problem22() : base(22) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            return FindWinnerScore(Input);
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            return "Unsolved";
        }

        public static long FindWinnerScore(IEnumerable<string> input)
        {
            var (playerOneDeck, playerTwoDeck) = ParseInput(input.ToList());

            while (playerOneDeck.Count > 0 && playerTwoDeck.Count > 0)
            {
                var playerOneCard = playerOneDeck[0];
                playerOneDeck.RemoveAt(0);
                var playerTwoCard = playerTwoDeck[0];
                playerTwoDeck.RemoveAt(0);

                if (playerOneCard > playerTwoCard)
                {
                    playerOneDeck.Add(playerOneCard);
                    playerOneDeck.Add(playerTwoCard);
                }
                else
                {
                    playerTwoDeck.Add(playerTwoCard);
                    playerTwoDeck.Add(playerOneCard);
                }
            }
            
            return CalculateScore(playerOneDeck.Count == 0 ? playerTwoDeck : playerOneDeck);
        }

        public static long CalculateScore(IList<int> deck)
        {
            var modifier = deck.Count;

            return deck.Sum(card => card * modifier--);
        }

        public static (IList<int> playerOneDeck, IList<int> playerTwoDeck) ParseInput(IEnumerable<string> input)
        {
            var inputList = input.ToList();
            var splitIndex = inputList.FindIndex(s => s.Equals("Player 2:", StringComparison.OrdinalIgnoreCase));

            return (inputList.Skip(1).Take(splitIndex - 2).Select(int.Parse).ToList(), inputList.Skip(splitIndex + 1).Select(int.Parse).ToList());
        }
    }
}
