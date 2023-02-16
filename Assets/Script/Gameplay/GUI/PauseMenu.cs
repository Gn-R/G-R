using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// Pauses the game, stopping updates and blocking button presses
public class PauseMenu : MonoBehaviour
{
    private Manager manager;
    private bool muted;

    // TODO move mute button to main UI
    [SerializeField] Image muteButton, pauseButton;
    [SerializeField] GameObject pausePanel, resumeButton, currentLevel;
    [SerializeField] TextMeshProUGUI currentLevelText;
    [SerializeField] Button menuButton;
    
    void Start()
    {
        manager = Manager.Instance;
        manager.paused = true;
        currentLevelText.text = "Current Level: " + DishManager.GetCurrentRecipe().GetNextLevel();
        menuButton.onClick.AddListener(ToMenu);
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePaused();
        }
    }

    public void TogglePaused()
    {
        manager.paused = !manager.paused;
        UpdateUI();
    }

    private void UpdateUI()
    {
         // show buttons when paused, hide when playing
        pausePanel.SetActive(manager.paused);
        resumeButton.SetActive(manager.paused);
        currentLevel.SetActive(manager.paused);
        menuButton.gameObject.SetActive(manager.paused);

        if (manager.paused)  // darken pause button when paused
        {
            pauseButton.color = new Color(0.5f, 0.5f, 0.5f);
        }
        else
        {
            pauseButton.color = new Color(1, 1, 1);
        }
    }

    public void ToggleMuted()
    {
        muted = !muted;
        if (muted)
        {
            muteButton.color = new Color(0.5f, 0.5f, 0.5f);
            AudioListener.volume = 0f;
        }
        else
        {
            muteButton.color = new Color(1, 1, 1);
            AudioListener.volume = 1f;
        }
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
