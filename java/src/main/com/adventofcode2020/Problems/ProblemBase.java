package com.adventofcode2020.Problems;

import java.io.IOException;
import java.net.URISyntaxException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;

public abstract class ProblemBase {

    private final Integer _day;

    public ProblemBase(Integer day) {
        _day = day;
    }

    public Integer get_day() {
        return _day;
    }

    public abstract void solve();

    public List<Integer> readInputAsIntegers() {
        var result = new ArrayList<Integer>();
        var input = readInputAsStrings();

        if (input == null) {
            return null;
        }

        for (var number : input
        ) {
            if (!number.isEmpty()) {
                try {
                    result.add(Integer.parseInt(number));
                } catch (NumberFormatException n) {
                    System.err.println("Could not convert \"" + number + "\" to an Integer.");
                    return null;
                }
            }
        }

        return result;
    }

    public List<String> readInputAsStrings() {
        try {
            var classLoader = getClass().getClassLoader();
            return Files.readAllLines(Paths.get(classLoader.getResource(_day + ".input").toURI()));
        } catch (IOException | URISyntaxException ex) {
            System.err.println("Got exception " + ex.getClass() + ": " + ex.getMessage());
            return null;
        }
    }
}
