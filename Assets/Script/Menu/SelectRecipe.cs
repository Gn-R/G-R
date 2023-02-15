using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectRecipe : MonoBehaviour
{
    [SerializeField] StartMenu startMenu;
    [SerializeField] Button selectButton;
    [SerializeField] ProgressBar[] levelSliders;
    [SerializeField] string recipeName = "";
    
    private Recipe recipe;

    void Start()
    {
        recipe = Recipes.GetRecipe(recipeName);
        selectButton.onClick.AddListener(ChooseRecipe);

        for (int i = 0; i < recipe.GetLevelsCompleted(); i++)
        {
            levelSliders[i].SetCompletion(true);
        }
    }

    void ChooseRecipe()
    {
        startMenu.SetRecipe(recipe);
        //TODO: Set Button Look to show selection
    }
}
