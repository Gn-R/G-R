using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private Manager manager;

    void Start()
    {
        manager = Manager.Instance;
        manager.Score = 0;
		
        Manager.Instance.Score = 0;
        scoreText.text = "Score: " + Manager.Instance.Score + "\nTotal Score: " + Manager.Instance.totalScore;
    }

    void Update()
    {
        scoreText.text = "Score: " + Manager.Instance.Score + "\nTotal Score: " + Manager.Instance.totalScore;
    }
}
