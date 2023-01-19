using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardIngeScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bowl") || other.gameObject.CompareTag("UI"))
        {

        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
