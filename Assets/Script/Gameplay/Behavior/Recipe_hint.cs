using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// A button that displays a recipe hint text box for the user
public class Recipe_hint : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI button_text;
    [SerializeField] TextMeshProUGUI recipe_hint;
    private List<string> recipe;
    private string hint_text;
    private bool show_hint;
    
    void Start()
    {
        show_hint = false;
        recipe = Recipes.balancedDiet; // todo get current recipe from Manager
        recipe_hint.text = "";
        hint_text = "";
        foreach (string str in recipe)
        {
            hint_text += str + " ";
        }
        // TODO Can't find the method to set text invisible. In the future just make text box invisible from beginning
    }

    public void Toggle() {
        show_hint = !show_hint;
        if (show_hint)
        {
            button_text.text = "Hide Recipe";
            recipe_hint.text = hint_text;
        }
        else
        {
            button_text.text = "Show Recipe";
            recipe_hint.text = "";
        }
    }
}
