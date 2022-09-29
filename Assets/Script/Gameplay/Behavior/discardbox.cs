using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardBox : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("MainBowl"))
        {
            
        }
        else if (other.gameObject.name.Contains("SmallBowl"))
        {

        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
