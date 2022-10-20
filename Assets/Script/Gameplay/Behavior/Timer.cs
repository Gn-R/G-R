//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeLimit;
    private float timer;
    [SerializeField] RectTransform timerBar, timerFill;
    private Vector3 startPos;
    private float width, positionDx;

    void Start()
    {
        timer = timeLimit;
        startPos = timerFill.localPosition;
        width = timerFill.rect.width;
    }

    void Update()
    {
        if (!Manager.Instance.paused) // Disable timer if paused
        {            
            timer -= Time.deltaTime;
            Manager.Instance.GameTime = timer;

            if (timer < 0)
            {
                Manager.Instance.GameTime = timer;
                SceneManager.LoadScene("End Screen");
            }

            if (timer >= 0) {
                // shrink the timer bar
                int timeInt = Mathf.CeilToInt(Manager.Instance.GameTime);
                float percentTimeLeft = timeInt / timeLimit;
                timerFill.localScale = new Vector3(percentTimeLeft, 1, 1);

                // keep bar anchored left
                float dx = (1f - percentTimeLeft) * width / 2f;
                timerFill.localPosition = startPos + dx * Vector3.left;
            }
        }
    }
}
