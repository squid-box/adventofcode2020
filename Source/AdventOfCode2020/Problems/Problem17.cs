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
        private HashSet<Vector> _neighborVectors;

        public Space(IList<string> initialState, int dimensions)
        {
            _dimensions = dimensions;
            _cubes = new HashSet<Coordinate>();
            _neighborVectors = GetNeighborDirections(dimensions);

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

        public void Cycle(int cycles = 6)
        {
            for (var n = 0; n < cycles; n++)
            {
                var newState = new HashSet<Coordinate>();

                foreach (var coordinate in _cubes)
                {
                    var toCheck = GetNeighbors(coordinate);
                    toCheck.Add(coordinate);

                    foreach (var c in toCheck)
                    {
                        var activeNeighbors = GetNeighbors(c).Count(coord => _cubes.Contains(coord));

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

        private HashSet<Coordinate> GetNeighbors(Coordinate coord)
        {
            var result = new HashSet<Coordinate>();

            foreach (var direction in _neighborVectors)
            {
                result.Add(coord + direction);
            }

            return result;
        }

        private static HashSet<Vector> GetNeighborDirections(int dimensions)
        {
            var neighbors = new HashSet<Vector>();

            for (var x = -1; x <= 1; x++)
            {
                for (var y = -1; y <= 1; y++)
                {
                    for (var z = -1; z <= 1; z++)
                    {
                        if (dimensions == 4)
                        {
                            for (var w = -1; w <= 1; w++)
                            {
                                if (x == 0 && y == 0 && z == 0 && w == 0)
                                {
                                    continue;
                                }
                                neighbors.Add(new Vector(x, y, z, w));
                            }
                        }
                        else
                        {
                            if (x == 0 && y == 0 && z == 0)
                            {
                                continue;
                            }
                            neighbors.Add(new Vector(x, y, z));
                        }
                    }
                }
            }
            
            return neighbors;
        }
    }
}
