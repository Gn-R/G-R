using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Lists the ingredients of the current dish
public class ListIngredients : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI baseText, toppingsText, dressingText, proteinText;
    
    void Start()
    {
        ClearText();
        UpdateRecipeIngredients();
    }

    public void ClearText() {
        baseText.text = "";
        toppingsText.text = "";
        dressingText.text = "";
        proteinText.text = "";
    }

    private void SetTextField(TextMeshProUGUI textField, params string[] lines)
    {
        string listText = "";
        foreach (string ln in lines)
        {
            listText += string.Format("• {0}\n", ln);
        }
        textField.text = listText;
    }

    public void UpdateRecipeIngredients()
    {
        Recipe recipe = DishManager.GetCurrentRecipe();
        SetTextField(baseText, recipe.bases);
        SetTextField(toppingsText, recipe.toppings);
        SetTextField(dressingText, recipe.dressing);
        SetTextField(proteinText, recipe.grill);
    }

}
