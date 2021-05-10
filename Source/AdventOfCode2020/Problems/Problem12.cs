namespace AdventOfCode2020.Problems
{
    using System.Collections.Generic;
    using AdventOfCode2020.Utils;
    using AdventOfCode2020.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/12">Day 12</a>.
    /// </summary>
    public class Problem12 : ProblemBase
    {
        public Problem12() : base(12) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            return FindPartOne(Input.WithoutEmptyLines());
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            return FindPartTwo(Input.WithoutEmptyLines());
        }

        internal static int FindPartOne(IEnumerable<string> input)
        {
            var origin = Coordinate.Zero;
            var ship = new Ship(origin);

            foreach (var maneuver in input)
            {
                ship.ExecuteManeuver(maneuver);
            }

            return Coordinate.ManhattanDistance(origin, ship.CurrentPosition);
        }

        internal static int FindPartTwo(IEnumerable<string> input)
        {
            var origin = Coordinate.Zero;
            var ship = new Ship(origin);

            foreach (var maneuver in input)
            {
                ship.ExecuteActualManeuver(maneuver);
            }

            return Coordinate.ManhattanDistance(origin, ship.CurrentPosition);
        }
    }

    internal class Ship
    {
        private int _currentDirection;

        private Vector _wayPoint;

        public Ship(Coordinate startingPosition, int startingDirection = 90)
        {
            CurrentPosition = startingPosition;
            CurrentDirection = startingDirection;
            _wayPoint = new Vector(10, 1);
        }

        public Coordinate CurrentPosition { get; private set; }

        public int CurrentDirection
        {
            get => _currentDirection;

            set
            {
                _currentDirection = value % 360;

                if (_currentDirection == 360)
                {
                    CurrentDirection = 0;
                }

                if (_currentDirection < 0)
                {
                    CurrentDirection += 360;
                }
            }
        }

        public void ExecuteManeuver(string maneuver)
        {
            var val = maneuver[1..].ToInt();
            Vector direction = null;

            switch (maneuver[0])
            {
                case 'N':
                    direction = Vector.North * val;
                    break;
                case 'S':
                    direction = Vector.South * val;
                    break;
                case 'E':
                    direction = Vector.East * val;
                    break;
                case 'W':
                    direction = Vector.West * val;
                    break;
                case 'L':
                    CurrentDirection -= val;
                    return;
                case 'R':
                    CurrentDirection += val;
                    return;
                case 'F':
                    direction = CurrentDirection switch
                    {
                        0 => Vector.North * val,
                        90 => Vector.East * val,
                        180 => Vector.South * val,
                        270 => Vector.West * val,
                        _ => null
                    };
                    break;
            }

            CurrentPosition += direction;
        }

        public void ExecuteActualManeuver(string maneuver)
        {
            var val = maneuver[1..].ToInt();
            
            switch (maneuver[0])
            {
                case 'N':
                    _wayPoint += new Vector(0, val);
                    break;
                case 'S':
                    _wayPoint += new Vector(0, -val);
                    break;
                case 'E':
                    _wayPoint += new Vector(val, 0);
                    break;
                case 'W':
                    _wayPoint += new Vector(-val, 0);
                    break;
                case 'L':
                    for (var i = 0; i < val / 90; i++)
                    {
                        _wayPoint = new Vector(-_wayPoint.Y, _wayPoint.X);
                    }

                    return;
                case 'R':
                    for (var i = 0; i < val / 90; i++)
                    {
                        _wayPoint = new Vector(_wayPoint.Y, -_wayPoint.X);
                    }
                    return;
                case 'F':
                    CurrentPosition += _wayPoint * val;
                    break;
            }
        }
    }
}
