using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI Number;

    void Start()
    {
        Manager.Instance.Score = 0;
        Number.text = "Score: " + Manager.Instance.Score;
    }

    void Update()
    {
        Number.text = "Score: " + Manager.Instance.Score;
    }
}
