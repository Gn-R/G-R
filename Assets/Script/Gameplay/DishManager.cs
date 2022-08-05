using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;


public class DishManager : MonoBehaviour
{
    public string currDish = "";
    public List<string> currRecipe = new List<string>();

    public GameObject Recipe_hint;
    public TextMeshProUGUI orderText;

    public int mixes = 0;

    // Start is called before the first frame update
    void Awake()
    {
        getNewRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Randomizes a new recipe for another order
    public void getNewRecipe()
    {
        currDish = Recipes.getRandomDish();
        currRecipe = new List<string>(Recipes.getRecipe(currDish));
        mixes = 0;
        int count = currRecipe.Count;
        string extraIngredients = "";
        //Add randomization
        for (int i = 0; i < count; i++)
        {
            int dice = Random.Range(-5, 3);
            for (int y = 0; y < dice; y++)
            {
                currRecipe.Add(currRecipe[i]);
                extraIngredients += currRecipe[i] + " ";
            }
        }

        Recipe_hint.GetComponent<Recipe_hint>().setRecipe(currRecipe);
        if (!extraIngredients.Equals(""))
        {
            orderText.text = "Order: " + currDish + " with extra " + extraIngredients;
        }
        else
        {
            orderText.text = "Order: " + currDish;
        }

        StartCoroutine(ShowText());

    }

    IEnumerator ShowText()
    {
        orderText.gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        orderText.gameObject.SetActive(false);
    }

    //Returns whether or not the dish was correct
    public bool checkDish(List<string> combo)
    {
        //Order does not matter
        return ScrambledEquals(currRecipe, combo, true) && mixes == 3;
    }

    //If not reset, increase by 1. Otherwise, set mixes to 0.
    public void mixBowl(bool reset)
    {
        if (reset)
        {
            mixes = 0;
        }
        else
        {
            mixes++;
        }
    }

    //Checks if the ingredients in it are valid so far and gives points (if empty, remove points)
    public bool checkMix(List<string> combo)
    {
        return combo.Count > 0 && ScrambledEquals(combo, currRecipe, false);
    }

    //Matches lists without order
    //If complete match, must have same set of items. If not, fullList must contain all partialList items
    public static bool ScrambledEquals<T>(IEnumerable<T> partialList, IEnumerable<T> fullList, bool completeMatch)
    {
        Dictionary<T, int> cnt = new Dictionary<T, int>();
        foreach (T s in partialList)
        {
            if (cnt.ContainsKey(s))
            {
                cnt[s]++;
            }
            else
            {
                cnt.Add(s, 1);
            }
        }
        foreach (T s in fullList)
        {
            if (cnt.ContainsKey(s))
            {
                cnt[s]--;
            }
            else if (completeMatch)
            {
                return false;
            }
        }
        return cnt.Values.All(c => c <= 0);
    }
}
