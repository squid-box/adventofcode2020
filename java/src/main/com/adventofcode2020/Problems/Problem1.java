package com.adventofcode2020.Problems;

import java.util.List;

public class Problem1 extends ProblemBase {

    public Problem1() {
        super(1);
    }

    public void solve() {
        var input = readInputAsIntegers();

        if (input == null) {
            System.out.println("Couldn't read input, we're fucked.");
            return;
        }

        System.out.println("1.1: " + findFirst(input, 2020));
        System.out.println("1.2: " + findSecond(input, 2020));
    }

    public static Integer findFirst(List<Integer> input, Integer targetSum) {
        for (var i = 0; i < input.size(); i++) {
            for (var j = 0; j < input.size(); j++) {
                if (i == j) {
                    continue;
                }

                if (input.get(i) + input.get(j) == targetSum) {
                    return input.get(i) * input.get(j);
                }
            }
        }

        return Integer.MIN_VALUE;
    }

    public static int findSecond(List<Integer> input, Integer targetSum) {
        for (var i = 0; i < input.size(); i++) {
            for (var j = 0; j < input.size(); j++) {
                for (var k = 0; k < input.size(); k++) {
                    if (i == j || i == k || j == k) {
                        continue;
                    }

                    if (input.get(i) + input.get(j) + input.get(k) == targetSum) {
                        return input.get(i) * input.get(j) * input.get(k);
                    }
                }
            }
        }

        return Integer.MIN_VALUE;
    }
}
