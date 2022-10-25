using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
	[SerializeField] Button swapPhoto;
	[SerializeField] Image photo;

	// Game modes
	[SerializeField] Button playLast, showGameModes;
	private bool selectMode;
	[SerializeField] GameObject gameModesPanel;
	[SerializeField] Button elJefeFreeplay, elJefePro, randomFreeplay, randomPro;

	void Start()
	{
		swapPhoto.onClick.AddListener(SwapOnClick);
		playLast.onClick.AddListener(PlayOnClick);

		gameModesPanel.SetActive(false);
		selectMode = false;
		showGameModes.onClick.AddListener(ToggleGameModes);

		elJefeFreeplay.onClick.AddListener(ElJefeFreeplayOnClick);
		elJefePro.onClick.AddListener(ElJefeProOnClick);
		randomFreeplay.onClick.AddListener(RandomFreeplayOnClick);
		randomPro.onClick.AddListener(RandomProOnClick);
	}

	void ToggleGameModes()
	{
		selectMode = !selectMode;
		gameModesPanel.SetActive(selectMode);
	}

	void PlayOnClick()
    {
		SceneManager.LoadScene("Main Scene");
	}

	void ElJefeFreeplayOnClick()
    {
		DishManager.gameMode = 0;
		SceneManager.LoadScene("Main Scene");
	}

	void ElJefeProOnClick()
	{
		DishManager.gameMode = 1;
		SceneManager.LoadScene("Main Scene");
	}

	void RandomFreeplayOnClick()
	{
		DishManager.gameMode = 2;
		SceneManager.LoadScene("Main Scene");
	}

	void RandomProOnClick()
	{
		DishManager.gameMode = 3;
		SceneManager.LoadScene("Main Scene");
	}

	void SwapOnClick()
	{
		photo.enabled = !photo.enabled;
	}
}
