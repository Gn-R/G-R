using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPrompts : MonoBehaviour
{
    private GameObject rail;
    [SerializeField] GameObject[] stopPrompts;
    [SerializeField] GameObject[] stopPrompts2;
    private GameObject currPrompt;
    private int currStop = 0;
    private List<GameObject> promptList;
    //private List<GameObject> promptList2;
    private Dictionary<int, List<GameObject>> dict;
    private bool isset = false;
    // Start is called before the first frame update
    void Start()
    {
        isset = false;

        dict = new Dictionary<int, List<GameObject>>();
        foreach (GameObject prompt in stopPrompts)
        {
            Debug.Log(DishManager.GetCurrentDish());
            int point = prompt.GetComponent<Tutorial>().stopPoint;
            if (!System.Array.Exists(prompt.GetComponent<Tutorial>().recipesAttached, e => e.Equals(DishManager.GetCurrentDish()))) {
                continue;
            }

            if (!dict.ContainsKey(point))
            {
                dict.Add(point, new List<GameObject>());
            }
            dict[point].Add(prompt);
        }

        foreach (int point in dict.Keys) {
            onPointUpdate(point);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Manager.Instance.bowltest == 1 && isset == false)
        //{
            
        //}
        //else if (Manager.Instance.bowltest == 2 && isset == false)
        //{
        //    dict = new Dictionary<int, List<GameObject>>();
        //    foreach (GameObject prompt in stopPrompts2)
        //    {
        //        foreach (int point in prompt.GetComponent<Tutorial>().stopPoints)
        //        {
        //            if (!dict.ContainsKey(point))
        //            {
        //                dict.Add(point, new List<GameObject>());
        //            }
        //            dict[point].Add(prompt);
        //        }
        //    }
        //    onPointUpdate(1);
        //    isset = true;
        //}

    }

    public void onPointUpdate(int newStop)
    {
        currStop = newStop;
        //if (currPrompt != null)
        //{
        //    currPrompt.SetActive(false);
        //}

        if (!dict.ContainsKey(newStop))
        {
            currPrompt = null;
            return;
        }
        promptList = dict[newStop];
        if (promptList.Count <= 0)
        {
            return;
        }

        currPrompt = promptList[0];
        if (currPrompt == null)
        {
            promptList.RemoveAt(0);
            onPointUpdate(newStop);
            return;
        }
        currPrompt.SetActive(true);
    }

    public void addedIngredient(string ingredient)
    {
        foreach (int point in dict.Keys)
        {
            foreach (GameObject prompt in dict[point])
            {
                if (prompt == null || !prompt.name.ToLower().Contains(ingredient.ToLower()))
                {
                    continue;
                }
                Debug.Log(ingredient);

                dict[point].RemoveAt(0);
                //currPrompt.SetActive(false);
                Destroy(prompt);
                //currPrompt = null;

                onPointUpdate(point);
                return;
            }
        }
    }
}
