package com.adventofcode2020.Problems;

import java.util.List;

public class Problem3 extends ProblemBase {
    public Problem3() {
        super(3);
    }

    @Override
    public void solve() {
        var map = parseInputToMap(readInputAsStrings());

        System.out.println("3.1: " + solvePartOne(map));
        System.out.println("3.2: " + solvePartTwo(map));
    }

    public static Integer solvePartOne(boolean[][] map) {


        return 0;
    }

    public static Integer solvePartTwo(boolean[][] map) {


        return 0;
    }

    public static boolean[][] parseInputToMap(List<String> input)
    {
        var result = new boolean[input.get(0).length()][input.size()];

        for (var y = 0; y < input.size(); y++)
        {
            for (var x = 0; x < input.get(y).length(); x++)
            {
                result[x][y] = input.get(y).charAt(x) == '#';
            }
        }

        return result;
    }
}
