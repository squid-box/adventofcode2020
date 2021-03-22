package test.com.adventofcode2020.Problems;

import com.adventofcode2020.Problems.Problem1;
import org.junit.jupiter.api.Assertions;

import java.util.Arrays;
import java.util.List;

public class Problem1Test {

    List<Integer> input = Arrays.asList(1721, 979, 366, 299, 675, 1456);

    @org.junit.jupiter.api.Test
    void findFirst() {
        Assertions.assertEquals(514579, Problem1.findFirst(input, 2020));
    }

    @org.junit.jupiter.api.Test
    void findSecond() {
        Assertions.assertEquals(241861950, Problem1.findSecond(input, 2020));
    }
}