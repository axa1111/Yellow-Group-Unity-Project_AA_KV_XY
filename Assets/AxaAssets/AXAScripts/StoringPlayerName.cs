using UnityEngine;
using TMPro;

/*This script is working to store the players name to use in
dialogue throughout the game this script sits on the camera Obj in Main menu scene*/

public class StoringPlayerName : MonoBehaviour
{
    //text player inputs in
    [SerializeField] private TextMeshProUGUI myText;

    //input field parent obj
    [SerializeField] private GameObject inputNameParentObj;

    //players name variable
    public string playerName;
    //bool to check if name is saved
    public bool hasNameBeenSaved;

    //bool to check if game has been played before
    public bool hasGameBeenPlayedBefore = false;
    
    void Start()
    {
        //setting bool to false;
        hasNameBeenSaved = false;
    }

    /*When player presses play button this is called (in its on click event)
    checkes to see if we need a name from the player or if we 
    already stored and setting input field active or inactive based on that*/
    public void OnPlayClick()
    {
        //if the name has already been stored before
        if (PlayerPrefs.HasKey("playerName"))
        {
            //turn off the input name obj
            inputNameParentObj.SetActive(false);
            //set bool to true
            hasGameBeenPlayedBefore = true;
        }
        else
        {
            //otherwise turn on input field and set bool to false
            hasGameBeenPlayedBefore = false;
            inputNameParentObj.SetActive(true);
        }
    }

    /*method called on the onClick event of the save button next to the input
    field, here we are saving the name*/
    public void OnClickSaveName()
    {

        /* saveing the text the player put in storing it under playerName key */
        PlayerPrefs.SetString("playerName", myText.text);
        //saving onto disk
        PlayerPrefs.Save();
        //disable the input field obj
        inputNameParentObj.SetActive(false);
        //bool set to true
        hasNameBeenSaved = true;
    }

    //this is on the OnClickEvent on the change name button
    //we delete the key and turn the input field on again
    public void OnClickChangeName()
    {
        //setting bools to false
        hasGameBeenPlayedBefore = false;
        hasNameBeenSaved = false;
        //deleting the key
        PlayerPrefs.DeleteKey("playerName");
        //setting input field active 
        inputNameParentObj.SetActive(true);
    }
}
