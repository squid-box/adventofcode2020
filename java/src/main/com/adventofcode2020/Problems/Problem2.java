package com.adventofcode2020.Problems;

import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem2 extends ProblemBase {
    public Problem2() {
        super(2);
    }

    public void solve() {
        var input = readInputAsStrings();

        System.out.println("2.1: " + solvePartOne(input));
        System.out.println("2.2: " + solvePartTwo(input));
    }

    public static int solvePartOne(List<String> input)
    {
        var count = 0;

        Pattern pattern = Pattern.compile("(?<lowerRange>\\d+)-(?<upperRange>\\d+) (?<target>\\w): (?<password>\\w*)", Pattern.CASE_INSENSITIVE);

        for (var line:
             input) {
            if (line.isEmpty()) {
                continue;
            }

            Matcher matcher = pattern.matcher(line);

            if (!matcher.find())
            {
                System.err.println("Line \"" + line + "\" didn't match regex. We can't go on.");
                return Integer.MIN_VALUE;
            }

            var lowerRange = Integer.parseInt(matcher.group("lowerRange"));
            var upperRange = Integer.parseInt(matcher.group("upperRange"));
            var target = matcher.group("target").substring(0, 1);
            var password = matcher.group("password");

            var targetOccurrences = password.length() - password.replaceAll(target, "").length();

            if (targetOccurrences >= lowerRange &&
                    targetOccurrences <= upperRange)
            {
                count++;
            }
        }

        return count;
    }

    public static int solvePartTwo(List<String> input)
    {
        var count = 0;

        Pattern pattern = Pattern.compile("(?<lowerRange>\\d+)-(?<upperRange>\\d+) (?<target>\\w): (?<password>\\w*)", Pattern.CASE_INSENSITIVE);

        for (var line:
                input) {
            if (line.isEmpty()) {
                continue;
            }

            Matcher matcher = pattern.matcher(line);

            if (!matcher.find())
            {
                System.err.println("Line \"" + line + "\" didn't match regex. We can't go on.");
                return Integer.MIN_VALUE;
            }

            var lowerRange = Integer.parseInt(matcher.group("lowerRange"));
            var upperRange = Integer.parseInt(matcher.group("upperRange"));
            var target = matcher.group("target").charAt(0);
            var password = matcher.group("password");

            var firstPosContainsTarget = password.charAt(lowerRange-1) == target;
            var secondPosContainsTarget = password.charAt(upperRange-1) == target;

            if (firstPosContainsTarget && !secondPosContainsTarget ||
                    secondPosContainsTarget && !firstPosContainsTarget)
            {
                count++;
            }
        }

        return count;
    }
}
