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

    // Recipes

    private static readonly Recipe blankRecipe = new Recipe(
        "Blank Recipe", // Name
        new string[] { "Nothing" }, // Base(s)
        new string[] { }, // Topping(s)
        new string[] { }, // Dressing(s)
        new string[] { } // From the Grill (protein)
    );

    private static readonly Recipe GRBowl1 = new Recipe(
        "G & R Bowl 1", 
        new string[] { "Sweet Potatoes", "Cabbage" }, // Base(s)
        new string[] { "Goat Cheese", "Spring Mix", "Chicken" }, // Topping(s)
        new string[] { "Caesar Dressing" }, // Dressing(s)
        new string[] { } // From the Grill (protein)
    );

    private static readonly Recipe GRBowl2 = new Recipe(
        "G & R Bowl 2", 
        new string[] { "Shredded Carrots", "Corn" }, // Base(s)
        new string[] { "Cucumbers", "Red Onion", "Pickled Onions", "Parmesan", "Spring Mix" }, // Topping
        new string[] { "Caesar Dressing" }, // Dressing(s)
        new string[] { "Chicken" } // From the Grill (protein)
    );

    private static readonly Recipe baja = new Recipe(
        "Baja", 8.79,
        new string[] { "Romaine", "Grape Tomatoes", },
        new string[] { "Pickled Red Onions", "Charred Corn", "Black Beans", "Tortilla Strips", "Sharp Cheddar Cheese" },
        new string[] { "Chipotle Ranch Dressing" },
        new string[] { }
    );

    private static readonly Recipe classicCaesar = new Recipe(
        "Classic Caesar", 7.49,
        new string[] { "Romaine", "Garlic Croutons" },
        new string[] { "Shaved Parmesan" },
        new string[] { "Creamy Caesar Dressing" },
        new string[] { }
    );

    private static readonly Recipe greekGarden = new Recipe(
        "Greek Garden", 8.79,
        new string[] { "Romaine / Spring", "Cucumbers" },
        new string[] { "Grape Tomatoes", "Red Onions", "Kalamata Olives", "Banana Peppers", "Crumbled Feta Cheese" },
        new string[] { "House Greek Vinaigrette Dressing" },
        new string[] { }
    );

    private static readonly Recipe thai = new Recipe(
        "Thai", 7.99,
        new string[] { "Romaine/Spring", "Cucumbers", "Shredded Carrots" },
        new string[] { "Shredded Red Cabbage", "Edamame", "Crunchy Noodles" },
        new string[] { "Thai Peanut Ginger Dressing" },
        new string[] { }
    );

    private static readonly Recipe crispCobb = new Recipe(
        "Crisp Cobb", 9.79,
        new string[] { "Romaine", "Grape Tomatoes", "Hard-Boiled Egg" },
        new string[] { "Crumbled Blue Cheese", "Grilled Chicken", "Crumbled Bacon" },
        new string[] { "Blue Cheese or Buttermilk Ranch Dressing" },
        new string[] { }
    );

    private static readonly Recipe tamari = new Recipe(
        "Moroccan", 9.49,
        new string[] { "Romaine/Spring", "Cucumbers", "Shredded Carrots" },
        new string[] { "Golden Raisins", "Crumbled Feta Cheese", "Falafel" },
        new string[] { "House Greek Vinaigrette Dressing" },
        new string[] { }
    );

    private static readonly Recipe steakhouse = new Recipe(
        "Steakhouse", 10.49,
        new string[] { "Romaine/Spinach", "Grape Tomatoes", "Crispy Fried Onions" },
        new string[] { "Crumbled Blue Cheese", "Sirloin Steak" },
        new string[] { "Honey Dijon Dressing" },
        new string[] { }
    );

    private static readonly Recipe superfood = new Recipe(
        "Superfood", 8.49,
        new string[] { "Romaine/Spinach/Kale", "Shredded Carrots", "Organic Quinoa" },
        new string[] { "Roasted Sweet Potatoes", "Roasted Beets", "Chopped Apples", "Sunflower Seeds" },
        new string[] { "Apple Cider Vinaigrette Dressing" },
        new string[] { }
    );

    private static readonly Recipe seaBoy = new Recipe(
        "Sea Boy", 10.49,
        new string[] { "Romaine/Spring", "Cucumbers", "Grape Tomatoes", "Charred Corn" },
        new string[] { "Crispy Fried Onions", "Sautéed Shrimp" },
        new string[] { "Honey Dijon Dressing" },
        new string[] { }
    );

    private static readonly Recipe bbqAndBlue = new Recipe(
        "BBQ & Blue", 9.79,
        new string[] { "Romaine/Spring/Kale", "Strawberries", "Sunflower Seeds" },
        new string[] { "Crumbled Blue Cheese", "Grilled Chicken", "Crumbled Bacon" },
        new string[] { "Honey BBQ Vinaigrette Dressing" },
        new string[] { }
    );

    private static readonly Recipe pestoCaesarGrainBowl = new Recipe(
        "Pesto Caesar Grain Bowl", 8.99,
        new string[] { "Spinach", "Brown Rice", "Organic Quinoa", "Grape Tomatoes" },
        new string[] { "Shaved Parmesan", "Grilled Chicken" },
        new string[] { "Pesto Caesar Dressing" },
        new string[] { }
    );

    private static readonly Recipe harvestGrainBowl = new Recipe(
        "Harvest Grain Bowl", 7.99,
        new string[] { "Spinach", "Brown Rice", "Organic Quinoa" },
        new string[] { "Roasted Sweet Potatoes", "Roasted Beets", "Chopped Apples", "Sunflower Seeds" },
        new string[] { "Pesto Caesar Dressing" },
        new string[] { }
    );

    private static readonly Recipe zenGrainBowl = new Recipe(
        "Zen Grain Bowl", 7.99,
        new string[] { "Spinach", "Organic Quinoa", "Shredded Carrots" },
        new string[] { "Shredded Red Cabbage", "Edamame", "Crunchy Noodles" },
        new string[] { "Asian Sesame Dressing" },
        new string[] { }
    );

    // Store All Recipes

    private static readonly Recipe[] allRecipes = {
        GRBowl1, GRBowl2, baja, classicCaesar, greekGarden, thai, crispCobb, tamari, steakhouse, superfood, seaBoy, bbqAndBlue, pestoCaesarGrainBowl,
        harvestGrainBowl, zenGrainBowl
    };

}
