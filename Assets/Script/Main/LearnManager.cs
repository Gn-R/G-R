using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LearnManager : MonoBehaviour
{
    [SerializeField] Button continueRecipe;
    [SerializeField] Text progress, currentLevel;
    [SerializeField] Slider progressBar;

    private static Recipe currRecipe;

    void Start()
    {
        continueRecipe.onClick.AddListener(AdvanceToPlay);
    }

    void AdvanceToPlay()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void setRecipe(Recipe recipe)
    {
        currRecipe = recipe;
        progress.text = "Progress: " + recipe.GetProgress() + "%";
        progressBar.value = recipe.GetProgress();
        currentLevel.text = "Level: " + recipe.GetCurrentLevel();
    }
}
