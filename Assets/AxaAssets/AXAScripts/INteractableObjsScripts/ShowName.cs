using System.Collections;
using UnityEngine;

//this script sits on the interactables parent obj
//it is used to manages some of the dialogue but mainly the instuctions (ex. press e to pick up towel) in the scene
//the interactables manager was getting really busy and I wanted to be able to see clearly which dialogue is triggered when
//it uses swich statements just like the interctables script so for more info and detailed comments please see tat script
public class ShowName : MonoBehaviour
{
    public GameObject cameraObj; //reference to camera which holds the raycast script
    private RayCastManager raycastManagerScript; //reference to raycast script so we can acces hit variable
    // Start is called once before the first execution of Update after the MonoBehaviour is created

//ref to text/dialogue game objs 
    public GameObject dialogueOne;
    public GameObject dialogueThree;
    public GameObject textUIOne;
    public GameObject textUITwo;
    public GameObject textUIThree;
    public GameObject textUIFour;
    public GameObject textUIFive;
    public GameObject textUISix;
    public GameObject textUISeven;
    public GameObject textUIEight;

    //bools to track which interactables turn it is 
    private bool isdampFootTowelTurn = false;
    private bool isTowelOnFootTurn = false;
    private bool isFlaskTurn = false;
    private bool isFaceTowelTurn = false;
    private bool isPlayerFaceTurn = false;
    private bool isSawTurn = false;
    private bool isSoldierRightFootTurn = false;
    void Start()
    {
        raycastManagerScript = cameraObj.GetComponent<RayCastManager>(); //getting raycast script
    }

    // Update is called once per frame
    void Update()
    {
        //if the raycastmanager is null keep going (preventing error)
        if (raycastManagerScript == null) return;

        //if the collider hits no object set all the text inactive
        if (raycastManagerScript.hit.collider == null)
        {
            textUIOne.SetActive(false);
            textUITwo.SetActive(false);
            textUIThree.SetActive(false);
            textUIFour.SetActive(false);
            textUIFive.SetActive(false);
            textUISix.SetActive(false);
            textUISeven.SetActive(false);
            textUIEight.SetActive(false);
            return;
        }
        //hit object is the object of the collider the ray is hitting 
        GameObject hitObject = raycastManagerScript.hit.collider.gameObject;

        //switch statement to manage cases
        //based on the objs tag
        switch (hitObject.tag)
        {
            case "FootTowel": //if the tag is FootTowel 
                textUIOne.SetActive(true); //set text one active
                isdampFootTowelTurn = true; //set bool to true
                break; //exit

            case "DampFootTowel" when isdampFootTowelTurn: //if the tag is DampFootTowel and corrosponding bool is true 
                dialogueOne.SetActive(false);//set dialogue inactive
                textUITwo.SetActive(true);//set text active
                isTowelOnFootTurn = true;//set bool to true
                break;

            case "SoldierLeftFoot" when isTowelOnFootTurn: //if the tag is SoldierLeftFoot and corrosponding bool is true 
                textUIThree.SetActive(true);//set text active
                isFlaskTurn = true;//set bool to true
                break;//exit

            case "Flask" when isFlaskTurn: //if the tag is Flask and corrosponding bool is true 
                textUIFour.SetActive(true);//set text active
                isFaceTowelTurn = true;//set bool to true
                break;//exit

            case "FaceTowel" when isFaceTowelTurn: //if the tag is FaceTowel and corrosponding bool is true 
                textUIFive.SetActive(true);//set text active
                isPlayerFaceTurn = true;//set bool to true
                break;//exit

            case "PlayerFace" when isPlayerFaceTurn: //if the tag is PlayerFace and corrosponding bool is true 
                textUISix.SetActive(true);//set text active
                dialogueThree.SetActive(false);
                isSawTurn = true;//set bool to true
                break;//exit

            case "Saw" when isSawTurn: //if the tag is Saw and corrosponding bool is true 
                textUISeven.SetActive(true);//set text active
                isSoldierRightFootTurn = true;//set bool to true
                break;//exit

            case "SoldierRightFoot" when isSoldierRightFootTurn: //if the tag is SoldierRightFoot and corrosponding bool is true 
                textUIEight.SetActive(true);
                break;//exit

            default:
            //set them all inactive
                textUIOne.SetActive(false);
                textUITwo.SetActive(false);
                textUIThree.SetActive(false);
                textUIFour.SetActive(false);
                textUIFive.SetActive(false);
                textUISix.SetActive(false);
                textUISeven.SetActive(false);
                textUIEight.SetActive(false);
                break;//exit
        }
    }
}
