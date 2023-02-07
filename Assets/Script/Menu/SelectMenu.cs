using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// The dish select scene menu manager
public class SelectMenu : MonoBehaviour
{
    [SerializeField] Button continueButton;
    [SerializeField] TextMeshProUGUI progress, recipeText, cashEarned;
    [SerializeField] ProgressBar progressBar;
    [SerializeField] ProgressSlider progressSlider;

    private static Recipe currRecipe;

    void Start()
    {
        continueButton.onClick.AddListener(AdvanceToPlay);
        continueButton.enabled = false;
        SetCashEarned(0); // Get this value from manager
        SetSliderProgress(0.0f); // Get this value from manager
    }

    void AdvanceToPlay()
    {
        if (recipeText == null) return;
        DishManager.currDish = currRecipe.name;
        SceneManager.LoadScene("Main Scene");
    }

    public void SetRecipe(Recipe recipe)
    {
        if (!continueButton.enabled) continueButton.enabled = true;
        
        currRecipe = recipe;
        recipeText.text = recipe.name;

        progress.text = "Level: " + recipe.GetCurrentLevel();
        progressBar.SetCompletion(recipe.GetCompletion());
    }

    public void SetCashEarned(int cash)
    {
        cashEarned.text = "$" + cash;
    }

    public void SetSliderProgress(float percent)
    {
        progressSlider.SetProgress(percent);
    }
}
