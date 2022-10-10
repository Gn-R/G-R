using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// A button that displays a recipe hint text box for the user
public class RecipeHint : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI button_text;
    [SerializeField] TextMeshProUGUI recipe_hint;
    private List<string> recipe;
    private string hint_text;
    private bool show_hint;

    public GameObject manager;

    void Start()
    {
        show_hint = false;
        setRecipe(manager.GetComponent<DishManager>().currRecipe);
        // TODO Can't find the method to set text invisible. In the future just make text box invisible from beginning
    }

    public void setRecipe(List<string> newRecipe)
    {
        recipe = newRecipe;

        recipe_hint.text = "";
        hint_text = "";
        foreach (string str in recipe)
        {
            hint_text += str + ", ";
        }
    }

    public void Toggle()
    {        
        show_hint = !show_hint;
        if (show_hint)
        {
            button_text.text = "Hide Recipe";
            recipe_hint.text = hint_text;

            if (DishManager.gameMode % 2 == 0)
            {
                Manager.Instance.Score -= 50;
            }
            else
            {
                Manager.Instance.Score -= 300;
            }
        }
        else
        {
            button_text.text = "Show Recipe";
            recipe_hint.text = "";
        }
    }
}
