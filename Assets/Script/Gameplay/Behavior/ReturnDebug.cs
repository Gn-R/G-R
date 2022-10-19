using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnDebug : MonoBehaviour
{
    public GameObject mbp;
    public Button button;

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        mbp.GetComponent<LerpRail>().returnToStart();
    }
}
