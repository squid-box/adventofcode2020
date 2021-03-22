package test.com.adventofcode2020.Problems;

import com.adventofcode2020.Problems.Problem2;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.List;

class Problem2Test {

    List<String> input = Arrays.asList("1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc");

    @Test
    void solvePartOne() {
        Assertions.assertEquals(2, Problem2.solvePartOne(input));
    }

    @Test
    void solvePartTwo() {
        Assertions.assertEquals(1, Problem2.solvePartTwo(input));
    }
}