using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ManageHighlightedObjInListScene7 : MonoBehaviour
{
    public List<GameObject> myObjList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myObjList = new List<GameObject>();
    }

    public void ClearList()
    {   
        for  (int i = 0; i < myObjList.Count; i++)
        {
            myObjList[i].GetComponent<Outline>().enabled = false;
        }
        myObjList.Clear();
    }
}
