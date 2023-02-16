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
        float rcpProgress = DishManager.GetCurrentRecipe().GetProgress();
        float totProgress = Recipes.GetTotalProgress();

        progressText.text = DishManager.currDish + " Progress";
        recipeProgressSlider.value = rcpProgress;
        totalProgressSlider.value = totProgress;
    }
}
