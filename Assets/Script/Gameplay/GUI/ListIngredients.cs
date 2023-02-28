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

    public void UpdateIngredientsAdded(string ingredient)
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

        if (textField == null)
        {
            return;
        }

        string[] lines = textField.text.Split(
            new string[] { "\n" },
            System.StringSplitOptions.None
        );

        for (int i = 0; i < lines.Length; i++) {
            if (lines[i].Contains(ingredient) && !lines[i].Contains(string.Format("<color=green>{0}</color>", ingredient)))
            {
                lines[i] = lines[i].Replace(ingredient, string.Format("<color=green>{0}</color>", ingredient));
                break;
            }
        }

        textField.text = string.Join("\n", lines);
    }

}
