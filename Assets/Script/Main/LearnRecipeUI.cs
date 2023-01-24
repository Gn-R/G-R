using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LearnRecipeUI : MonoBehaviour
{
    [SerializeField] GameObject learnSceneManager;
    [SerializeField] Button selectRecipe;
    [SerializeField] ProgressBar[] levelSliders;
    [SerializeField] TextMeshProUGUI recipeNameText;

    public string recipeName = "";
    private Recipe recipe;

    // Start is called before the first frame update
    void Start()
    {
        recipeNameText.text = recipeName;
        recipe = Recipes.GetRecipe(recipeName);
        selectRecipe.onClick.AddListener(chooseRecipe);

        for (int i = 0; i < recipe.GetCurrentLevel(); i++) {
            levelSliders[i].setCompletion(true);
        }
        levelSliders[recipe.GetCurrentLevel() - 1].setCompletion(recipe.GetCompletion());
    }

    void chooseRecipe()
    {
        learnSceneManager.GetComponent<LearnManager>().setRecipe(recipe);
        //TODO: Set Button Look to show selection
    }
}
