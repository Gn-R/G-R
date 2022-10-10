using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServeDebug : MonoBehaviour
{
    public GameObject manager;
    public Button button;
    public GameObject ingredients;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
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

        manager.GetComponent<DishManager>().getNewRecipe();

        foreach (Transform obj in ingredients.transform)
        {
            Destroy(obj.gameObject);
        }

        manager.GetComponent<LerpRail>().returnToStart();
    }
}
