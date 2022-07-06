using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Anime : MonoBehaviour
{
    private Animator bowl_anime;
    Button disbutton;
    Button forbu;
    Button backbu;
    Button resetbu;

    // Start is called before the first frame update
    void Start()
    {
        bowl_anime = GetComponent<Animator>();
        disbutton = GameObject.Find("Discard").GetComponent<Button>();
        disbutton.onClick.AddListener(OnButtonClick);
        forbu = GameObject.Find("Forward").GetComponent<Button>();
        forbu.onClick.AddListener(ForwardClick);
        backbu = GameObject.Find("Back").GetComponent<Button>();
        backbu.onClick.AddListener(BackClick);
        resetbu = GameObject.Find("Reset").GetComponent<Button>();
        resetbu.onClick.AddListener(resetClick);
    }

    void OnButtonClick()
    {
        if (Manager.Instance.Mixing == false)
        {
            Manager.Instance.discarding = true;
        }
    }

    void ForwardClick()
    {
        if (Manager.Instance.Mixing == false && Manager.Instance.discarding == false)
        {
            Manager.Instance.forward = true;
        }
    }

    void BackClick()
    {
        if (Manager.Instance.Mixing == false && Manager.Instance.discarding == false)
        {
            Manager.Instance.back = true;
        }
    }

    void resetClick()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Instance.Mixing == true)
        {
            bowl_anime.SetBool("shake", true);
        }
        else
        {
            bowl_anime.SetBool("shake", false);
        }

        if (Manager.Instance.discarding == true)
        {
            bowl_anime.SetBool("discard", true);
        }
        else
        {
            bowl_anime.SetBool("discard", false);
        }
    }
}
