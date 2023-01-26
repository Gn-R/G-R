using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LearnManager : MonoBehaviour
{
    [SerializeField] Button continueRecipe;
    [SerializeField] TextMeshProUGUI progress, currentRecipe, cashEarned;
    [SerializeField] ProgressBar progressBar;

    private static Recipe currRecipe;

    void Start()
    {
        continueRecipe.onClick.AddListener(AdvanceToPlay);
        continueRecipe.enabled = false;
        SetCashEarned(0);
    }

    void AdvanceToPlay()
    {
        if (currentRecipe == null) return;
        DishManager.currDish = currRecipe.name;
        SceneManager.LoadScene("Main Scene");
    }

    public void SetRecipe(Recipe recipe)
    {
        if (!continueRecipe.enabled)
        {
            continueRecipe.enabled = true;
        }
        
        currRecipe = recipe;
        progress.text = "Level: " + recipe.GetCurrentLevel();
        progressBar.setCompletion(recipe.GetCompletion());
        currentRecipe.text = recipe.name;
    }

    public void SetCashEarned(int cash)
    {
        cashEarned.text = "$" + cash;
    }
}
