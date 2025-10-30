using UnityEngine;

public class MouseInputs : MonoBehaviour
{
    // This script will look at Mouse Inputs

    public GameObject objToEnable; //this is a variable
    public Color clickedColorChange; // this is a variable

    private Color oldColor;
    Color dodgerBlue = new Color(0.1176471f, 0.5647059f, 1f, 1f);
    

    Renderer rend; //Makes an instance of the renderer component of this script to access it


    void Start()
    {
        rend = GetComponent<Renderer>();
       //assigns the instance of the renderer component object we made in script memory to be the same renderer component on the object this script is attached to
        oldColor = rend.material.color;

    }

    void Update()
    {
        //KerriCustomMouseMethod();
    }

    void OnMouseEnter() //this is a method that is part of Unity's Libraries/Monobehaviour
    {
        Debug.Log("LeftMouse Button Clicked");
        //objToEnable.SetActive(true);
        rend.material.color = clickedColorChange; //;//changes the color of the material to green using the variable we assigned earlier

    }
    
    void OnMouseExit() //this is a method that is part of Unity's Libraries/Monobehaviour
    {
        Debug.Log("LeftMouse Button Clicked");
       //objToEnable.SetActive(true);
       rend.material.color = oldColor; //;//changes the color of the material to green using the variable we assigned earlier

    }

    void KerriCustomMouseMethod() //this is a custom method I am creating...but how can i get this to run?
    {
        if(Input.GetAxis("Mouse X")<0)//we are using operaters <==> to tell the system the values
        {
            Debug.Log("Mouse is moving to the left");
        }
        if(Input.GetAxis("Mouse X")==0) // == assigns a value
        {
            Debug.Log("Mouse not moving");
        }
        if(Input.GetAxis("Mouse X")>0)
        {
            Debug.Log("Mouse is moving to the right");
        }
    }
}