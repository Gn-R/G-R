using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DishManager : MonoBehaviour
{
    public List<string> currRecipe = new List<string>();

    public GameObject Recipe_hint;

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
        currRecipe = new List<string>(Recipes.getRandomBowl());
        mixes = 0;
        //Add randomization

        Recipe_hint.GetComponent<Recipe_hint>().setRecipe(currRecipe);
    }

    //Returns whether or not the dish was correct
    public bool checkDish(List<string> combo)
    {
        //Order does not matter
        return ScrambledEquals(currRecipe, combo) && mixes == 3;
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

    public static bool ScrambledEquals<T>(IEnumerable<T> list1, IEnumerable<T> list2)
    {
        Dictionary<T, int> cnt = new Dictionary<T, int>();
        foreach (T s in list1)
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
        foreach (T s in list2)
        {
            if (cnt.ContainsKey(s))
            {
                cnt[s]--;
            }
            else
            {
                return false;
            }
        }
        return cnt.Values.All(c => c == 0);
    }
}
