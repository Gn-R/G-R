using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPrompts : MonoBehaviour
{
    private GameObject rail;
    [SerializeField] GameObject[] stopPrompts;
    private GameObject currPrompt;
    private int currStop = 0;
    private List<GameObject> promptList;
    private Dictionary<int, List<GameObject>> dict;
    // Start is called before the first frame update
    void Start()
    {
        dict = new Dictionary<int, List<GameObject>>();
        foreach (GameObject prompt in stopPrompts)
        {
            int point = prompt.GetComponent<Tutorial>().stopPoint;
            if (!dict.ContainsKey(point))
            {
                dict.Add(point, new List<GameObject>());
            }
            dict[point].Add(prompt);
        }

        onPointUpdate(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPointUpdate(int newStop)
    {
        currStop = newStop;
        if (currPrompt != null)
        {
            currPrompt.SetActive(false);
        }

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
        currPrompt.SetActive(true);
    }

    public void addedIngredient(string ingredient)
    {
        if (!currPrompt.name.ToLower().Contains(ingredient.ToLower())) {
            return;
        }

        promptList.RemoveAt(0);
        currPrompt.SetActive(false);
        currPrompt = null;

        onPointUpdate(currStop);
    }
}
