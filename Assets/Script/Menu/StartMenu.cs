using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// The dish select scene menu manager
public class StartMenu : MonoBehaviour
{
    [SerializeField] Button continueButton;
    [SerializeField] TextMeshProUGUI nextLevel, recipeText, cashEarned;
    [SerializeField] ProgressBar progressBar;
    [SerializeField] Slider progressSlider;

    private static Recipe currRecipe = null; // static to remember last dish after scene transition

    void Start()
    {
        continueButton.onClick.AddListener(ToMainScene);
        continueButton.enabled = false; // don't allow click until recipe is set
        UpdateElements();

        // TODO get these values from manager
        SetCashEarned(0); 
        SetSliderProgress(Recipes.GetTotalProgress());
    }

    void ToMainScene()
    {
        if (currRecipe == null) return; // ignore if no recipe set
        DishManager.currDish = currRecipe.name;
        SceneManager.LoadScene("Main Scene");
    }

    public void SetRecipe(Recipe recipe)
    {
        currRecipe = recipe;
        UpdateElements();
    }

    public void UpdateElements()
    {
        if (currRecipe == null) return;
        continueButton.enabled = true;
        recipeText.text = currRecipe.name;
        nextLevel.text = "Next Level: " + currRecipe.GetCurrentLevel();
    }

    public void SetCashEarned(int cash)
    {
        cashEarned.text = "$" + cash;
    }

    public void SetSliderProgress(float percent)
    {
        progressSlider.value = percent;
    }
}
