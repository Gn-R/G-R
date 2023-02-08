using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPrompts : MonoBehaviour
{
    private GameObject rail;
    private List<List<GameObject>> stopPrompts;
    private List<GameObject> currPrompts;
    private GameObject currPrompt;
    private int currStop;
    // Start is called before the first frame update
    void Start()
    {
        stopPrompts = new List<List<GameObject>>(rail.GetComponent<LerpRail>().points.Length);
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

        currPrompts = stopPrompts[currStop];
        if (currPrompts.Count <= 0)
        {
            return;
        }

        GameObject prompt = currPrompts[0];
        prompt.SetActive(true);
    }

    public void addedIngredient(string ingredient)
    {
        if (!currPrompt.name.Contains(ingredient.ToLower())) {
            return;
        }

        currPrompts.RemoveAt(0);
        currPrompt.SetActive(false);
        currPrompt = null;

        onPointUpdate(currStop);
    }
}
