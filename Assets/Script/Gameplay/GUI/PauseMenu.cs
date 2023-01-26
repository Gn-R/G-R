using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Pauses the game, stopping updates and blocking button presses
public class PauseMenu : MonoBehaviour
{
    private Manager manager;
    private bool muted;

    // TODO move mute button to main UI
    [SerializeField] GameObject resumeButton, pauseButton; // change button (images) depend on play/pause
    [SerializeField] Image muteButton;
    [SerializeField] GameObject pausePanel;
    
    void Start()
    {
        manager = Manager.Instance;
        manager.paused = true;
        pausePanel.SetActive(true);
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

        pauseButton.SetActive(!manager.paused); // hide pause button when paused
        resumeButton.SetActive(manager.paused); // show resume button when paused
        pausePanel.SetActive(manager.paused); // show pause panel when paused
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
