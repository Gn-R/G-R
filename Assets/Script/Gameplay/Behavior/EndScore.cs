using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text += " " + Manager.Instance.totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
