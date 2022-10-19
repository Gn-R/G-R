using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;


public class DishManager : MonoBehaviour
{
    public string currDish = "";
    public List<string> currRecipe = new List<string>();

    public ShowRecipe showRecipe;
    public TextMeshProUGUI orderText;
    public GameObject orderTimerManager;

    public int mixes = 0;

    public Slider extraFoodSlider;


    public Coroutine showItemCoroutine;
    const float SLIDER_ANIM_SPEED = 4;
    const float SLIDER_ANIM_SECONDS = 2;

    //0 = El Jefe Freeplay, 1 = El Jefe Pro, 2 = Random Freeplay, 3 = Random Pro
    public static int gameMode = 2;

    void Start()
    {
        GetNewRecipe();
    }

    //Randomizes a new recipe for another order
    public void GetNewRecipe()
    {
        Debug.Log(gameMode);
        //Sets timer for freeplay (more time)
        if (gameMode % 2 == 0)
        {
            orderTimerManager.GetComponent<OrderTimerDebug>().StartOrderTimer(60);

        }
        //Sets timer for pro (less time)
        else
        {
            orderTimerManager.GetComponent<OrderTimerDebug>().StartOrderTimer(15);
        }

        //Sets dish only as El Jefe
        if (gameMode <= 1)
        {
            currDish = "El Jefe";
        }
        //Sets random dishes
        else
        {
            currDish = Recipes.GetRandomDish();
        }

        currRecipe = new List<string>(Recipes.GetRecipe(currDish));
        mixes = 0;
        int count = currRecipe.Count;
        string extraIngredients = "";


        //Add randomization 
        if (gameMode > 1)
        {
            for (int i = 0; i < count; i++)
            {
                int dice = Random.Range(-5, 3);
                for (int y = 0; y < dice; y++)
                {
                    currRecipe.Add(currRecipe[i]);
                    extraIngredients += currRecipe[i] + " ";
                }
            }
        }

        showRecipe.SetRecipe(currRecipe);
        // BUG: Getting null recipes
        // orderText.text = "Order: " + currDish;
        // if (!extraIngredients.Equals(""))
        // {
        //     orderText.text += " with extra " + extraIngredients;
        // }

        // StartCoroutine(ShowText());

    }

    IEnumerator ShowText()
    {
        orderText.gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        orderText.gameObject.SetActive(false);
    }

    //Returns true if the item requires an extra amount (shows a bar)
    public bool requiresExtra(string item)
    {
        int count = 0;
        foreach (string s in currRecipe)
        {
            if (item.Equals(s))
            {
                count++;
            }
        }
        return count > 1;
    }

    public IEnumerator setExtraBar(string item)
    {
        int currCount = 0;
        foreach (string s in Manager.Instance.combo)
        {
            if (item.Equals(s))
            {
                currCount++;
            }
        }

        int recipeCount = 0;
        foreach (string s in currRecipe)
        {
            if (item.Equals(s))
            {
                recipeCount++;
            }
        }

        extraFoodSlider.gameObject.SetActive(true);

        float startValue = (float)(currCount - 1) / recipeCount;
        float endValue = (float)currCount / recipeCount;

        float slider_speed = SLIDER_ANIM_SPEED;

        float timeScale = 0;
        while (timeScale < 1) {
            timeScale += Time.deltaTime * slider_speed;
            slider_speed *= .98f;
            //timeScale /= SLIDER_ANIM_SECONDS;
            //timeScale = timeScale * timeScale * (3f - 2f * timeScale);
            extraFoodSlider.value = Mathf.Lerp(startValue, endValue, timeScale);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(3);
        extraFoodSlider.gameObject.SetActive(false);
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

    public float getTimerPercentage()
    {
        return orderTimerManager.GetComponent<OrderTimerDebug>().getPercentage();
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
