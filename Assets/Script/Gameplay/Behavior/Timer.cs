//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI Number;
    public float timer = 10f;
    public int final;

    // Start is called before the first frame update
    void Start()
    {
        Number = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        Number.text = "Time: " + Manager.Instance.GameTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Manager.Instance.paused)
        {
            timer -= Time.deltaTime;
            Manager.Instance.GameTime = timer;

            //if (timer <= 0)
            //{
            //    Manager.Instance.GameTime = timer;
            //    SceneManager.LoadScene(2);
            //}

            final = Mathf.CeilToInt(Manager.Instance.GameTime);

            Number.text = "Time: " + final;
        }
    }
}
