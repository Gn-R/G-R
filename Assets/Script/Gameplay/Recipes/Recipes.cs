using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private static readonly Recipe blankRecipe = new Recipe(
        "Blank Recipe", // Name
        new string[] {"Nothing"}, // Base(s)
        new string[] {}, // Topping(s)
        new string[] {}, // Dressing(s)
        new string[] {} // From the Grill (protein)
    );

    // Store All Recipes

    private static readonly Recipe[] allRecipes = CrispRecipes.allCrispRecipes;
    // private static readonly Recipe[] allRecipes = RootsRecipes.allRootsRecipes;

}
