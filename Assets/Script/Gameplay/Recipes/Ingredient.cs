using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An ingredient that can be added to the bowl when clicked
public class Ingredient : MonoBehaviour
{   
    [SerializeField] string ingredientName;
    [SerializeField] GameObject ingredientPrefab;
    [SerializeField] int prefabCount = 1;
    [SerializeField] Vector3 textOffset = new Vector3(0, 0, 0);
    [SerializeField] bool isLiquid = false;
    [SerializeField] Color color = new Color(1, 1, 1);

    public string GetName()
    {
        return ingredientName;
    }

    public GameObject GetPrefab()
    {
        return ingredientPrefab;
    }

    public int GetCount()
    {
        return prefabCount;
    }

    public Vector3 GetOffset()
    {
        return textOffset;
    }

    public bool IsLiquid()
    {
        return isLiquid;
    }

    public Color GetColor()
    {
        return color;
    }
}
