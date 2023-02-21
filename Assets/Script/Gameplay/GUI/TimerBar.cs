//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerBar : MonoBehaviour
{
    [SerializeField] float maxTime;
    private float timeLeft;
    [SerializeField] RectTransform timerBar, timerFill;
    private Vector3 startPos;
    private float height;

    void Start()
    {
        timeLeft = maxTime;
        startPos = timerFill.localPosition;
        height = timerFill.rect.height;
    }

    void Update()
    {
        if (!Manager.Instance.paused) // Advanced timer when unpaused
        {            
            timeLeft -= Time.deltaTime;
            Manager.Instance.GameTime = timeLeft;

            if (timeLeft < 0)
            {
                Manager.Instance.GameTime = timeLeft;
                SceneManager.LoadScene("Final Scene");
            }
            else {
                // shrink the timer bar vertically
                int timeInt = Mathf.CeilToInt(Manager.Instance.GameTime);
                float percentTimeLeft = timeInt / maxTime;
                timerFill.localScale = new Vector3(1, percentTimeLeft, 1);

                // keep bar anchored down
                float dy = (1f - percentTimeLeft) * height / 2f;
                timerFill.localPosition = startPos + dy * Vector3.down;
            }
        }
    }
}
