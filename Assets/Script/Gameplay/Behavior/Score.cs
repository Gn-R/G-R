using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI Number;

    // Start is called before the first frame update
    void Start()
    {
        Manager.Instance.Score = 0;
        Number.text = "Score: " + Manager.Instance.Score;
    }

    // Update is called once per frame
    void Update()
    {
        Number.text = "Score: " + Manager.Instance.Score;
    }
}
