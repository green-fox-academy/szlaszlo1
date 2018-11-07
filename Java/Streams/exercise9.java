package com.company;

import java.util.Arrays;
import java.util.stream.Collectors;

public class Main{

  public static void main(String a[]) {
    //Write a Stream Expression to convert a char array to a string!
    Character[] characters = {'T','u',' ','S','a'};
    String concat = Arrays.stream(characters).map(c -> c.toString()).collect(Collectors.joining(""));
    System.out.println(concat);
  }
}
