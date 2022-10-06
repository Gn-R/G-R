using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Pauses the game, stopping updates and blocking button presses
// ISSUE: bowl and ingredients are still pressable while paused
public class PauseMenu : MonoBehaviour
{
    private Manager manager;
    private bool muted;

    [SerializeField] TextMeshProUGUI pauseText, muteText;
    [SerializeField] GameObject pauseDialog, pausePanel, muteButton;
    
    void Start()
    {
        manager = Manager.Instance;
        manager.paused = true;
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
        if (manager.paused)
        {
            pauseText.text = "Unpause";
            ShowPauseMenu(true);
        }
        else
        {
            pauseText.text = "Pause";
            ShowPauseMenu(false);
        }
    }

    private void ShowPauseMenu(bool active)
    {
        pauseDialog.SetActive(active);
        pausePanel.SetActive(active);
        muteButton.SetActive(active);
    }

    public void ToggleMuted()
    {
        muted = !muted;
        if (muted)
        {
            muteText.text = "Unmute";
            AudioListener.volume = 0f;
        }
        else
        {
            muteText.text = "Mute";
            AudioListener.volume = 1f;
        }
    }
}
