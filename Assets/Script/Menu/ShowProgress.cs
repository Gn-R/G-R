using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Show recipe and total progress in end scene
public class ShowProgress : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI progressText;
    [SerializeField] Slider recipeProgressSlider, totalProgressSlider;
    
    void Start()
    {
        string dishName = DishManager.currDish;
        float rcpProgress = Recipes.GetRecipe(dishName).GetProgress();
        float totProgress = Recipes.GetTotalProgress();

        progressText.text = dishName + " Progress";
        recipeProgressSlider.value = rcpProgress;
        totalProgressSlider.value = totProgress;
    }
}
