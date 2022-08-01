using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A list a recipes the program uses.f
// In the future, load these from a text file and distinguish between ingredient types (base, dressing, etc.).
public class Recipes
{
    // Roots recipes
    // "Roots Bowl"
    public static List<string> rootsBowl = new List<string>(new string[] {
        "Roots Rice", // Primary Base
        "Spinach", // Secondary Base
        "Roasted Sweet Potatoes", "Roasted Sweet Potatoes", "Red Onions", "Goat Cheese", "Dried Cranberries", // Ingredients
        "Lemon Tahini" //Dressing
    });

    // "El Jefe"
    public static List<string> elJefe = new List<string>(new string[] {
        "Brown Rice", // Primary Base
        "Kale", // Secondary Base
        "Black Beans", "Charred Corn", "Red Onions", "Avocado", "Pita Chips", "Feta", // Ingredients
        "Cilantro Lime", //Dressing
        "Khicken" // From The Grill
    });

    // "Corner Cobb"
    public static List<string> cornerCobb = new List<string>(new string[] {
        "Brown Rice", "Kale", // etc.
        "Roasted Broccoli", "Red Onions", "Pickled Jalapeños", "Red Cabbage", "Toasted Almonds",
        "Miso Ginger",
        "Chicken"
    });

    // Example recipes
    // "Balanced Diet"
    public static List<string> balancedDiet = new List<string>(new string[] {
        "Red",
        "Blue",
        "Red", "Green", "Green", "Blue", "Red",
        "Green",
        "Blue"
    });

    // "Planet Earth"
    public static List<string> planetEarth = new List<string>(new string[] {
        "Blue",
        "Green",
        "Blue", "Blue", "Green", "Red",
        "Blue", "Red",
        "Green"
    });

    // "Rainbow"
    public static List<string> rainbow = new List<string>(new string[] {
        "Red",
        "Red", "Green",
        "Green", "Green", "Blue", "Blue", "Blue", "Red",
        "Red", "Green", "Blue"
    });

}
