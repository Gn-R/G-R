using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Show recipe and total progress in ready scene
public class ShowProgress : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI progressText;
    [SerializeField] Slider recipeProgressSlider, totalProgressSlider;
    
    void Start()
    {
        string dishName = DishManager.currDish;
        float rcpProgress = Recipes.GetRecipeProgress(dishName);
        float totProgress = Recipes.GetTotalProgress();

        // For testing
        // rcpProgress = 1/3f;
        // totProgress = 0.5f;

        progressText.text = dishName + " Progress";
        recipeProgressSlider.value = rcpProgress;
        totalProgressSlider.value = totProgress;
    }
}
