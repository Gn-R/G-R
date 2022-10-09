using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// A button that displays a recipe hint text box for the user
public class RecipeHint : MonoBehaviour
{
    [SerializeField] Image hintButton;
    [SerializeField] GameObject hintTextImage;
    [SerializeField] TextMeshProUGUI hintTextField;

    private List<string> recipe;
    private bool showingRecipe;

    public GameObject manager;

    void Start()
    {
        showingRecipe = false;
        setRecipe(manager.GetComponent<DishManager>().currRecipe);
        // TODO Can't find the method to set text invisible. In the future just make text box invisible from beginning
    }

    public void setRecipe(List<string> newRecipe)
    {
        recipe = newRecipe;
        
        string hintText = "";
        foreach (string str in recipe)
        {
            hintText += str + ", ";
        }
        hintTextField.text = hintText;
    }

    public void Toggle()
    {        
        showingRecipe = !showingRecipe;
        if (showingRecipe)
        {
            hintButton.color = new Color(0.5f, 0.5f, 0.5f);
        }
        else
        {
            hintButton.color = new Color(1, 1, 1);
        }
        hintTextImage.SetActive(showingRecipe);
    }
}
