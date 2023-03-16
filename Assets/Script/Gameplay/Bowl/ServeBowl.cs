using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ServeBowl : MonoBehaviour
{
    [SerializeField] Button serveButton;
    [SerializeField] GameObject manager, ingredients, notAtEndMessage;
    [SerializeField] string mainGameScene, endMenuScene;

    private Coroutine endMessage;

    void Start()
    {
        serveButton.onClick.AddListener(OnServeBowl);
    }

    void OnServeBowl()
    {
        // TODO make sure player is at end of rail
        // SceneManager.LoadScene(mainGameScene);
        bool hasCorrectCombo = CheckCombo();
        EndLevel(hasCorrectCombo);
    }

    bool CheckCombo()
    {
        return DishManager.CheckFinalCombo(Manager.Instance.combo);
    }

    void EndLevel(bool pass)
    {
        DishManager.SetLevelSuccess(pass);
        if (pass) DishManager.GetCurrentRecipe().IncreaseLevel();
        SceneManager.LoadScene(endMenuScene);
    }    

    // void TaskOnClick()
    // {
    //     if (!manager.GetComponent<LerpRail>().isAtEnd())
    //     {
    //         if (endMessage != null)
    //         {
    //             StopCoroutine(endMessage);
    //         }
    //         endMessage = StartCoroutine(ShowNotAtEndMessage());
    //         return;
    //     }

    //     // foreach (string str in Manager.Instance.combo)
    //     // {
    //     //     Debug.Log(str);
    //     // }

    //     if (DishManager.CheckFinalCombo(Manager.Instance.combo))
    //     {
    //         Manager.Instance.totalScore += (int) (Manager.Instance.Score * Manager.Instance.ScoreMult);
    //     }
    //     else
    //     {;
    //         Manager.Instance.totalScore = Manager.Instance.Score;
    //     }

    //     SceneManager.LoadScene(endMenuScene);

    //     foreach (Transform obj in ingredients.transform)
    //     {
    //         Destroy(obj.gameObject);
    //     }

    //     manager.GetComponent<LerpRail>().returnToStart();
    // }

    private IEnumerator ShowNotAtEndMessage()
    {
        notAtEndMessage.SetActive(true);
        yield return new WaitForSeconds(3f);
        notAtEndMessage.SetActive(false);
    }

}
