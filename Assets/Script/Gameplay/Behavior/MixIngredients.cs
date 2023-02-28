using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MixIngredients : MonoBehaviour
{
    //bool print_inge;
    //TextMeshProUGUI dis_inge;
    public AudioSource Discard;
    float tima;

    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        //dis_inge = transform.GetComponent<TextMeshProUGUI>();
        Discard.GetComponent<AudioSource>();
        tima = 3f;
    }

    // Update is called once per frame
    void Update()
    {        
        if (Manager.Instance.paused == false && (Manager.Instance.Mixing == true || Manager.Instance.discarding == true))
        {
            //bowl_anime.SetBool("shake", true);
            if (tima > 0f)
            {
                tima -= Time.deltaTime;
            }
            else 
            {
                if (Manager.Instance.Mixing == true)
                {
                    //string temp = "";
                    //foreach (string str in Manager.Instance.combo)
                    //{
                    //    temp += str + ", ";
                    //}

                    //Remove the last ", "
                    //if (temp.Length > 0)
                    //    temp = temp.Substring(0, temp.Length - 2);

                    //dis_inge.text = temp;

                    //print_inge = true;

                    Manager.Instance.Mixing = false;

                    if (DishManager.CheckPartialCombo(Manager.Instance.combo))
                    {
                        Manager.Instance.Score += 200;
                    }
                    else
                    {
                        Manager.Instance.Score -= 200;
                    }
                }

                if (Manager.Instance.discarding == true)
                {
                    Manager.Instance.Score = 0;

                    Manager.Instance.combo.Clear();

                    //dis_inge.text = "";

                    Discard.Play();

                    // DishManager.ResetMixes();
                }

                tima = 3f;
            }
        }
    }
}