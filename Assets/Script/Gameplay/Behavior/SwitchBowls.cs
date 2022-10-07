using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchBowls : MonoBehaviour
{
    public GameObject[] bowls;
    private Button discBtn;
    private int bowlIndex;
    
    void Start()
    {
        discBtn = GameObject.Find("Switch Bowl").GetComponent<Button>();
        discBtn.onClick.AddListener(Switch);
        bowlIndex = 0;
    }

    void Update()
    {
        
    }

    void Switch() {
        bowlIndex = (bowlIndex + 1) % bowls.Length;
        Debug.Log(bowls[bowlIndex].name);
    }
}
