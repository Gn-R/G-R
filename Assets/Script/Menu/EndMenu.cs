using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// The end scene menu manager
public class EndMenu : MonoBehaviour
{
    [SerializeField] Button menuButton, continueButton;
    [SerializeField] TextMeshProUGUI cashEarned, continueText;

    private static Recipe currRecipe;

    void Start()
    {
        menuButton.onClick.AddListener(BackToMenu);
        continueButton.onClick.AddListener(ContinueNextLevel);
        SetCashEarned(0); // Get this value from manager

        string dish = DishManager.currDish;
        continueText.text = "Continue\nLevel " + Recipes.GetRecipe(dish).GetCurrentLevel();
    }

    void BackToMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    void ContinueNextLevel()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void SetCashEarned(int cash)
    {
        cashEarned.text = "$" + cash;
    }
}
