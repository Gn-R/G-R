using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectRecipe : MonoBehaviour
{
    [SerializeField] GameObject selectMenu;
    [SerializeField] Button selectButton;
    [SerializeField] ProgressBar[] levelSliders;
    [SerializeField] string recipeName = "";
    
    private Recipe recipe;

    void Start()
    {
        recipe = Recipes.GetRecipe(recipeName);
        selectButton.onClick.AddListener(ChooseRecipe);

        for (int i = 0; i < recipe.GetCurrentLevel(); i++) {
            levelSliders[i].SetCompletion(true);
        }
        levelSliders[recipe.GetCurrentLevel() - 1].SetCompletion(recipe.GetCompletion()); // make previous bars red
    }

    void ChooseRecipe()
    {
        selectMenu.GetComponent<SelectMenu>().SetRecipe(recipe);
        //TODO: Set Button Look to show selection
    }
}
