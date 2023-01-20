using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Shows hints when the "Hint" button is pressed
public class ShowHints : MonoBehaviour
{
    [SerializeField] Button hintButton;
    [SerializeField] List<GameObject> hintBoxes;
    private int maxHints, hintsLeft;
    
    void Start()
    {
        maxHints = hintBoxes.Count;
        hintsLeft = maxHints;
    }

    public void ShowHint() {
        if (hintsLeft <= 0) return;
        hintsLeft--;
        hintBoxes[hintsLeft].SetActive(false);
    }
}
