using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Pauses the game, stopping updates and blocking button presses
// ISSUE: bowl and ingredients are still pressable while paused
public class PauseMenu : MonoBehaviour
{
    private Manager manager;
    private bool muted;

    public Sprite pauseImage, resumeImage;
    [SerializeField] Image pauseButton, muteButton;
    [SerializeField] GameObject pausePanel;
    
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
            pauseButton.sprite = resumeImage;
            ShowPauseMenu(true);
        }
        else
        {
            pauseButton.sprite = pauseImage;
            ShowPauseMenu(false);
        }
    }

    private void ShowPauseMenu(bool active)
    {
        pausePanel.SetActive(active);
        muteButton.gameObject.SetActive(active);
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
}
