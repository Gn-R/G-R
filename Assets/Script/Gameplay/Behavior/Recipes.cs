using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A list a recipes the program uses.f
// In the future, load these from a text file and distinguish between ingredient types (base, dressing, etc.).
public class Recipes
{
    public static string getRandomDish()
    {
        int dice = Random.Range(0, 10); 
        switch (dice)
        {
            default:
            case 0:
                return "Mayweather";
            case 1:
                return "Pesto Caesar";
            case 2:
                return "Corner Cobb";
            case 3:
                return "Tamari";
            case 4:
                return "Mad Bowl";
            case 5:
                return "El Jefe";
            case 6:
                return "Roots Bowl";
            case 7:
                return "The Apollo";
            case 8:
                return "The Southern";
            case 9:
                return "The Balboa";
        }
    }

    public static List<string> getRecipe(string dish)
    {
        List<string> recipe;
        switch (dish)
        {
            default:
            case "Mayweather":
                recipe = new List<string>(mayweather);
                break;
            case "Pesto Caesar":
                recipe = new List<string>(pestoCaesar);
                break;
            case "Corner Cobb":
                recipe = new List<string>(cornerCobb);
                break;
            case "Tamari":
                recipe = new List<string>(tamari);
                break;
            case "Mad Bowl":
                recipe = new List<string>(madBowl);
                break;
            case "El Jefe":
                recipe = new List<string>(elJefe);
                break;
            case "Roots Bowl":
                recipe = new List<string>(rootsBowl);
                break;
            case "The Apollo":
                recipe = new List<string>(theApollo);
                break;
            case "The Southern":
                recipe = new List<string>(theSouthern);
                break;
            case "The Balboa":
                recipe = new List<string>(theBalboa);
                break;
            case "Balanced Diet":
                recipe = new List<string>(balancedDiet);
                break;
            case "Planet Earth":
                recipe = new List<string>(planetEarth);
                break;
            case "Rainbow":
                recipe = new List<string>(rainbow);
                break;
        }

        return recipe;
    }

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
        "Chicken" // From The Grill
    });

    // "Corner Cobb"
    public static List<string> cornerCobb = new List<string>(new string[] {
        "Arcadian Mix", //Primeary Base
        "Roots Rice", "Kale", //Secondary Base
        "Roasted Broccoli", "Red Onions", "Pickled Jalapeños", "Red Cabbage", "Toasted Almonds", //Ingredients
        "Miso Ginger", //Dressing
        "Chicken" //From the Grill
    });

    // "Mayweather"
    public static List<string> mayweather = new List<string>(new string[] {
        "Kale", //Primary Base
        "Bulgur", //Secondary Base
        "Roasted Sweet Potatoes", "Roasted Beets", "Red Onions", "Goat Cheese", "Avocado", //Ingredients    
        "Lemon Tahini", "Pesto Vinaigrette", //Dressing
        "Chicken" //From the Grill
    });

    // "Pesto Caesar"
    public static List<string> pestoCaesar = new List<string>(new string[] {
        "Kale", //Primary Base
        "Bulgur", //Secondary Base
        "Grape Tomatoes", "Pita Chips", "Lime-Pickled Onions, Shaved Parmesan", //Ingredients
        "Pesto Vinaigrette", "Caesar", //Dressing
        "Chicken" //From the Grill
    });

    // "Tamari"
    public static List<string> tamari = new List<string>(new string[] {
        "Brown Rice", "Kale", //Primary Base
        "Roatsed Broccoli", "Red Onion", "Carrots", "Pickled Jalapenos", "Red Cabbage", "Toasted Almonds", //Ingredients
        "Miso Ginger", //Dressing
        "Red Chili Miso Tofu" //From the Grill
    });

    // "Mad Bowl"
    public static List<string> madBowl = new List<string>(new string[]
    {
        "Brown Rice", //Primary Base
        "Spinach", //Secondary Base
        "Cannellini Beans", "Roasted Broccoli", "Cucumbers", "Grape Tomatoes", "Red Onions", "Shaved Parmesan", //Ingredients
        "Pesto Vinaigrette", "Basil Balsamic", //Dressing
        "Mushrooms" //From the Grill
    });

    public static List<string> theApollo = new List<string>(new string[] {
        "Brown Rice", //Primary Base
        "Kale", //Secondary Base
        "Black Beans", "Charred Corn", "Red Onions", "Avocado", "Pita Chips", "Feta", //Ingredients
        "Cilantro Lime", //Dressing
        "Chicken" //From the Grill
    });

    public static List<string> theSouthern = new List<string>(new string[]
    {
        "Roots Rice", //Primary Base
        "Kale", //Secondary Base
        "Chickpeas", "Roatsed Broccoli", "Charred Corn", "Lime-Pickled Onions", "Cheddar", //Ingredients
        "Lemon Tahini", //Dressing
        "BBQ Tofu" //From the Grill
    });

    public static List<string> theBalboa = new List<string>(new string[]
    {
        "Brown Rice", //Primary Base
        "Roatsed Sweet Potatoes", "Charred Corn", "Avocado", "Pita Chips", "Feta", "Lime-Pickled Onions", //Ingredients
        "Lemon Tahini", "Caesar", "Frank's Red Hot", //Dressing
        "Chicken" //From the Grill
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
