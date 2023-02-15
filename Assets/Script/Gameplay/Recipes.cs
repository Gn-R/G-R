using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A list a recipes the program uses.
// In the future, load these from a CSV file
public class Recipes
{
    public static string GetRandomDish()
    {
        int rand = Random.Range(0, allRecipes.Length); 
        return allRecipes[rand].name;
    }

    public static Recipe GetRecipe(string dishName)
    {
        // Search for a recipe
        foreach (Recipe r in allRecipes)
        {
            if (r.name.ToLower().Equals(dishName.ToLower())) return r;
        }
        return blankRecipe; // empty recipe if bad name entered
    }

    public static float GetTotalProgress()
    {
        int numRecipes = allRecipes.Length;
        float avgProgress = 0f;
        foreach (Recipe r in allRecipes)
        {
            avgProgress += r.GetProgress();
        }
        return avgProgress / numRecipes;
    }

    // Roots Recipes

    private static readonly Recipe blankRecipe = new Recipe(
        "Blank Recipe", // Name
        new string[] {"Nothing"}, // Base(s)
        new string[] {}, // Topping(s)
        new string[] {}, // Dressing(s)
        new string[] {} // From the Grill (protein)
    );

    private static readonly Recipe cornerCobb = new Recipe(
        "Corner Cobb",
        new string[] {"Arcadian Mix", "Roots Rice", "Kale"},
        new string[] {"Roasted Broccoli", "Red Onions", "Pickled Jalapeños", "Red Cabbage", "Toasted Almonds"},
        new string[] {"Miso Ginger"},
        new string[] {"Chicken"}
    );

    private static readonly Recipe elJefe = new Recipe(
        "El Jefe",
        new string[] {"Brown Rice", "Kale"},
        new string[] {"Black Beans", "Charred Corn", "Red Onions", "Avocado", "Pita Chips", "Feta"},
        new string[] {"Cilantro Lime"},
        new string[] {"Chicken"}
    );

    private static readonly Recipe mayweather = new Recipe(
        "Mayweather",
        new string[] {"Kale", "Bulgur"},
        new string[] {"Roasted Sweet Potatoes", "Roasted Beets", "Red Onions", "Goat Cheese", "Avocado"},    
        new string[] {"Lemon Tahini", "Pesto Vinaigrette"},
        new string[] {"Chicken"}
    );

    private static readonly Recipe pestoCaesar = new Recipe(
        "Pesto Caesar",
        new string[] {"Kale", "Bulgur"},
        new string[] {"Grape Tomatoes", "Pita Chips", "Lime-Pickled Onions, Shaved Parmesan"},
        new string[] {"Pesto Vinaigrette", "Caesar"},
        new string[] {"Chicken"}
    );

    private static readonly Recipe rootsBowl = new Recipe(
        "Roots Bowl",
        new string[] {"Roots Rice", "Spinach"},
        new string[] {"Roasted Sweet Potatoes", "Roasted Sweet Potatoes", "Red Onions", "Goat Cheese", "Dried Cranberries"},
        new string[] {"Lemon Tahini"},
        new string[] {}
    );

    private static readonly Recipe tamari = new Recipe(
        "Tamari",
        new string[] {"Brown Rice", "Kale"},
        new string[] {"Roasted Broccoli", "Red Onion", "Carrots", "Pickled Jalapenos", "Red Cabbage", "Toasted Almonds"},
        new string[] {"Miso Ginger"},
        new string[] {"Red Chili Miso Tofu"}
    );

    private static readonly Recipe theApollo = new Recipe(
        "The Apollo",
        new string[] {"Brown Rice", "Kale"},
        new string[] {"Black Beans", "Charred Corn", "Red Onions", "Avocado", "Pita Chips", "Feta"},
        new string[] {"Cilantro Lime"},
        new string[] {"Chicken"}
    );

    private static readonly Recipe theBalboa = new Recipe(
        "The Balboa",
        new string[] {"Brown Rice"},
        new string[] {"Roasted Sweet Potatoes", "Charred Corn", "Avocado", "Pita Chips", "Feta", "Lime-Pickled Onions"},
        new string[] {"Lemon Tahini", "Caesar", "Frank's Red Hot"},
        new string[] {"Chicken"}
    );

    private static readonly Recipe theLola = new Recipe(
        "The Lola", // is this supposed to be the Mad Bowl?
        new string[] {"Brown Rice", "Spinach"},
        new string[] {"Cannellini Beans", "Roasted Broccoli", "Cucumbers", "Grape Tomatoes", "Red Onions", "Shaved Parmesan"},
        new string[] {"Pesto Vinaigrette", "Basil Balsamic"},
        new string[] {"Mushrooms"}
    );

    private static readonly Recipe theSouthern = new Recipe(
        "The Southern",
        new string[] {"Roots Rice", "Kale"},
        new string[] {"Chickpeas", "Roasted Broccoli", "Charred Corn", "Lime-Pickled Onions", "Cheddar"},
        new string[] {"Lemon Tahini"},
        new string[] {"BBQ Tofu"}
    );

    // Store All Recipes

    private static readonly Recipe[] allRecipes = {
        cornerCobb, elJefe, mayweather, pestoCaesar, rootsBowl,
        tamari, theApollo, theBalboa, theLola, theSouthern
    };

}
