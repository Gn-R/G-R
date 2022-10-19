using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Shakes the bowl and mixes ingredients
public class BowlAnime : MonoBehaviour
{
    private Animator bowl_anime;
    Button discBtn;
    Button fwdBtn;
    Button backBtn;
    Button resetBtn;

    void Start()
    {
        bowl_anime = GetComponent<Animator>();
        discBtn = GameObject.Find("Discard").GetComponent<Button>();
        discBtn.onClick.AddListener(DiscardClick);
        fwdBtn = GameObject.Find("Move Forward").GetComponent<Button>();
        fwdBtn.onClick.AddListener(ForwardClick);
        backBtn = GameObject.Find("Move Back").GetComponent<Button>();
        backBtn.onClick.AddListener(BackClick);
    }

    void DiscardClick()
    {
        if (!Manager.Instance.Mixing)
        {
            Manager.Instance.discarding = true;
        }
    }

    void ForwardClick()
    {
        if (!Manager.Instance.Mixing && !Manager.Instance.discarding)
        {
            Manager.Instance.forward = true;
        }
    }

    void BackClick()
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
