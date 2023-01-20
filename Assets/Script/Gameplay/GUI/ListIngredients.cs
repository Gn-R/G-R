using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListIngredients : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI baseText, toppingsText, dressingText, grillText;
    
    void Start()
    {
        baseText.text = "";
        toppingsText.text = "";
        dressingText.text = "";
        grillText.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // For testing only
        {
            SetBase("Food");
            SetToppings(new List<string>() {"Food", "Flavor", "Extra Food"});
            SetDressing("Sauce");
            SetGrill("Food");
        }
    }

    public void SetBase(string baseStr) // can't use "base" as identifier
    {
        baseText.text = string.Format("• {0}", baseStr);
    }

    public void SetBases(List<string> bases)
    {
        string listText = "";
        foreach (string baseStr in bases)
        {
            listText += string.Format("• {0}\n", baseStr);
        }
        baseText.text = listText;
    }

    public void SetToppings(List<string> toppings)
    {
        string listText = "";
        foreach (string topping in toppings)
        {
            listText += string.Format("• {0}\n", topping);
        }
        toppingsText.text = listText;
    }

    public void SetDressing(string dressing)
    {
        dressingText.text = string.Format("• {0}", dressing);
    }

    public void SetGrill(string grill)
    {
        grillText.text = string.Format("• {0}", grill);
    }

}
