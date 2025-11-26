using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BacteriaShowing : MonoBehaviour
{
    public GameObject bacteriaObj;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Magnifier"))
        {
            bacteriaObj.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Magnifier"))
        {
            bacteriaObj.SetActive(false);
        }
    }
}