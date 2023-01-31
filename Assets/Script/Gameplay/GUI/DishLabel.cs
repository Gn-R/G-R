using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Changes the image in the top right corner based on the dish
public class DishLabel : MonoBehaviour
{
    [SerializeField] Image dishLabel;
    [SerializeField] List<Sprite> sprites;

    void Start()
    {
        string recipe = DishManager.currDish;
        Debug.Log("curr dish is " + recipe);
        SetLabel(recipe); // TODO use current recipe
    }

    // Set label image based on the index in the array
    public void SetLabel(int spriteIndex)
    {
        dishLabel.sprite = sprites[spriteIndex];
    }

    // Set label image based on a part of the dish's name (see Materials/Canvas/Dish Labels)
    public void SetLabel(string spriteName)
    {
        foreach (Sprite spr in sprites)
        {
            string name = spr.name.ToLower();
            string query = spriteName.ToLower();
            if (name.Contains(query))
            {
                dishLabel.sprite = spr;
                return;
            }
        }
    }

    
}
