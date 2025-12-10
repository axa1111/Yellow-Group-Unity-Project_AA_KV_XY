using System.Collections.Generic;
using UnityEngine;

//it was first using arrays and the had t change to list as items would be added afer
//sits on mainCameraObj
//keeps track of objs which can be interacted with
//highlights items when ray hits them by turning outlline on
public class RayCastManager : MonoBehaviour
{

    private float maxDistance = 4f; //setting max distance of ray
    public RaycastHit hit; //declaring variable RayCastHit as hit


    [Header("Obj to interact with")] //header for neatness

    //list of interactable objs in the scene
    [SerializeField]
    private List<GameObject> interactableObjects = new List<GameObject>(); 

    //list of the scripts attatched to the interactable objs
    private List<HighlightItems> highlightItems = new List<HighlightItems>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //clear the list
        highlightItems.Clear();

        //foreach interactable obj 
        for (int i = 0; i < interactableObjects.Count; i++)
        {
            //if its not active skip it

            if (!interactableObjects[i].activeInHierarchy)
                continue;

            //get the highlightItems script component 
            HighlightItems h = interactableObjects[i].GetComponent<HighlightItems>();

           // if it doesn't exist move ont
            if (h == null)
                continue;
            //add the components to that list 
            highlightItems.Add(h);
        }
    }


    void Update()
    {
        //for every item in highlight items list
        for (int i = 0; i < highlightItems.Count; i++)
        {
            //if any are null continue
            if (highlightItems[i] == null)
                continue;

            //if they are not active still continue
            if (!highlightItems[i].gameObject.activeInHierarchy)
                continue;
            //turn off the outline
            highlightItems[i].TurnOutlineOff();
        }

        //create ray from camera going in forward direction
        Ray ray = new Ray(transform.position, transform.forward); // creating ray then setting ray direction to forward

        //if the ray hits something within the max distance
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Debug.Log("RaycastHit" + hit.collider.transform.name);
            //for every item in highlightItems List
            for (int i = 0; i < highlightItems.Count; i++) //looping through all interactable objs
            {
                //even if it can't be found/is inactive 
                if (highlightItems[i] == null)
                    continue; //keep going if one of the objs is inactive  

                if (!highlightItems[i].gameObject.activeInHierarchy)
                    continue; //keep going if one of the highlights scripts is inactive

                //if the ray hit any of those gamobject
                if (hit.collider.gameObject == highlightItems[i].gameObject) //checking if the ray hit any of their colliders
                {
                    //turn on their outlines
                    highlightItems[i].TurnOutlineOn(); //if so we turn their outlines on
                }

            }

        }
        //debug to draw ray shown in scene view only - for debugging pruposes
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red); //Debug to draw ray from the camera in scene window

    }

//called in foot towel mechanic as one of the objs is not active until later
    public void AddInteractable(GameObject obj)
    {
        if (!interactableObjects.Contains(obj))
        {
            //add new object to the list
            interactableObjects.Add(obj);
        }


        HighlightItems h = obj.GetComponent<HighlightItems>();

        if (h == null)
            return;
        //adds its highlight item componenet too
        highlightItems.Add(h);
    }


}
    

