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
        // For testing only
        string recipe = "roots bowl"; // TODO ingredients from current dish
        ShowRecipeIngredients(recipe);
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

    public void ShowRecipeIngredients(string recipeName)
    {
        Recipe recipe = Recipes.GetRecipe(recipeName);
        SetTextField(baseText, recipe.bases);
        SetTextField(toppingsText, recipe.toppings);
        SetTextField(dressingText, recipe.dressing);
        SetTextField(proteinText, recipe.grill);
    }

    public void UpdateIngredientsAdded()
    {
        foreach (string ingredient in Manager.Instance.combo)
        {
            TextMeshProUGUI textField = null;

            switch(ingredient)
            {
                case string a when baseText.text.Contains(a):
                    textField = baseText;
                    break;
                case string b when toppingsText.text.Contains(b):
                    textField = toppingsText;
                    break;
                case string c when dressingText.text.Contains(c):
                    textField = dressingText;
                    break;
                case string d when proteinText.text.Contains(d):
                    textField = proteinText;
                    break;
            }

            if (textField != null && !textField.text.Contains(string.Format("<color=green>{0}</color>", ingredient)))
                textField.text = textField.text.Replace(ingredient, string.Format("<color=green>{0}</color>", ingredient));
        }
    }

}
