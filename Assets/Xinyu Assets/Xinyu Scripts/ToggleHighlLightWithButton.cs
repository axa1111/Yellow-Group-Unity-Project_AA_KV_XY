using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ToggleHighlLightWithButton : MonoBehaviour
{ 

    private bool isClicked = false; 

    public GameObject goListObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created 

    void Start() 

    { 
        transform.GetComponent<Outline>().enabled = false; 
    } 

 

    // Update is called once per frame 

    void Update() 

    { 
       
    } 

    public void ManageHighlight()
    {
        OnMouseDown();
    }

    public void OnMouseDown() 

    { 

        Debug.Log("click on object" + transform.name); 

        isClicked = !isClicked; 

        if(isClicked) 

        { 

            transform.GetComponent<Outline>().enabled = true; 
            goListObj.GetComponent<ManageHighlightedObjInListScene7>().myObjList.Add(transform.gameObject);

        } 

        else 

        { 

            transform.GetComponent<Outline>().enabled = false;
            goListObj.GetComponent<ManageHighlightedObjInListScene7>().myObjList.Remove(transform.gameObject); 

        }

    }
} 

 

 
