using UnityEngine;

public class RayCastManager : MonoBehaviour
{
    [SerializeField]
    private GameObject reticule; //referencing the reticule obj
    private float maxDistance = 5f; //setting max distance of ray to 5 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward); // creating ray then setting ray direction

        RaycastHit hit; //declaring variable RayCastHit as hit

        //checking if ray is hitting somrthing in the scene 
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Debug.Log("RaycastHit" + hit.collider.transform.name);

            //if reticule is not null
            if (reticule != null)
            {
                //set it active
                reticule.SetActive(true);

                //move it to the point where the ray hits
                reticule.transform.position = hit.point;
                // reticule.transform.LookAt(transform.position);
            }


            //this if statement will later handle item interactions
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("P Pressed and contact point is" + hit.point);
                //we pick up the item and put it down
                //can use bool to track if item is in hand or not
            }
        }
        else
        {
            //else if the reticule is not null then set it inactive if it doesn't hit anything
            if (reticule != null)
            {
                reticule.SetActive(false);
            }
        }
         Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red); //Debug to draw ray from the camera in scene window
       

    }
}
