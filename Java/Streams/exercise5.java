package com.company;

public class Main{

  public static void main(String a[]) {
    //Write a Stream Expression to find which number squared value is more then 20 from the following array:
    String sentece = "This is mY teSt TeXt";
    sentece.chars().filter(c -> Character.toUpperCase(c)==c && c != 32).mapToObj(l -> (char)l).forEach(System.out::println);
  }
}
