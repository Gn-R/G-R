using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CW.Common;

// Shakes the bowl and mixes ingredients
public class BowlAnimator : MonoBehaviour
{    
    [SerializeField] GameObject bowl;
    [SerializeField] Button discardButton, leftButton, rightButton;
    private Animator animator;
    public AudioSource Wood;

    void Start()
    {
        discardButton.onClick.AddListener(DiscardClick);
        leftButton.onClick.AddListener(LeftClick);
        rightButton.onClick.AddListener(RightClick);

        animator = GetComponent<Animator>();
        Wood = GetComponent<AudioSource>();
    }

    //private void OnEnable()
    //{
    //    Lean.Touch.LeanTouch.OnFingerSwipe += Swipe;
    //}

    //private void OnDisable()
    //{
    //    Lean.Touch.LeanTouch.OnFingerSwipe -= Swipe;
    //}

    //public void Swipe(Lean.Touch.LeanFinger finger)
    //{
    //    //finger.
    //    //if (finger.RequiredAngle == 90)
    //    //{
    //    //    Debug.Log("E");
    //    //}
    //    //else if (finger.RequiredAngle == 270)
    //    //{
    //    //    Debug.Log("W");
    //    //}
    //}

    void DiscardClick()
    {
        Wood.Play();
        if (!Manager.Instance.Mixing)
        {
            Manager.Instance.discarding = true;
            bowl.GetComponent<AddIngredient>().DetachIngredient();
        }
    }

    void RightClick()
    {
        Wood.Play();
        Move(true);
    }

    void LeftClick()
    {
        Wood.Play();
        Move(false);
    }

    void Move(bool right)
    {
        if (!Manager.Instance.Mixing && !Manager.Instance.discarding)
        {
            if (right) Manager.Instance.right = true;
            else Manager.Instance.left = true;
            
            bowl.GetComponent<AddIngredient>().AttachIngredientToBowl();
        }
    }

    void Update()
    {
        // Update animator states
        animator.SetBool("shake", Manager.Instance.Mixing);
        //animator.SetBool("discard", Manager.Instance.discarding);
    }
}
