using UnityEngine;

public class RayCastManager : MonoBehaviour
{
    [SerializeField]
    private GameObject reticule; //referencing the reticule obj
    private float maxDistance = 6f; //setting max distance of ray to 6f
    public RaycastHit hit; //declaring variable RayCastHit as hit


    [Header("Obj to interact with")] //header for neatness
    [SerializeField]
    private GameObject[] interactableObjects;  //array of objs which will be interacted with 0 - set in inspector
    private HighlightItems[] highlightScripts; //array highlight scripts 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highlightScripts = new HighlightItems[interactableObjects.Length]; //storing it in memory limited to the same size of interactable objects

        for(int i = 0; i < interactableObjects.Length; i++) 
        {
            highlightScripts[i] = interactableObjects[i].GetComponent<HighlightItems>(); //filling the array with the highlight script component from each interactable obj in array
            highlightScripts[i].enabled = true; //setting the scripts to be enabled
        }
    }

    // Update is called once per frame
    void Update()
    {
        //we loop through all the interactable objs and ensure the outline is turned off, this method is accessed through each obj's highlight script
        //we turn it off here so it is only on when the ray is actually hitting the objs collider 
        for (int i = 0; i < interactableObjects.Length; i++)
        {
            highlightScripts[i].TurnOutlineOff();
        } 
            
        Ray ray = new Ray(transform.position, transform.forward); // creating ray then setting ray direction to forward

        //checking if ray is hitting somrthing in the scene 
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
          //  Debug.Log("RaycastHit" + hit.collider.transform.name);
            if (reticule != null)
            {
                //set it active
                reticule.SetActive(true);

                //move it to the point where the ray hits
                reticule.transform.position = hit.point;
            }
            
            for(int i = 0; i <interactableObjects.Length; i++) //looping through all interactable objs
            {
                if (hit.collider.gameObject == interactableObjects[i]) //checking if the ray hit any of their colliders
                {
                    highlightScripts[i].TurnOutlineOn(); //if so we turn their outlines on
                }
                
            } 
        }
       /* else
       {
            //else if the reticule is not null then set it inactive if it doesn't hit anything
           if (reticule != null)
            {
                reticule.SetActive(false);
            } 
        }*/
         Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red); //Debug to draw ray from the camera in scene window
       

    }
}
