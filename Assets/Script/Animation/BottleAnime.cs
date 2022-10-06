using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lifts the bottle and squirts some sauce into the bowl
public class BottleAnime : MonoBehaviour
{
    private Animator animator;
    private bool squirting;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        squirting = false;
        animator.SetBool("squirt", false);
    }

    void Update()
    {
        // If squirt animation has finished
        // TODO need to create squirt animation
        if (squirting && !animator.GetBool("squirt")) {
            squirting = false;
            Debug.Log("Finish squirt");
        }
    }

    // Called in AddIngredient upon raycst
    public void OnBottleClick()
    {
        if (!squirting)
        {
            squirting = true;
            animator.SetBool("squirt", true);
            Debug.Log("Squirt bottle");
        }
    }
}
