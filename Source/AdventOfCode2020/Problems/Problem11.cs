namespace AdventOfCode2020.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2020.Utils;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/11">Day 11</a>.
    /// </summary>
    public class Problem11 : ProblemBase
    {
        public Problem11() : base(11) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            return FindPartOne(Input);
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            return FindPartTwo(Input);
        }

        internal static int FindPartOne(IEnumerable<string> input)
        {
            var seating = new Seating(input.ToList());
            seating.ExecuteRulesUntilEquilibrium();

            return seating.OccupiedSeats;
        }

        internal static int FindPartTwo(IEnumerable<string> input)
        {
            var seating = new Seating(input.ToList());
            seating.ExecuteNewRulesUntilEquilibrium();

            return seating.OccupiedSeats;
        }
    }

    internal class Seating
    {
        private readonly int _width;
        private readonly int _height;

        private readonly List<Vector> _directions = new List<Vector>
        {
            Vector.Up,
            Vector.Down,
            Vector.Left,
            Vector.Left + Vector.Up,
            Vector.Left + Vector.Down,
            Vector.Right,
            Vector.Right + Vector.Up,
            Vector.Right + Vector.Down,
        };

        private char [,] _positions;

        public Seating(IList<string> input)
        {
            _width = input[0].Length;
            _height = input.Count;
            _positions = new char[_width, _height];

            for (var y = 0; y < _height; y++)
            {
                var line = input[y].ToCharArray();

                for (var x = 0; x < _width; x++)
                {
                    _positions[x, y] = line[x];
                }
            }
        }

        public int OccupiedSeats
        {
            get
            {
                var sum = 0;

                for (var y = 0; y < _height; y++)
                {
                    for (var x = 0; x < _width; x++)
                    {
                        if (_positions[x, y].Equals('#'))
                        {
                            sum++;
                        }
                    }
                }

                return sum;
            }
        }

        public void ExecuteRulesUntilEquilibrium()
        {
            var changed = true;

            while (changed)
            {
                changed = ExecuteRules(FirstRules);
            }
        }
        
        public void ExecuteNewRulesUntilEquilibrium()
        {
            var changed = true;

            while (changed)
            {
                changed = ExecuteRules(SecondRules);
            }
        }

        public bool ExecuteRules(Func<char[,], int, int, bool> rules)
        {
            var newPositions = (char[,])_positions.Clone();

            var changed = false;

            for (var x = 0; x < _width; x++)
            {
                for (var y = 0; y < _height; y++)
                {
                    if (rules(newPositions, x, y))
                    {
                        changed = true;
                    }
                }
            }

            _positions = newPositions;

            return changed;
        }

        private bool FirstRules(char[,] newPositions, int x, int y)
        {
            var position = GetSeat(x, y);
            // Ignore floors
            if (position.Equals('.'))
            {
                return false;
            }

            var occupiedNeighbors = GetNeighbors(x, y).Count(pos => pos.Equals('#'));

            if (position.Equals('L') && occupiedNeighbors == 0)
            {
                newPositions[x, y] = '#';
                return true;
            }

            if (position.Equals('#') && occupiedNeighbors >= 4)
            {
                newPositions[x, y] = 'L';
                return true;
            }

            return false;
        }

        private bool SecondRules(char[,] newPositions, int x, int y)
        {
            var position = GetSeat(x, y);
            // Ignore floors
            if (position.Equals('.'))
            {
                newPositions[x, y] = position;
                return false;
            }

            var occupiedNeighbors = GetLineOfSightNeighbors(x, y).Count(pos => pos.Equals('#'));

            if (position.Equals('L') && occupiedNeighbors == 0)
            {
                newPositions[x, y] = '#';
                return true;
            }

            if (position.Equals('#') && occupiedNeighbors >= 5)
            {
                newPositions[x, y] = 'L';
                return true;
            }

            return false;
        }

        public char GetSeat(int x, int y)
        {
            return _positions[x,y];
        }

        public IEnumerable<char> GetNeighbors(int x, int y)
        {
            var result = new List<char>();

            for (var neighborY = y - 1; neighborY <= y + 1; neighborY++)
            {
                if (neighborY < 0 || neighborY >= _height)
                {
                    continue;
                }

                for (var neighborX = x - 1; neighborX <= x + 1; neighborX++)
                {
                    if (neighborX < 0 || neighborX >= _width || neighborX == x && neighborY == y)
                    {
                        continue;
                    }

                    result.Add(GetSeat(neighborX, neighborY));
                }
            }

            return result;
        }

        public IEnumerable<char> GetLineOfSightNeighbors(int x, int y)
        {
            return _directions.Select(direction => FindNextVisibleNeighbor(x, y, direction)).ToList();
        }

        private char FindNextVisibleNeighbor(int x, int y, Vector vector)
        {
            var neighborX = x + vector.X;
            var neighborY = y + vector.Y;

            while (neighborX >= 0 && neighborX < _width && neighborY >= 0 && neighborY < _height)
            {
                var seat = GetSeat(neighborX, neighborY);

                if (!seat.Equals('.'))
                {
                    return seat;
                }

                neighborX += vector.X;
                neighborY += vector.Y;
            }

            return '.';
        }
    }
}
