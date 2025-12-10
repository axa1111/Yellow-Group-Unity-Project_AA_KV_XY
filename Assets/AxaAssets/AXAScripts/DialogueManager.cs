using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class DialogueManager : MonoBehaviour
{
    //reference to canvas obj which holds player pref script
    [SerializeField] private GameObject canvasObj;
    
    //ref to storing player name script (player prefs)
    private StoringPlayerName storingPlayerNameScript;

//ref to texts which will use the name from player pref
    [SerializeField] private TextMeshProUGUI welcomeText;
    [SerializeField] private TextMeshProUGUI welcomeBackText;
    [SerializeField] private TextMeshProUGUI walkieTalkieText;
//ref to walki talkie obj
    [SerializeField] private GameObject walkieTalkieDialogue;

    void Start()
    {
        //setting storingPlayerNameScript
        storingPlayerNameScript = canvasObj.GetComponent<StoringPlayerName>();

        //turning off the welcome dialogues
        welcomeText.gameObject.SetActive(false);
        welcomeBackText.gameObject.SetActive(false);

    }


    void Update()
    {
        //if we are in the main menu scene
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            //if the name has been saved
            if (storingPlayerNameScript.hasNameBeenSaved)
            {
                //set welcome text active
                welcomeText.gameObject.SetActive(true);
                //get the name that the player input and has been saved
                storingPlayerNameScript.playerName = PlayerPrefs.GetString("playerName");
                //set the welcome text to read welcome doctor and add int the players name
                welcomeText.text = "Welcome Dr " + storingPlayerNameScript.playerName;
            }
            //otherwise if the game has been played before
            else if (storingPlayerNameScript.hasGameBeenPlayedBefore)
            {
                //get the name
                storingPlayerNameScript.playerName = PlayerPrefs.GetString("playerName");
                //set the welcome back text true
                welcomeBackText.gameObject.SetActive(true);
                //set the text to read Welcom back Dr plus the players name
                welcomeBackText.text = "Welcome back Dr " + storingPlayerNameScript.playerName;
            }

            //managing the walkie talkie text
            //get the player name
            storingPlayerNameScript.playerName = PlayerPrefs.GetString("playerName");
            //set the walkie talkie text to the outlined below and add the players name
            walkieTalkieText.text = "Dr " + storingPlayerNameScript.playerName + " you are needed in the medic tent now... soldier with severe trench foot, amputation may be needed... over";


        }

    }

    //wait to show walkie talkie Dialogue
    /*this is called on the continue buttons or the welcome dialogues
    the wait helps it match up to the animation of the walkie
    talkie appearing on the screen*/
    public void ShowWalkieTalkieDialogue()
    {
        //StartCoroutine DelayWalkieTalkieDialogue
        StartCoroutine(DelayWalkieTalkieDialogue());
    }
    private IEnumerator DelayWalkieTalkieDialogue()
    {
        //wait for one second
        yield return new WaitForSeconds(1f);
        //turn the walkie talkie dialogue on
        walkieTalkieDialogue.SetActive(true);

    }
}


