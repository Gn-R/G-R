using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressSlider : MonoBehaviour
{
    [SerializeField] Slider slider;

    public void SetProgress(float percent)
    {
        slider.value = percent;
    }
}
