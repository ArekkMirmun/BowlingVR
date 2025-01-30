using System;
using UnityEngine;

public class PinsCheck : MonoBehaviour
{
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pin"))
        {
            PinsCanvas.Instance.NotifyPinDown();
            
            //remove pin tag
            other.gameObject.tag = "Untagged";
        }
    }
}
