using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderTimerDebug : MonoBehaviour
{
    public Slider slider;
    public Image sliderFill;
    public GameObject manager;

    private float totalTime = 10f;
    public float timer = 0f;

    private Coroutine runTimer = null;

    private float interval = 0.05f;

    public void StartOrderTimer(int recipeTime)
    {
        totalTime = recipeTime;
        timer = totalTime;
        
        if (runTimer != null)
        {
            StopCoroutine(RunTimer());
        }
        runTimer = StartCoroutine(RunTimer());
    }

    private IEnumerator RunTimer()
    {
        if (!Manager.Instance.paused) {
        
            if (timer > 0)
            {
                timer -= interval;

                float percentage = timer / totalTime;

                slider.value = percentage;

                if (percentage > 0.5f)
                {
                    //Done to convert the percentage to the proper RGB value so the color changes properly
                    percentage = (percentage - 0.5f) * 2;
                    sliderFill.color = new Color(1 - percentage, 1, 0);
                }
                else
                {
                    percentage *= 2;
                    sliderFill.color = new Color(1, percentage, 0);
                }
            }

            if (timer <= 0)
            {
                Manager.Instance.Score -= 1;
            }
            
        }
        yield return new WaitForSeconds(interval);

        runTimer = StartCoroutine(RunTimer());
    }

    public float getPercentage()
    {
        return timer / totalTime;
    }
}
