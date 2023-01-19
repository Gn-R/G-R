using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
	// Game modes
	[SerializeField] Button showGameModes;
	[SerializeField] GameObject gameModesPanel;
	private bool selectMode;
	[SerializeField] Button elJefeFreeplay, elJefePro, randomFreeplay, randomPro, learn;

	void Start()
	{
		gameModesPanel.SetActive(false);
		selectMode = false;
		showGameModes.onClick.AddListener(ToggleGameModePanel);

		elJefeFreeplay.onClick.AddListener(PlayElJefeFreeplay);
		elJefePro.onClick.AddListener(PlayElJefePro);
		randomFreeplay.onClick.AddListener(PlayRandomFreeplay);
		randomPro.onClick.AddListener(PlayRandomPro);
		learn.onClick.AddListener(PlayLearnMode);
	}
	void ToggleGameModePanel()
	{
		selectMode = !selectMode;
		gameModesPanel.SetActive(selectMode);
	}

	void PlayElJefeFreeplay()
    {
		DishManager.gameMode = 0;
		SceneManager.LoadScene("Main Scene");
	}

	void PlayElJefePro()
	{
		DishManager.gameMode = 1;
		SceneManager.LoadScene("Main Scene");
	}

	void PlayRandomFreeplay()
	{
		DishManager.gameMode = 2;
		SceneManager.LoadScene("Main Scene");
	}

	void PlayRandomPro()
	{
		DishManager.gameMode = 3;
		SceneManager.LoadScene("Main Scene");
	}

	void PlayLearnMode()
    {
		DishManager.gameMode = 4;
		SceneManager.LoadScene("Learn Scene");
    }
}
