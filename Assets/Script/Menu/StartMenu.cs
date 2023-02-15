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
    [SerializeField] TextMeshProUGUI progress, recipeText, cashEarned;
    [SerializeField] ProgressBar progressBar;
    [SerializeField] Slider progressSlider;

    private static Recipe currRecipe;

    void Start()
    {
        continueButton.onClick.AddListener(ToMainScene);
        continueButton.enabled = DishManager.currDish.Equals(""); // don't move forward until recipe is set
        // TODO check if set after scene transition
        // TODO get these values from manager
        SetCashEarned(0); 
        SetSliderProgress(0.0f);
    }

    void ToMainScene()
    {
        if (currRecipe == null) return; // ignore if no recipe set
        DishManager.currDish = currRecipe.name;
        SceneManager.LoadScene("Main Scene");
    }

    public void SetRecipe(Recipe recipe)
    {
        continueButton.enabled = true;
        
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
        progressSlider.value = percent;
    }
}
