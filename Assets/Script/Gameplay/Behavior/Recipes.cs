using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// A list a recipes the program uses.f
/// In the future, load these from a text file and distinguish between ingredient types (base, dressing, etc.).
public class Recipes
{
    // Roots recipes
    // "Roots Bowl"
    public static List<string> rootsBowl = new List<string>(new string[] {
        "roots rice", // Primary Base
        "spinach", // Secondary Base
        "roasted sweet potatoes", "roasted sweet potatoes", "red onions", "goat cheese", "dried cranberries", // Ingredients
        "lemon tahini" //Dressing
    });

    // "El Jefe"
    public static List<string> elJefe = new List<string>(new string[] {
        "brown rice", // Primary Base
        "kale", // Secondary Base
        "black beans", "charred corn", "red onions", "avocado", "pita chips", "feta", // Ingredients
        "cilantro lime", //Dressing
        "chicken" // From The Grill
    });    

    // "Corner Cobb"
    public static List<string> cornerCobb = new List<string>(new string[] {
        "brown rice", "kale", // etc.
        "roasted broccoli", "red onions", "pickled jalapeños", "red cabbage", "toasted almonds",
        "miso ginger",
        "chicken"
    });

    // Example recipes
    // "Balanced Diet"
    public static List<string> balancedDiet = new List<string>(new string[] {
        "red",
        "blue",
        "red", "green", "green", "blue", "red",
        "green",
        "blue"
    });

    // "Planet Earth"
    public static List<string> planetEarth = new List<string>(new string[] {
        "blue",
        "green",
        "blue", "blue", "green", "red",
        "blue", "red",
        "green"
    });

    // "Rainbow"
    public static List<string> rainbow = new List<string>(new string[] {
        "red",
        "red", "green",
        "green", "green", "blue", "blue", "blue", "red",
        "red", "green", "blue"
    });

}
