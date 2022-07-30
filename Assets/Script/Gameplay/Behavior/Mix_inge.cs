using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mix_inge : MonoBehaviour
{
    //bool print_inge;
    TextMeshProUGUI dis_inge;
    public AudioSource Discard;
    float tima;

    void Start()
    {
        dis_inge = transform.GetComponent<TextMeshProUGUI>();
        Discard.GetComponent<AudioSource>();
        tima = 3f;
    }

    void Update()
    {
        if (Manager.Instance.Adding == true || Manager.Instance.Mixing == true || Manager.Instance.Discarding == true)
        {
            if (Manager.Instance.Adding == true) // Update ingredients list when adding
            {
                string temp = "";
                foreach (string str in Manager.Instance.combo)
                {
                    temp += str + " ";
                }
                dis_inge.text = temp;

                Manager.Instance.Adding  = false;
                return;
            }
            
            //bowl_anime.SetBool("shake", true);
            if (tima > 0f)
            {
                tima -= Time.deltaTime;
            }
            else 
            {
                
                if ( Manager.Instance.Mixing == true) // Show ingredients list when matching
                {
                // Not needed any more since list dynamically updates
                //     string temp = "";
                //     foreach (string str in Manager.Instance.combo)
                //     {
                //         temp += str + " ";
                //     }
                //     dis_inge.text = temp;

                //     //print_inge = true;

                    Manager.Instance.Mixing = false;
                }

                if (Manager.Instance.Discarding == true) // Empty ingredients list when discarding
                {
                    Manager.Instance.Score -= 300;

                    dis_inge.text = "";

                    Discard.Play();

                    Manager.Instance.Discarding = false;
                }

                tima = 3f;
            }
        }
    }
}