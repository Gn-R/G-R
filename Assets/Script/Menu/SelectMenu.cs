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
    [SerializeField] Slider progressSlider;

    private static Recipe currRecipe;

    void Start()
    {
        continueButton.onClick.AddListener(ToReadyScene);
        continueButton.enabled = DishManager.currDish.Equals(""); // don't move forward until recipe is set
        // TODO check if set after scene transition
        // TODO get these values from manager
        SetCashEarned(0); 
        SetSliderProgress(0.0f);
    }

    void ToReadyScene()
    {
        if (recipeText == null) return;
        DishManager.currDish = currRecipe.name;
        SceneManager.LoadScene("Ready Scene");
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
