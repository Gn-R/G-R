using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Shows hints when the "Hint" button is pressed
public class ShowHints : MonoBehaviour
{
    [SerializeField] GameObject addIngredients;
    [SerializeField] Button hintButton;
    [SerializeField] List<GameObject> hintBoxes;
    private int maxHints, hintsLeft;
    
    void Start()
    {
        maxHints = hintBoxes.Count;
        hintsLeft = maxHints;
    }

    public void ShowHint() {
        // Deplete remaining hints
        if (hintsLeft <= 0) return;
        hintsLeft--;
        hintBoxes[hintsLeft].SetActive(false);
        addIngredients.GetComponent<AddIngredient>().ShowHint(3);
        
        // Do something based on difficulty
    }
}
