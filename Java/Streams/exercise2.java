package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.OptionalDouble;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

public class Main{

  public static void main(String a[]) {
    //Write a Stream Expression to get the average value of the odd numbers from the following array:
    ArrayList<Integer> numbers = new ArrayList<>(Arrays.asList(1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14));
    double avg = numbers.stream().filter(n -> Math.abs(n % 2) == 0).mapToInt(i -> i).average().getAsDouble();
    System.out.println(avg);
  }
}
