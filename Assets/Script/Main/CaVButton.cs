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

	// Start is called before the first frame update
	void Start()
	{
		Button btn = Swap.GetComponent<Button>();
		btn.onClick.AddListener(SwapOnClick);

		Button btn1 = Play.GetComponent<Button>();
		btn1.onClick.AddListener(PlayOnClick);
	}

	void PlayOnClick()
    {
		SceneManager.LoadScene(1);
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
