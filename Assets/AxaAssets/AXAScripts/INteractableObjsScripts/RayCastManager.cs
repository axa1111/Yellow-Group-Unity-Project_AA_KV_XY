using System.Collections.Generic;
using UnityEngine;

//it was first using arrays and the had t change to list as items would be added afer
public class RayCastManager : MonoBehaviour
{

    private float maxDistance = 3.5f; //setting max distance of ray to 6f
    public RaycastHit hit; //declaring variable RayCastHit as hit


    [Header("Obj to interact with")] //header for neatness
    [SerializeField]
    private List<GameObject> interactableObjects = new List<GameObject>();
    private List<HighlightItems> highlightItems = new List<HighlightItems>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highlightItems.Clear();

        for (int i = 0; i < interactableObjects.Count; i++)
        {

            if (!interactableObjects[i].activeInHierarchy)
                continue;

            HighlightItems h = interactableObjects[i].GetComponent<HighlightItems>();

            if (h == null)
                continue;

            highlightItems.Add(h);
        }
    }


    void Update()
    {
        for (int i = 0; i < highlightItems.Count; i++)
        {
            if (highlightItems[i] == null)
                continue;

            if (!highlightItems[i].gameObject.activeInHierarchy)
                continue;

            highlightItems[i].TurnOutlineOff();
        }

        Ray ray = new Ray(transform.position, transform.forward); // creating ray then setting ray direction to forward

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Debug.Log("RaycastHit" + hit.collider.transform.name);

            for (int i = 0; i < highlightItems.Count; i++) //looping through all interactable objs
            {
                if (highlightItems[i] == null)
                    continue; //keep going if one of the objs is inactive  

                if (!highlightItems[i].gameObject.activeInHierarchy)
                    continue; //keep going if one of the highlights scripts is inactive

                if (hit.collider.gameObject == highlightItems[i].gameObject) //checking if the ray hit any of their colliders
                {
                    highlightItems[i].TurnOutlineOn(); //if so we turn their outlines on
                }

            }

        }
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red); //Debug to draw ray from the camera in scene window

    }


    public void AddInteractable(GameObject obj)
    {
        if (!interactableObjects.Contains(obj))
        {
            interactableObjects.Add(obj);
        }

        HighlightItems h = obj.GetComponent<HighlightItems>();

        if (h == null)
            return;

        highlightItems.Add(h);
    }


}
    

