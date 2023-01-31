using System.Collections;
using System.Collections.Generic;

// Stores a list of ingredients
public class Recipe
{
    public readonly string name; // name of dish
    public readonly string[] bases, toppings, dressing, grill; // ingredients list + category
    private int currentLevel = 1;
    private bool completed = false;

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

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void IncreaseLevel()
    {
        if (currentLevel < 3) {
            currentLevel++;
            completed = false;
        }
    }

    public bool GetCompletion()
    {
        return completed;
    }
}