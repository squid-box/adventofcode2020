namespace AdventOfCode2020.Problems
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2020.Utils;
    using AdventOfCode2020.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/17">Day 17</a>.
    /// </summary>
    public class Problem17 : ProblemBase
    {
        public Problem17() : base(17) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            var dimension = new Space(Input.WithoutEmptyLines(), 3);

            dimension.Cycle();

            return dimension.ActiveCubes;
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            var dimension = new Space(Input.WithoutEmptyLines(), 4);

            dimension.Cycle();

            return dimension.ActiveCubes;
        }
    }

    internal class Space
    {
        private readonly int _dimensions;
        private HashSet<Coordinate> _cubes;

        public Space(IList<string> initialState, int dimensions)
        {
            _dimensions = dimensions;
            _cubes = new HashSet<Coordinate>();

            for (var y = 0; y < initialState.Count; y++)
            {
                for (var x = 0; x < initialState[y].Length; x++)
                {
                    if (initialState[y][x].Equals('#'))
                    {
                        _cubes.Add(new Coordinate(x, y, 0, 0));
                    }
                }
            }
        }

        public int ActiveCubes => _cubes.Count;

        public void Cycle()
        {
            for (var n = 0; n < 6; n++)
            {
                var newState = new HashSet<Coordinate>();

                foreach (var coordinate in _cubes)
                {
                    var toCheck = GetNeighbors(coordinate, _dimensions).ToHashSet();
                    toCheck.Add(coordinate);

                    foreach (var c in toCheck)
                    {
                        var activeNeighbors = GetNeighbors(c, _dimensions).Count(coord => _cubes.Contains(coord));

                        if (_cubes.Contains(c) && activeNeighbors.IsWithin(2, 3))
                        {
                            newState.Add(c);
                        }

                        if (!_cubes.Contains(c) && activeNeighbors == 3)
                        {
                            newState.Add(c);
                        }
                    }
                }

                _cubes = newState;
            }
        }

        private static IEnumerable<Coordinate> GetNeighbors(Coordinate coordinate, int dimensions)
        {
            var neighbors3d = new HashSet<Coordinate>
            {
                coordinate + Vector.North,
                coordinate + Vector.West,
                coordinate + Vector.South,
                coordinate + Vector.East,
                coordinate + Vector.North + Vector.West,
                coordinate + Vector.North + Vector.East,
                coordinate + Vector.South + Vector.West,
                coordinate + Vector.South + Vector.East,

                coordinate + Vector.Up,
                coordinate + Vector.Up + Vector.North,
                coordinate + Vector.Up + Vector.West,
                coordinate + Vector.Up + Vector.South,
                coordinate + Vector.Up + Vector.East,
                coordinate + Vector.Up + Vector.North + Vector.West,
                coordinate + Vector.Up + Vector.North + Vector.East,
                coordinate + Vector.Up + Vector.South + Vector.West,
                coordinate + Vector.Up + Vector.South + Vector.East,

                coordinate + Vector.Down,
                coordinate + Vector.Down + Vector.North,
                coordinate + Vector.Down + Vector.West,
                coordinate + Vector.Down + Vector.South,
                coordinate + Vector.Down + Vector.East,
                coordinate + Vector.Down + Vector.North + Vector.West,
                coordinate + Vector.Down + Vector.North + Vector.East,
                coordinate + Vector.Down + Vector.South + Vector.West,
                coordinate + Vector.Down + Vector.South + Vector.East,
            };

            var neighbors4d = new HashSet<Coordinate>(neighbors3d);
            // TODO: should probably rewrite this code...

            return dimensions == 3 ? neighbors3d : neighbors4d;
        }
    }
}
