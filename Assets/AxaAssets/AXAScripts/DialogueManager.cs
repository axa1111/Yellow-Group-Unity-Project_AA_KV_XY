using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject canvasObj;

    private StoringPlayerName storingPlayerNameScript;

    [SerializeField] private TextMeshProUGUI welcomeText;
    [SerializeField] private TextMeshProUGUI welcomeBackText;
    [SerializeField] private TextMeshProUGUI walkieTalkieText;
    [SerializeField] private GameObject walkieTalkieDialogue;

    void Start()
    {
        storingPlayerNameScript = canvasObj.GetComponent<StoringPlayerName>();

        welcomeText.gameObject.SetActive(false);
        welcomeBackText.gameObject.SetActive(false);

    }


    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (storingPlayerNameScript.hasNameBeenSaved)
            {
                welcomeText.gameObject.SetActive(true);
                storingPlayerNameScript.playerName = PlayerPrefs.GetString("playerName");
                welcomeText.text = "Welcome Dr " + storingPlayerNameScript.playerName;
            }
            else if (storingPlayerNameScript.hasGameBeenPlayedBefore)
            {
                storingPlayerNameScript.playerName = PlayerPrefs.GetString("playerName");
                welcomeBackText.gameObject.SetActive(true);
                welcomeBackText.text = "Welcome back Dr " + storingPlayerNameScript.playerName;
                walkieTalkieText.text = "Dr " + storingPlayerNameScript.playerName + " you are needed in the medic tent now... soldier with severe trench foot, amputation may be needed... over";
            }
        }

    }

    //wait to show walkie talkie Dialogue

    public void ShowWalkieTalkieDialogue()
    {
        StartCoroutine(delayWalkieTalkieDialogue());
    }
    private IEnumerator delayWalkieTalkieDialogue()
    {
        yield return new WaitForSeconds(1f);
        walkieTalkieDialogue.SetActive(true);

    }
}


