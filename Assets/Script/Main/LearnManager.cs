using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LearnManager : MonoBehaviour
{
    [SerializeField] Button continueRecipe;
    [SerializeField] TextMeshProUGUI progress, currentRecipe;
    [SerializeField] ProgressBar progressBar;

    private static Recipe currRecipe;

    void Start()
    {
        continueRecipe.onClick.AddListener(AdvanceToPlay);
    }

    void AdvanceToPlay()
    {
        DishManager.currDish = currRecipe.name;
        SceneManager.LoadScene("Main Scene");
    }

    public void setRecipe(Recipe recipe)
    {
        currRecipe = recipe;
        progress.text = "Level: " + recipe.GetCurrentLevel();
        progressBar.setCompletion(recipe.GetCompletion());
        currentRecipe.text = recipe.name;
    }
}
