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
        fwdBtn = GameObject.Find("Forward").GetComponent<Button>();
        fwdBtn.onClick.AddListener(ForwardClick);
        backBtn = GameObject.Find("Back").GetComponent<Button>();
        backBtn.onClick.AddListener(BackClick);
        resetBtn = GameObject.Find("Reset").GetComponent<Button>();
        resetBtn.onClick.AddListener(ResetClick);
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

    void ResetClick()
    {
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        // Update animator states
        bowl_anime.SetBool("shake", Manager.Instance.Mixing);
        //bowl_anime.SetBool("discard", Manager.Instance.discarding);
    }
}
