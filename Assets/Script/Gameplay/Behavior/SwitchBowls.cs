using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// WORK IN PROGRESS
// TODO track ingredients added?
public class SwitchBowls : MonoBehaviour
{
    public GameObject bigBowl;
    public GameObject smallBowl;
    // public Animator bigBowlAnim;
    // public Animator smallBowlAnim;

    // private Vector3 smallBowlStart;
    // private Vector3 bigBowlStart;
    // private Vector3 discardDirection;

    private Button switchBtn;
    private bool switching;
    private int bowlMode;
    // private float animPercent;
    
    void Start()
    {
        switchBtn = GameObject.Find("Switch Bowl").GetComponent<Button>();
        switchBtn.onClick.AddListener(Switch);
        switching = false;
        bowlMode = 0;
        // animPercent = 0.0f;

        // bigBowlAnim = bigBowl.GetComponent<Animator>();
        // smallBowlAnim = smallBowl.GetComponent<Animator>();

        // smallBowlStart = smallBowl.transform.position;
        // bigBowlStart = bigBowl.transform.position;
        // discardDirection = Vector3.left * 0.5f;
    }

    void Update()
    {
        if (switching)
        {
            // animPercent += 0.1f * Time.deltaTime;
            // Debug.Log(animPercent);
            // if (animPercent >= 0.5f);
            // {
                switching = false;
            // }
        }
    }

    void Switch()
    {
        if (switching)
        {
            // wait for animation to finish
        } else
        {
            bowlMode = (bowlMode + 1) % 3;
            switching = true;
            // animPercent = 0.0f;

            if (bowlMode == 0)
            {
                Debug.Log("both");
                smallBowl.SetActive(true);
            }
            else if (bowlMode == 1)
            {
                Debug.Log("big");
                smallBowl.SetActive(false);
            }
            else if (bowlMode == 2)
            {
                Debug.Log("small");
                smallBowl.SetActive(true);
            }
        }
        
    }

    // void StartSwitch(int mode)
    // {
    //     if (mode == 0 || mode == 1) // big bowl
    //     {
    //         bigBowlAnim.SetBool("discard", true);
    //     }
    //     if (mode == 0 || mode == 2) // small bowl
    //     {
    //         smallBowlAnim.SetBool("discard", true);
    //     }
    // }
}
