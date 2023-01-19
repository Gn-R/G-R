using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Internal class to store a list of ingredients
public class Recipe
{
    public readonly string name; // name of dish
    public readonly List<string> ingredients; // ingredients list
    private int currentLevel = 1;
    private int progress = 0;

    public Recipe(string name, params string[] ingredients)
    {
        this.name = name;
        this.ingredients = new List<string>(ingredients);
    }

    // Copy of ingredients
    public List<string> GetIngredients()
    {
        return new List<string>(ingredients);
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void IncreaseLevel()
    {
        currentLevel++;
        progress = 0;
    }

    public int GetProgress()
    {
        return progress;
    }
}

// A list a recipes the program uses.f
// In the future, load these from a text file and distinguish between ingredient types (base, dressing, etc.).
public class Recipes
{

    
    public static string GetRandomDish()
    {
        int rand = Random.Range(0, allRecipes.Length); 
        return allRecipes[rand].name;
    }

    public static Recipe GetRecipe(string dish)
    {
        // Search for a recipe
        foreach (Recipe r in allRecipes)
        {
            if (r.name.Equals(dish))
            {
                return r;
            }
        }
        return rootsBowl; // default in case bad name entered
    }

    // Roots Recipes

    private static readonly Recipe rootsBowl = new Recipe(
        "Roots Bowl",
        "Roots Rice", // Primary Base
        "Spinach", // Secondary Base
        "Roasted Sweet Potatoes", "Roasted Sweet Potatoes", "Red Onions", "Goat Cheese", "Dried Cranberries", // Ingredients
        "Lemon Tahini" //Dressing
    );

    private static readonly Recipe elJefe = new Recipe(
        "El Jefe",
        "Brown Rice", // Primary Base
        "Kale", // Secondary Base
        "Black Beans", "Charred Corn", "Red Onions", "Avocado", "Pita Chips", "Feta", // Ingredients
        "Cilantro Lime", //Dressing
        "Chicken" // From The Grill
    );

    private static readonly Recipe cornerCobb = new Recipe(
        "Corner Cobb",
        "Arcadian Mix", //Primeary Base
        "Roots Rice", "Kale", //Secondary Base
        "Roasted Broccoli", "Red Onions", "Pickled Jalapeños", "Red Cabbage", "Toasted Almonds", //Ingredients
        "Miso Ginger", //Dressing
        "Chicken" //From the Grill
    );

    private static readonly Recipe mayweather = new Recipe(
        "Mayweather",
        "Kale", //Primary Base
        "Bulgur", //Secondary Base
        "Roasted Sweet Potatoes", "Roasted Beets", "Red Onions", "Goat Cheese", "Avocado", //Ingredients    
        "Lemon Tahini", "Pesto Vinaigrette", //Dressing
        "Chicken" //From the Grill
    );

    private static readonly Recipe pestoCaesar = new Recipe(
        "Pesto Caesar",
        "Kale", //Primary Base
        "Bulgur", //Secondary Base
        "Grape Tomatoes", "Pita Chips", "Lime-Pickled Onions, Shaved Parmesan", //Ingredients
        "Pesto Vinaigrette", "Caesar", //Dressing
        "Chicken" //From the Grill
    );

    private static readonly Recipe tamari = new Recipe(
        "Tamari",
        "Brown Rice", "Kale", //Primary Base
        "Roasted Broccoli", "Red Onion", "Carrots", "Pickled Jalapenos", "Red Cabbage", "Toasted Almonds", //Ingredients
        "Miso Ginger", //Dressing
        "Red Chili Miso Tofu" //From the Grill
    );

    private static readonly Recipe madBowl = new Recipe(
        "Mad Bowl",
        "Brown Rice", //Primary Base
        "Spinach", //Secondary Base
        "Cannellini Beans", "Roasted Broccoli", "Cucumbers", "Grape Tomatoes", "Red Onions", "Shaved Parmesan", //Ingredients
        "Pesto Vinaigrette", "Basil Balsamic", //Dressing
        "Mushrooms" //From the Grill
    );

    private static readonly Recipe theApollo = new Recipe(
        "The Apollo",
        "Brown Rice", //Primary Base
        "Kale", //Secondary Base
        "Black Beans", "Charred Corn", "Red Onions", "Avocado", "Pita Chips", "Feta", //Ingredients
        "Cilantro Lime", //Dressing
        "Chicken" //From the Grill
    );

    private static readonly Recipe theSouthern = new Recipe(
        "The Southern",
        "Roots Rice", //Primary Base
        "Kale", //Secondary Base
        "Chickpeas", "Roasted Broccoli", "Charred Corn", "Lime-Pickled Onions", "Cheddar", //Ingredients
        "Lemon Tahini", //Dressing
        "BBQ Tofu" //From the Grill
    );

    private static readonly Recipe theBalboa = new Recipe(
        "The Balboa",
        "Brown Rice", //Primary Base
        "Roasted Sweet Potatoes", "Charred Corn", "Avocado", "Pita Chips", "Feta", "Lime-Pickled Onions", //Ingredients
        "Lemon Tahini", "Caesar", "Frank's Red Hot", //Dressing
        "Chicken" //From the Grill
    );

    // Store All Recipes

    private static readonly Recipe[] allRecipes = {
        rootsBowl, elJefe, cornerCobb, mayweather, pestoCaesar,
        tamari, madBowl, theApollo, theSouthern, theBalboa
        // balancedDiet, planetEarth, rainbow
    };

    // Example/Debug Recipes

    // private static readonly Recipe balancedDiet = new Recipe(
    //     "Balanced Diet",
    //     "Red",
    //     "Blue",
    //     "Red", "Green", "Green", "Blue", "Red",
    //     "Green",
    //     "Blue"
    // );

    // private static readonly Recipe planetEarth = new Recipe(
    //     "Planet Earth",
    //     "Blue",
    //     "Green",
    //     "Blue", "Blue", "Green", "Red",
    //     "Blue", "Red",
    //     "Green"
    // );


    // private static readonly Recipe rainbow = new Recipe(
    //     "The Rainbow",
    //     "Red",
    //     "Red", "Green",
    //     "Green", "Green", "Blue", "Blue", "Blue", "Red",
    //     "Red", "Green", "Blue"
    // );

}
