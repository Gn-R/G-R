using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnDebug : MonoBehaviour
{
    public GameObject mbp;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (Manager.Instance.paused) return;
        
        mbp.GetComponent<LerpRail>().returnToStart();
    }
}
