using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MixIngredients : MonoBehaviour
{
    //bool print_inge;
    TextMeshProUGUI dis_inge;
    public AudioSource Discard;
    float tima;

    private GameObject manager; // doesn't seem to be used

    // Start is called before the first frame update
    void Start()
    {
        dis_inge = transform.GetComponent<TextMeshProUGUI>();
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
                    string temp = "";
                    foreach (string str in Manager.Instance.combo)
                    {
                        temp += str + " ";
                    }
                    dis_inge.text = temp;

                    //print_inge = true;

                    Manager.Instance.Mixing = false;
                }

                if (Manager.Instance.discarding == true)
                {
                    Manager.Instance.Score -= 300;

                    Manager.Instance.combo.Clear();

                    dis_inge.text = "";

                    Discard.Play();

                    manager.GetComponent<DishManager>().mixBowl(true);

                    Manager.Instance.discarding = false;
                }

                tima = 3f;
            }
        }
    }
}