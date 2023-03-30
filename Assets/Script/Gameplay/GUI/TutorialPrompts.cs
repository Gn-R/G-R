using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPrompts : MonoBehaviour
{
    private GameObject rail;
    [SerializeField] GameObject[] stopPrompts;
    [SerializeField] GameObject[] uiPrompts;
    private GameObject currPrompt;
    private int currStop = 0;
    private List<GameObject> promptList;
    //private List<GameObject> promptList2;
    private Dictionary<int, List<GameObject>> dict;
    private Dictionary<int, List<GameObject>> dictUI;
    private bool isset = false;

    private GameObject currUI;
    // Start is called before the first frame update
    void Start()
    {
        Recipe currRecipe = DishManager.GetCurrentRecipe();
        int lastLevel = currRecipe.GetLevelsCompleted();
        if (lastLevel >= 1)
        {
            return;
        }

        isset = false;

        dict = new Dictionary<int, List<GameObject>>();
        foreach (GameObject prompt in stopPrompts)
        {
            //Debug.Log(DishManager.GetCurrentDish());
            int point = prompt.GetComponent<Tutorial>().stopPoint;
            //If the current recipe does not have the ingredient, do not add it to the active dictionary/list
            //if (!System.Array.Exists(prompt.GetComponent<Tutorial>().recipesAttached, e => e.Equals(DishManager.GetCurrentDish())))
            //{
            //    continue;
            //}

            //Add prompt to dictionary
            if (!dict.ContainsKey(point))
            {
                dict.Add(point, new List<GameObject>());
            }
            dict[point].Add(prompt);
        }

        dictUI = new Dictionary<int, List<GameObject>>();
        foreach (GameObject prompt in uiPrompts)
        {
            //Debug.Log(DishManager.GetCurrentDish());
            int point = prompt.GetComponent<Tutorial>().stopPoint;
            //If the current recipe does not have the ingredient, do not add it to the active dictionary/list
            //if (!System.Array.Exists(prompt.GetComponent<Tutorial>().recipesAttached, e => e.Equals(DishManager.GetCurrentDish())))
            //{
            //    continue;
            //}

            //Add prompt to dictionary
            if (!dictUI.ContainsKey(point))
            {
                dictUI.Add(point, new List<GameObject>());
            }
            dictUI[point].Add(prompt);
        }

        //Put a prompt in each stop
        for (int i = 0; i < rail.GetComponent<LerpRail>().stopPoints.Length; i++)
        {
            onPointUpdate(i);
        }
        onUIUpdate(1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onPointUpdate(int newStop)
    {
        Recipe currRecipe = DishManager.GetCurrentRecipe();
        int lastLevel = currRecipe.GetLevelsCompleted();
        if (lastLevel > 0)
        {
            return;
        }

        //currStop = newStop;

        //If stop does not exist, also return
        if (!dict.ContainsKey(newStop))
        {
            currPrompt = null;
            return;
        }

        //If list empty, return
        promptList = dict[newStop];
        if (promptList.Count <= 0)
        {
            return;
        }

        //If prompt does not exist, remove it and re-run the function
        currPrompt = promptList[0];
        if (currPrompt == null)
        {
            promptList.RemoveAt(0);
            onPointUpdate(newStop);
            return;
        }

        //Set stop's current prompt
        currPrompt.SetActive(true);
    }

    public void addedIngredient(string ingredient)
    {
        Recipe currRecipe = DishManager.GetCurrentRecipe();
        int lastLevel = currRecipe.GetLevelsCompleted();
        if (lastLevel > 0)
        {
            return;
        }


        // Verifies if the added ingredient is a prompt. If so, destroy it
        foreach (int point in dict.Keys)
        {
            foreach (GameObject prompt in dict[point])
            {
                Debug.Log(ingredient + " " + prompt.name);
                if (prompt == null || !prompt.name.ToLower().Contains(ingredient.ToLower()))
                {
                    continue;
                }
                Debug.Log(ingredient);

                dict[point].RemoveAt(0);
                Destroy(prompt);

                onPointUpdate(point);
                return;
            }
        }
    }

    public void onUIUpdate(int newStop)
    {
        if (currUI != null)
        {
            currUI.SetActive(false);
        }

        currStop = newStop;

        if (dictUI.ContainsKey(newStop))
        {

            //If list empty, return
            promptList = dictUI[newStop];
            if (promptList.Count <= 0)
            {
                return;
            }

            currUI = dictUI[newStop][0];
            if (currUI == null)
            {
                dictUI[newStop].RemoveAt(0);
                onPointUpdate(newStop);
                return;
            }
            currUI.SetActive(true);
        }
    }

    public void uiHit(string action)
    {
        if (dictUI.ContainsKey(currStop) && currUI.name.ToLower().Contains(action.ToLower()))
        {
            Destroy(dictUI[currStop][0]);
            dictUI[currStop].RemoveAt(0);

            onUIUpdate(currStop);
        }
    }
}
