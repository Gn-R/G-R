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


    void Start()
    {
        menuButton.onClick.AddListener(BackToMenu);
        continueButton.onClick.AddListener(ContinueNextLevel);
        SetCashEarned(0); // Get this value from manager

        Recipe currRecipe = DishManager.GetCurrentRecipe();
        int lastLevel = currRecipe.GetLevelsCompleted();
        if (lastLevel < 3)
        {
            int nextLevel = currRecipe.GetCurrentLevel();
            if (DishManager.GetLevelSuccess())
            {
                continueText.text = "Continue\nLevel " + nextLevel;
            }
            else
            {
                continueText.text = "Retry\nLevel " + nextLevel;
            }
        }
        else
        {
            continueText.text = "All Levels\nComplete!";
        }
        
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
