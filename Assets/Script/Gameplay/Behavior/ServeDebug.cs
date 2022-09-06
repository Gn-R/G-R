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
        if (Manager.Instance.paused) return;
        
        foreach (string str in Manager.Instance.combo)
        {
            Debug.Log(str);
        }
        if (manager.GetComponent<DishManager>().checkDish(Manager.Instance.combo))
        {
            Manager.Instance.Score += (int) (1000 * manager.GetComponent<DishManager>().getTimerPercentage());
        }
        else
        {
            Manager.Instance.Score -= 1000;
        }

        manager.GetComponent<DishManager>().getNewRecipe();

        foreach (Transform obj in ingredients.transform)
        {
            Destroy(obj.gameObject);
        }

        manager.GetComponent<LerpRail>().returnToStart();
    }
}
