using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ShowName : MonoBehaviour
{
     public GameObject cameraObj; //reference to camera which holds the raycast script
    private RayCastManager raycastManagerScript; //reference to raycast script so we can acces hit variable
    // Start is called once before the first execution of Update after the MonoBehaviour is created

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
        if (raycastManagerScript == null) return;
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
        GameObject hitObject = raycastManagerScript.hit.collider.gameObject;

        switch (hitObject.tag)
        {
            case "FootTowel": //if the tag is FootTowel the do this
                textUIOne.SetActive(true);
                isdampFootTowelTurn = true;
                break;

            case "DampFootTowel" when isdampFootTowelTurn:
                dialogueOne.SetActive(false);
                textUITwo.SetActive(true);
                isTowelOnFootTurn = true;
                break;

            case "SoldierLeftFoot" when isTowelOnFootTurn:
                textUIThree.SetActive(true);
                isFlaskTurn = true;
                break;

            case "Flask" when isFlaskTurn:
                textUIFour.SetActive(true);
                isFaceTowelTurn = true;
                break;

            case "FaceTowel" when isFaceTowelTurn:
                textUIFive.SetActive(true);
                isPlayerFaceTurn = true;
                break;

            case "PlayerFace" when isPlayerFaceTurn:
                textUISix.SetActive(true);
                dialogueThree.SetActive(false);
                isSawTurn = true;
                break;

            case "Saw" when isSawTurn:
                textUISeven.SetActive(true);
                isSoldierRightFootTurn = true;
                Debug.Log("Saw");
                break;

            case "SoldierRightFoot" when isSoldierRightFootTurn:
                textUIEight.SetActive(true);
                break;

            default:
                textUIOne.SetActive(false);
                textUITwo.SetActive(false);
                textUIThree.SetActive(false);
                textUIFour.SetActive(false);
                textUIFive.SetActive(false);
                textUISix.SetActive(false);
                textUISeven.SetActive(false);
                textUIEight.SetActive(false);
                break;
        }
    }
}
