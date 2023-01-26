using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SelectRecipe : MonoBehaviour
{
    [SerializeField] GameObject learnSceneManager;
    [SerializeField] Button selectButton;
    [SerializeField] ProgressBar[] levelSliders;
    [SerializeField] string recipeName = "";
    
    private Recipe recipe;

    // Start is called before the first frame update
    void Start()
    {
        recipe = Recipes.GetRecipe(recipeName);
        selectButton.onClick.AddListener(chooseRecipe);

        for (int i = 0; i < recipe.GetCurrentLevel(); i++) {
            levelSliders[i].setCompletion(true);
        }
        levelSliders[recipe.GetCurrentLevel() - 1].setCompletion(recipe.GetCompletion());
    }

    void chooseRecipe()
    {
        learnSceneManager.GetComponent<LearnManager>().SetRecipe(recipe);
        //TODO: Set Button Look to show selection
    }
}
