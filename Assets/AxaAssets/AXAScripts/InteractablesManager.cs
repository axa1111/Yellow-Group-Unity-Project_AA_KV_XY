using UnityEngine;

public class InteractablesManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject cameraObj; //reference to camera which holds the raycast script
    private RayCastManager raycastManagerScript; //reference to raycast script so we can acces hit variable

    [Header("Interactables on Tables")]
    public GameObject sawTable;
    public GameObject flaskTable;
    public GameObject faceTowelTable;
    public GameObject footTowelTable;   

    [Header("Interactables Picked Up")]
   // public GameObject sawPickedUp;
    public GameObject flaskPickedUp;
    public GameObject faceTowelPickedUp; 
    public GameObject footTowelPickedUp;     
    //public GameObject footTowelPickedUp;   
    void Start()
    {
        raycastManagerScript = cameraObj.GetComponent<RayCastManager>(); //getting raycast script
    }

    // Update is called once per frame
    void Update()
    {
        //exit loop if he isnt pressed
        if (!Input.GetKeyDown(KeyCode.E))
            return;
        //exit loop if nothing is hit
        if (raycastManagerScript.hit.collider == null)
            return;

        GameObject hitObject = raycastManagerScript.hit.collider.gameObject; //det hitObject to the object hit

        switch (hitObject.tag) //using switch instead of lots of if statments
        {
            case "Saw": //if the tag is saw the do this
                Debug.Log("picked up" + hitObject.name);
               // SwapActiveObj(sawTable, sawPickedUp);
                break;

            case "Flask": //if the tag is flask the do this
                Debug.Log("picked up" + hitObject.name);
                SwapActiveObj(flaskTable, flaskPickedUp);
                break;

            case "FaceTowel": //if the tag is FaceTowel the do this
                Debug.Log("picked up" + hitObject.name);
                SwapActiveObj(faceTowelTable, faceTowelPickedUp);
                break;

            case "FootTowel": //if the tag is FootTowel the do this
                Debug.Log("picked up" + hitObject.name);
                SwapActiveObj(footTowelTable, footTowelPickedUp);
                break;

            default:
                Debug.Log("" + hitObject.name);
                break;
        }
    }

    public void SwapActiveObj(GameObject deactivateObj, GameObject activateObj)
    {
        if (deactivateObj != null)
        {
            deactivateObj.SetActive(false);
        }

        if (activateObj != null)
        {
            activateObj.SetActive(true);
        }
    }
    
}
