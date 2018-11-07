package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main{

  public static void main(String a[]) {
    /*
    Create a Fox class with 3 properties(name, type, color).
    Fill a list with at least 5 foxes, it's up to you how you name/create them!
    Write a Stream Expression to find the foxes with green color!
    Write a Stream Expression to find the foxes with green color and pallida type!
    */
    List<Fox> foxes = new ArrayList<>(
        Arrays.asList(
            new Fox("Béla", "macrotis", "green"),
            new Fox("János", "pallida", "green"),
            new Fox("Gizi", "fulvipes", "red"),
            new Fox("Ica", "pallida", "blue"),
            new Fox("Géza", "alopex", "green")
        )
    );

    foxes.stream().filter(f -> f.getColor().equals("green")).forEach(System.out::println);
    System.out.print("\n");
    foxes.stream().filter(f -> f.getColor().equals("green") && f.getType().equals("pallida")).forEach(System.out::println);
  }
}
class Fox {
  private String name;
  private String type;
  private String color;

  public Fox(String name, String type, String color) {
    this.name = name;
    this.type = type;
    this.color = color;
  }

  public String getName() {
    return name;
  }

  public void setName(String name) {
    this.name = name;
  }

  public String getType() {
    return type;
  }

  public void setType(String type) {
    this.type = type;
  }

  public String getColor() {
    return color;
  }

  public void setColor(String color) {
    this.color = color;
  }

  @Override
  public String toString() {
    return "name: " + this.name + ", type: " + this.type + ", color: " + this.color;
  }
}