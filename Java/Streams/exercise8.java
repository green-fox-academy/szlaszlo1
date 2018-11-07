package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public class Main{

  public static void main(String a[]) {
    //Write a Stream Expression to find the frequency of numbers in the following array:
    ArrayList<Integer> numbers = new ArrayList<>(Arrays.asList(5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2));
    Map<Integer, Long> freq = numbers.stream().collect(Collectors.groupingBy(Function.identity(), Collectors.counting()));
    for (Integer key: freq.keySet()) {
      System.out.println(key + " " + freq.get(key));
    }
  }
}
