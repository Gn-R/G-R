using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class discardbox : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("MainBowl"))
        {
            
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
