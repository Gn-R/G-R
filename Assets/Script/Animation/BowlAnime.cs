using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CW.Common;

// Shakes the bowl and mixes ingredients
public class BowlAnime : MonoBehaviour
{
    private Animator bowl_anime;
    Button discBtn;
    Button fwdBtn;
    Button backBtn;
    Button resetBtn;
    public AudioSource Wood;

    void Start()
    {
        bowl_anime = GetComponent<Animator>();
        discBtn = GameObject.Find("Discard").GetComponent<Button>();
        discBtn.onClick.AddListener(DiscardClick);
        fwdBtn = GameObject.Find("Move Forward").GetComponent<Button>();
        fwdBtn.onClick.AddListener(ForwardClick);
        backBtn = GameObject.Find("Move Back").GetComponent<Button>();
        backBtn.onClick.AddListener(BackClick);
        //resetBtn = GameObject.Find("Reset").GetComponent<Button>();
        //resetBtn.onClick.AddListener(ResetClick);
    }

    //private void OnEnable()
    //{
    //    Lean.Touch.LeanTouch.OnFingerSwipe += Swipe;
    //}

    //private void OnDisable()
    //{
    //    Lean.Touch.LeanTouch.OnFingerSwipe -= Swipe;
    //}



    //puvoid Swipe(Lean.Touch.LeanFinger finger)
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
        }
    }

    void ForwardClick()
    {
        Wood.Play();
        Forward();
    }

    public void Forward()
    {
        if (!Manager.Instance.Mixing && !Manager.Instance.discarding)
        {
            Manager.Instance.forward = true;
        }
    }

    void BackClick()
    {
        Wood.Play();
        Backward();
    }

    public void Backward()
    {
        if (!Manager.Instance.Mixing && !Manager.Instance.discarding)
        {
            Manager.Instance.back = true;
        }
    }

    void Update()
    {
        // Update animator states
        bowl_anime.SetBool("shake", Manager.Instance.Mixing);
        //bowl_anime.SetBool("discard", Manager.Instance.discarding);
    }
}
