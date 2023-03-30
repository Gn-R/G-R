using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ServeBowl : MonoBehaviour
{
    [SerializeField] Button serveButton;
    [SerializeField] GameObject manager, ingredients, notAtEndMessage;
    [SerializeField] GameObject tutorialPrompts;

    private Coroutine endMessage;

    void Start()
    {
        serveButton.onClick.AddListener(OnServeBowl);
    }

    void OnServeBowl()
    {
        // TODO make sure player is at end of rail
        bool hasCorrectCombo = CheckCombo();
        EndLevel(hasCorrectCombo);
        tutorialPrompts.GetComponent<TutorialPrompts>().uiHit("Serve");
    }

    bool CheckCombo()
    {
        return DishManager.CheckFinalCombo(Manager.Instance.combo);
    }

    void EndLevel(bool pass)
    {
        DishManager.SetLevelSuccess(pass);
        if (pass) DishManager.GetCurrentRecipe().IncreaseLevel();
        SceneManager.LoadScene("End Scene");
    }    

    void TaskOnClick()
    {
        if (!manager.GetComponent<LerpRail>().isAtEnd())
        {
            if (endMessage != null)
            {
                StopCoroutine(endMessage);
            }
            endMessage = StartCoroutine(ShowNotAtEndMessage());
            return;
        }

        // foreach (string str in Manager.Instance.combo)
        // {
        //     Debug.Log(str);
        // }

        if (DishManager.CheckFinalCombo(Manager.Instance.combo))
        {
            Manager.Instance.totalScore += (int) (Manager.Instance.Score * Manager.Instance.ScoreMult);
        }
        else
        {;
            Manager.Instance.totalScore = Manager.Instance.Score;
        }

        SceneManager.LoadScene("End Scene");

        foreach (Transform obj in ingredients.transform)
        {
            Destroy(obj.gameObject);
        }

        manager.GetComponent<LerpRail>().returnToStart();
    }

    private IEnumerator ShowNotAtEndMessage()
    {
        notAtEndMessage.SetActive(true);
        yield return new WaitForSeconds(3f);
        notAtEndMessage.SetActive(false);
    }
}
