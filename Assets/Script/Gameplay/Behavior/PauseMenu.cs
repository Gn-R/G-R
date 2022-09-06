using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Plays a tutorial
// TODO make it more interactive and "pop out" more
// i.e. point to buttons to click
public class PauseMenu : MonoBehaviour
{
    private Manager manager;
    [SerializeField] TextMeshProUGUI pauseButton;
    [SerializeField] GameObject pauseDialog;
    
    void Start()
    {
        manager = Manager.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePaused();
        }
    }

    public void TogglePaused() {
        manager.paused = !manager.paused;
        if (manager.paused)
        {
            pauseButton.text = "Unpause";
            pauseDialog.SetActive(true);
        }
        else
        {
            pauseButton.text = "Pause";
            pauseDialog.SetActive(false);
        }
    }
}
