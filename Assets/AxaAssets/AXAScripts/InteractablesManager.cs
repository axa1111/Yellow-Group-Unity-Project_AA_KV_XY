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
    public GameObject sawPickedUp;
    public GameObject faceTowelPickedUp;
    public GameObject footTowelPickedUp;

    //bools to track mechanic order
    private bool timeForFaceTowel = false;
    private bool timeForChloroform = false;
    private bool timeForSaw = false;

    //script references
    private FlaskMechanicManager flaskMechanicManagerScript; //acript with method to trigger flask mechanic

    void Start()
    {
        raycastManagerScript = cameraObj.GetComponent<RayCastManager>(); //getting raycast script
        flaskMechanicManagerScript = GetComponent<FlaskMechanicManager>(); //setting flask mechanic script
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

        //using switch instead of lots of if statments
        switch (hitObject.tag)
        {
            case "Saw" when timeForSaw: //if the tag is saw the do this
                Debug.Log("picked up" + hitObject.name);
               SwapActiveObj(sawTable, sawPickedUp);
                break;

            case "Flask" when timeForChloroform: //if the tag is flask the do this
                Debug.Log("picked up" + hitObject.name);
                flaskMechanicManagerScript.FlaskMechanic(); //trigger the mechanic animation and texture change using this script
                //lets remove the tag so it cant be triggered again
                hitObject.tag = "Untagged";
                timeForFaceTowel = true;
                break;

            case "FaceTowel" when timeForFaceTowel: //if the tag is FaceTowel the do this && using when clause to ensure bool is true befor executing logic
                Debug.Log("picked up" + hitObject.name);
                SwapActiveObj(faceTowelTable, faceTowelPickedUp);
                break;

            case "FootTowel": //if the tag is FootTowel the do this
                Debug.Log("picked up" + hitObject.name);
                SwapActiveObj(footTowelTable, footTowelPickedUp);
                SwapActiveObj(faceTowelTable, footTowelPickedUp);
                timeForChloroform = true;
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
