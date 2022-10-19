using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiscardScript : MonoBehaviour
{
    Button discBtn;
    Button fwdBtn;
    Button backBtn;
    Button resetBtn;

    public GameObject manager;

    private Coroutine discardCoroutine;

    void Start()
    {
        discBtn = GameObject.Find("Discard").GetComponent<Button>();
        discBtn.onClick.AddListener(DiscardClick);
        fwdBtn = GameObject.Find("Move Forward").GetComponent<Button>();
        fwdBtn.onClick.AddListener(ForwardClick);
        backBtn = GameObject.Find("Move Back").GetComponent<Button>();
        backBtn.onClick.AddListener(BackClick);
    }

    void DiscardClick()
    {
        if (!Manager.Instance.Mixing)
        {
            Manager.Instance.discarding = true;
            if (discardCoroutine != null)
            {
                StopCoroutine(discardCoroutine);
            }
            discardCoroutine = StartCoroutine(DiscardAnim());
        }
    }

    void ForwardClick()
    {
        if (!Manager.Instance.Mixing && !Manager.Instance.discarding)
        {
            Manager.Instance.forward = true;
        }
    }

    void BackClick()
    {
        if (!Manager.Instance.Mixing && !Manager.Instance.discarding)
        {
            Manager.Instance.back = true;
        }
    }

    private IEnumerator DiscardAnim()
    {
        Vector3 rot = manager.GetComponent<LerpRail>().GetCurrentPoint().GetChild(1).rotation.eulerAngles;
        Vector3 finalPos;
        Vector3 originalPos = transform.position;
        //Default rotation
        if (rot.y > -10 && rot.y < 10)
        {
            finalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + -0.75f);
        }
        //-90 for Y = right side rotation
        else
        {
            finalPos = new Vector3(transform.position.x + .75f, transform.position.y, transform.position.z);
        }

        Debug.Log("start");
        for (int i = 0; i < 100; i++)
        {
            transform.position = Vector3.Lerp(originalPos, finalPos, i / 100.0f);
            yield return new WaitForSeconds(0.01f);
            Debug.Log(transform.position);
        }

        transform.position = finalPos;

        for (int i = 0; i < 100; i++)
        {
            transform.position = Vector3.Lerp(finalPos, originalPos, i / 100.0f);
            yield return new WaitForSeconds(0.01f);
        }

        transform.position = originalPos;

        discardCoroutine = null;
    }
}

