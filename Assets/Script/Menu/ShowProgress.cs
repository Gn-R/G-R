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
        float recipeProgress = DishManager.GetCurrentRecipe().GetProgress();
        float totalProgress = Recipes.GetTotalProgress();

        progressText.text = DishManager.GetCurrentDish() + " Progress";
        recipeProgressSlider.value = recipeProgress;
        totalProgressSlider.value = totalProgress;
    }
}
