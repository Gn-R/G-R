using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point_move: MonoBehaviour
{
    TextMeshProUGUI textMesh;
    float timer;
    Vector3 dir;
    Color textColor;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshProUGUI>();
        textColor = textMesh.color;
        timer = 1f;
    }

    void Update()
    {
        //if (Time.time >= timer)
        //{
        //    timer = Time.time + 0.8f;
        //    dir = new Vector3(0, 0.8f, 0);
        //}
        transform.position += new Vector3(0, 1f, 0) * Time.deltaTime;
        //transform.Translate(dir * Time.deltaTime);
        //transform.Rotate(0, 0, 240 * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            float dis = 2f;
            textColor.a -= dis * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

