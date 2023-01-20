using System.Collections;
using System.Collections.Generic;

// Stores a list of ingredients
public class Recipe
{
    public readonly string name; // name of dish
    public readonly string[] bases, toppings, dressing, grill; // ingredients list + category

    public Recipe(string name, string[] bases, string[] toppings, string[] dressing, string[] grill)
    {
        this.name = name;
        this.bases = bases;
        this.toppings = toppings;
        this.dressing = dressing;
        this.grill = grill;
    }

    // Copy of ingredients
    public List<string> GetIngredients()
    {
        List<string> ingredients = new List<string>();
        foreach(string b in bases) ingredients.Add(b);
        foreach(string t in toppings) ingredients.Add(t);
        foreach(string d in dressing) ingredients.Add(d);
        foreach(string g in grill) ingredients.Add(g);
        return ingredients;
    }
}