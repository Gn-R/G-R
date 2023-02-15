using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ServeDebug : MonoBehaviour
{
    public GameObject manager;
    public Button button;
    public GameObject ingredients;

    public GameObject notAtEndMessage;
    private Coroutine endMessage;

    void Start()
    {
        // button.onClick.AddListener(TaskOnClick);
        button.onClick.AddListener(ToEndScene);
    }

    void ToEndScene()
    {
        SceneManager.LoadScene("End Scene");
        string currDish = DishManager.currDish;
        Recipes.GetRecipe(currDish).IncreaseLevel();
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

        // foreach (string str in Manager.Instance.combo)
        // {
        //     Debug.Log(str);
        // }

        if (manager.GetComponent<DishManager>().checkDish(Manager.Instance.combo))
        {
            Manager.Instance.totalScore += (int) (Manager.Instance.Score * Manager.Instance.ScoreMult);
        }
        else
        {;
            Manager.Instance.totalScore = Manager.Instance.Score;
        }

        SceneManager.LoadScene("Final Scene");

        // manager.GetComponent<DishManager>().GetNewRecipe();

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
