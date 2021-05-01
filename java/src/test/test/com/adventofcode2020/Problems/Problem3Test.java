package test.com.adventofcode2020.Problems;

import com.adventofcode2020.Problems.Problem3;
import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class Problem3Test {

    private static final List<String> Input = Arrays.asList(
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#");

    @Test
    void solvePartOne() {
    }

    @Test
    void solvePartTwo() {
    }

    @Test
    public void ParseInput_MapSize() {
        var map = Problem3.parseInputToMap(Input);

        assertEquals(11, map.length);
        assertEquals(11, map[0].length);
    }

    @Test
    public void ParseInput_MapParsing() {
        var map = Problem3.parseInputToMap(Input);

        assertFalse(map[0][0]);
        assertTrue(map[0][1]);
        assertTrue(map[10][10]);
    }
}