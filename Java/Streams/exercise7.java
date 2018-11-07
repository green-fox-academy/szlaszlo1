package com.company;

import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public class Main{

  public static void main(String a[]) {
    //Write a Stream Expression to find the frequency of characters in a given string!
    String sentece = "This is my test text.";
    Map<Character, Long> frequency = sentece.chars().mapToObj(c-> (char)c).collect(Collectors.groupingBy(Function.identity(), Collectors.counting()));
    for (Character character : frequency.keySet()) {
      System.out.println(character + " : " + frequency.get(character));
    }
  }
}
