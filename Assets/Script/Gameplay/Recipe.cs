using System.Collections;
using System.Collections.Generic;

// Stores a list of ingredients
public class Recipe
{
    // Ingredients
    public readonly string name; // name of dish
    public readonly string[] bases, toppings, dressing, grill; // ingredients list + category

    // Levels
    private static int maxLevel = 3;
    private int levelsCompleted = 0;

    private double cost = 0;

    public Recipe(string name, double cost, string[] bases, string[] toppings, string[] dressing, string[] grill) : this(name, bases, toppings, dressing, grill)
    {
        this.cost = cost;
    }

    public Recipe(string name, string[] bases, string[] toppings, string[] dressing, string[] grill)
    {
        this.name = name;
        this.bases = bases;
        this.toppings = toppings;
        this.dressing = dressing;
        this.grill = grill;
    }

    // Combine all ingredients into one list
    public List<string> GetIngredients()
    {
        List<string> ingredients = new List<string>();
        foreach(string b in bases) ingredients.Add(b);
        foreach(string t in toppings) ingredients.Add(t);
        foreach(string d in dressing) ingredients.Add(d);
        foreach(string g in grill) ingredients.Add(g);
        return ingredients;
    }
    
    // Number of levels passed
    public int GetLevelsCompleted()
    {
        return levelsCompleted;
    }

    // Which level is in progress
    public int GetCurrentLevel()
    {
        if (levelsCompleted < 3)
        {
            return levelsCompleted + 1;
        }
        else
        {
            return 3;
        }
    }

    public void IncreaseLevel()
    {
        if (levelsCompleted < 3) levelsCompleted++;
    }

    public float GetProgress()
    {
        return (float) levelsCompleted / maxLevel;
    }
}