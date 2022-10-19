using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaVButton : MonoBehaviour
{
	public Button Play;
	public Button Swap;
	public Image C1;

	public Button ElJefeFreeplay;
	public Button ElJefePro;
	public Button RandomFreeplay;
	public Button RandomPro;

	// Start is called before the first frame update
	void Start()
	{
		Button btn = Swap.GetComponent<Button>();
		btn.onClick.AddListener(SwapOnClick);

		Button btn1 = Play.GetComponent<Button>();
		btn1.onClick.AddListener(PlayOnClick);


		ElJefeFreeplay.onClick.AddListener(ElJefeFreeplayOnClick);
		ElJefePro.onClick.AddListener(ElJefeProOnClick);
		RandomFreeplay.onClick.AddListener(RandomFreeplayOnClick);
		RandomPro.onClick.AddListener(RandomProOnClick);
	}

	void PlayOnClick()
    {
		SceneManager.LoadScene(1);
	}

	void ElJefeFreeplayOnClick()
    {
		SceneManager.LoadScene(1);
		DishManager.gameMode = 0;
	}

	void ElJefeProOnClick()
	{
		SceneManager.LoadScene(1);
		DishManager.gameMode = 1;
	}

	void RandomFreeplayOnClick()
	{
		SceneManager.LoadScene(1);
		DishManager.gameMode = 2;
	}

	void RandomProOnClick()
	{
		SceneManager.LoadScene(1);
		DishManager.gameMode = 3;
	}

	void SwapOnClick()
	{
		if (C1.enabled == true)
        {
			C1.enabled = false;
        }
		else 
        {
			C1.enabled = true;
		}
	}
}
