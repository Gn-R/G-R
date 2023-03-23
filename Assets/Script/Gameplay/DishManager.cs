using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class DishManager : MonoBehaviour
{
    private static string currDish = "";
    private static bool success; // user passed current level
    private static List<string> currIngredients = new List<string>();
    private static int mixes = 0;

    public TextMeshProUGUI orderText;
    public GameObject orderTimerManager;
    public Slider extraFoodSlider;

    public Coroutine showItemCoroutine;
    const float SLIDER_ANIM_SPEED = 4;
    const float SLIDER_ANIM_SECONDS = 2;

    void Start()
    {
        Manager.Instance.totalScore = 0;
        if (currDish.Equals("")) SetRecipe("G & R Bowl 2");
    }

    public static void SetRecipe(string recipe)
    {
        currDish = recipe;
        currIngredients = Recipes.GetRecipe(currDish).GetIngredients();
        mixes = 0;
    }

    IEnumerator ShowText()
    {
        orderText.gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        orderText.gameObject.SetActive(false);
    }

    public void StartOrderTimer(int seconds) {
        orderTimerManager.GetComponent<OrderTimerDebug>().StartOrderTimer(seconds);
    }

    public void RandomizeRecipe()
    {
        int count = currIngredients.Count;
        string extraIngredients = "";

        for (int i = 0; i < count; i++)
        {
            int dice = Random.Range(-5, 3);
            for (int y = 0; y < dice; y++)
            {
                currIngredients.Add(currIngredients[i]);
                extraIngredients += currIngredients[i] + " ";
            }
        }
    }

    //Returns true if the item requires an extra amount (shows a bar)
    public static bool RequiresExtra(string item)
    {
        int count = 0;
        foreach (string s in currIngredients)
        {
            if (item.Equals(s))
            {
                count++;
            }
        }
        return count > 1;
    }

    public IEnumerator SetExtraBar(string item)
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
        foreach (string s in currIngredients)
        {
            if (item.Equals(s))
            {
                recipeCount++;
            }
        }

        //extraFoodSlider.gameObject.SetActive(true);

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

    // Getter Methods

    public static string GetCurrentDish()
    {
        return currDish;
    }

    public static Recipe GetCurrentRecipe()
    {
        return Recipes.GetRecipe(currDish);
    }

    public float GetTimerPercentage()
    {
        return orderTimerManager.GetComponent<OrderTimerDebug>().getPercentage();
    }

    public static int GetMixes()
    {
        return mixes;
    }

    public static bool GetLevelSuccess()
    {
        return success;
    }

    public static void SetLevelSuccess(bool success)
    {
        DishManager.success = success;
    }

    public static void MixBowl()
    {
        mixes++; // increase mixes by 1
    }

    public static void ResetMixes()
    {
        mixes = 0; // reset mixes
    }

    // Check Ingredient Methods

    // Checks if ingredient is in dish
    public static bool CheckIngredient(string ing)
    {
        return currIngredients.Contains(ing);
    }

    // Checks if the ingredients in it are valid so far and gives points (if empty, remove points)
    public static bool CheckPartialCombo(List<string> combo)
    {
        return combo.Count > 0 && ScrambledEquals(combo, currIngredients, false);
    }

    // Check if the full dish was correct
    public static bool CheckFinalCombo(List<string> combo)
    {
        //Order does not matter
        return ScrambledEquals(currIngredients, combo, true) && mixes >= 1;
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
