using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Texture isCompleted, notCompleted;
    [SerializeField] RawImage image;

    public void setCompletion(bool completed)
    {
        if (completed)
        {
            image.texture = isCompleted;
        }
        else
        {
            image.texture = notCompleted;
        }
    }
}
