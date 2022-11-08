using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Button menuButton;
    
    void Start()
    {
        scoreText.text = "Final Score: " + Manager.Instance.totalScore;
        menuButton.onClick.AddListener(ToMainMenu);
    }

    void ToMainMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
