using UnityEngine;
//this script sits on the interactables parent obj
//it detects the interactable items the ray is hitting 
//executes specific logic depending on which item is looked at 
//ensures item interaction occurs in order 
public class InteractablesManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject cameraObj; //reference to camera which holds the raycast script

    [Header("Interactables on Tables")]
    public GameObject sawTable;
    public GameObject flaskTable;
    public GameObject faceTowelTable;
    public GameObject footTowelTable;
    public GameObject dampFootTowel;

    [Header("Interactables Picked Up")]
    public GameObject sawPickedUp;
    public GameObject faceTowelPickedUp;
    public GameObject footTowelPickedUp;
    public GameObject dialogueFour;
    public GameObject dialogueFive;

    //bools to track mechanic order
    private bool pickUpFaceTowel = false;
    private bool timeForChloroform = false;
    private bool timeForSaw = false;
    private bool putTowelOnFace = false;
    private bool putTowelOnSoldierFoot = false;
    private bool putSawOnRightFoot = false;

    //script references
    private FlaskMechanicManager flaskMechanicManagerScript; //acript with method to trigger flask mechanic
    private FootTowelMechanic footTowelMechanicScript;
    private RayCastManager raycastManagerScript; //reference to raycast script so we can acces hit variable
    private FaceTowelMechanic faceTowelMechanicScript;
    private SawMechanic sawMechanicScript;

    void Start()
    {
        raycastManagerScript = cameraObj.GetComponent<RayCastManager>(); //getting raycast script
        flaskMechanicManagerScript = GetComponent<FlaskMechanicManager>(); //setting flask mechanic script
        footTowelMechanicScript = GetComponent<FootTowelMechanic>(); //setting foot towel mechanic script
        faceTowelMechanicScript = GetComponent<FaceTowelMechanic>();
        sawMechanicScript = GetComponent<SawMechanic>();

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
            case "FootTowel": //if the tag is FootTowel the do this
                Debug.Log("picked up" + hitObject.name); //debug name in console
                footTowelMechanicScript.StartDunkingFootTowel(); //start dunking method called 
                break;//exit

            case "DampFootTowel"://if the tag is DampFootTowel the do this
                Debug.Log("picked up" + hitObject.name);//debug name in console
                SwapActiveObj(dampFootTowel, footTowelPickedUp); //call method ot swap out the items
                hitObject.tag = "Untagged"; //untag the object so it cant be picked up again
                putTowelOnSoldierFoot = true;//set the next bool true
                break; //exit

            case "SoldierLeftFoot" when putTowelOnSoldierFoot:  //if the tag is SoldierLeftFoot the do this && using when clause to ensure bool is true befor executing logic
                Debug.Log("picked up" + hitObject.name);//debug name in console
                footTowelMechanicScript.MoveDampTowelToFoot(); //call method to move the towel to teh foot
                hitObject.tag = "Untagged";//untag the object so it cant be picked up again
                timeForChloroform = true; //set the next bool true
                break; //exit

            case "Flask" when timeForChloroform: //if the tag is flask the do this && using when clause to ensure bool is true befor executing logic
                Debug.Log("picked up" + hitObject.name);//debug name in console
                flaskMechanicManagerScript.FlaskMechanic(); //trigger the mechanic animation and texture change using this script
                //lets remove the tag so it cant be triggered again
                hitObject.tag = "Untagged";//untag the object so it cant be picked up again
                pickUpFaceTowel = true; //set the next bool true
                break; //exit

            case "FaceTowel" when pickUpFaceTowel: //if the tag is FaceTowel the do this && using when clause to ensure bool is true befor executing logic
                Debug.Log("picked up" + hitObject.name);//debug name in console
                SwapActiveObj(faceTowelTable, faceTowelPickedUp);
                hitObject.tag = "Untagged";//untag the object so it cant be picked up again
                putTowelOnFace = true; //set the next bool true
                break; //exit

            case "PlayerFace" when putTowelOnFace: //if the tag is PlayerFace the do this && using when clause to ensure bool is true befor executing logic
                Debug.Log("picked up" + hitObject.name);//debug name in console
                faceTowelMechanicScript.MoveTowelToFace();
                hitObject.tag = "Untagged"; //untag the object so it cant be picked up again
                timeForSaw = true; //set the next bool true
                break; //exit

            case "Saw" when timeForSaw: //if the tag is saw the do this && using when clause to ensure bool is true befor executing logic
                Debug.Log("picked up" + hitObject.name);//debug name in console
                SwapActiveObj(sawTable, sawPickedUp);
                dialogueFour.SetActive(false);
                dialogueFive.SetActive(true);
                hitObject.tag = "Untagged";//untag the object so it cant be picked up again
                putSawOnRightFoot = true;//set the next bool true
                break; //exit

            case "SoldierRightFoot" when putSawOnRightFoot:  //if the tag is SoldierRightFoot the do this && using when clause to ensure bool is true befor executing logic
                Debug.Log("picked up" + hitObject.name);//debug name in console
                sawMechanicScript.MoveSawToFoot(); //call method to move the saw to the foot
                hitObject.tag = "Untagged";//untag the object so it cant be picked up again
                break; //exit

            default:
                Debug.Log("" + hitObject.name);//debug name in console
                break; //exit
        }
    }

    //method to switch out items used in this script and others 
    //passing through 2 game objects one is set inactive and one is set active 
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
