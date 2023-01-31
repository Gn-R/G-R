using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// The end screen menu manager
public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Button menuButton;
    
    void Start()
    {
        scoreText.text = "" + Manager.Instance.totalScore;
        menuButton.onClick.AddListener(ToMainMenu);
    }

    void ToMainMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
