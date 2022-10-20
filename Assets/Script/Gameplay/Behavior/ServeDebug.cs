using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServeDebug : MonoBehaviour
{
    public GameObject manager;
    public Button button;
    public GameObject ingredients;

    public GameObject notAtEndMessage;
    private Coroutine endMessage;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (!manager.GetComponent<LerpRail>().isAtEnd())
        {
            if (endMessage != null)
            {
                StopCoroutine(endMessage);
            }
            endMessage = StartCoroutine(ShowNotAtEndMessage());
            return;
        }

        foreach (string str in Manager.Instance.combo)
        {
            // Debug.Log(str);
        }

        if (manager.GetComponent<DishManager>().checkDish(Manager.Instance.combo))
        {
            Manager.Instance.totalScore += (int) (Manager.Instance.Score * Manager.Instance.ScoreMult);
        }
        else
        {
            Manager.Instance.Score = 0;
        }

        manager.GetComponent<DishManager>().GetNewRecipe();

        foreach (Transform obj in ingredients.transform)
        {
            Destroy(obj.gameObject);
        }

        manager.GetComponent<LerpRail>().returnToStart();
    }

    private IEnumerator ShowNotAtEndMessage()
    {
        notAtEndMessage.SetActive(true);
        yield return new WaitForSeconds(3f);
        notAtEndMessage.SetActive(false);
    }
}
