using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Script_FadePanelInactive : MonoBehaviour
{
    public GameObject panelObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SetPanelInactive());
    }

    private IEnumerator
    SetPanelInactive()
    {
        yield return new
        WaitForSeconds(1.0f);
        panelObj.SetActive(false);
    }

}
