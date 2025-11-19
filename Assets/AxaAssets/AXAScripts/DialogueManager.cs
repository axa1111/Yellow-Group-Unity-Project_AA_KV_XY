using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject canvasObj;

    private StoringPlayerName storingPlayerNameScript;

    [SerializeField] private TextMeshProUGUI welcomeText;
    [SerializeField] private TextMeshProUGUI welcomeBackText;

    void Start()
    {
        storingPlayerNameScript = canvasObj.GetComponent<StoringPlayerName>();

        welcomeText.gameObject.SetActive(false);
        welcomeBackText.gameObject.SetActive(false);

    }


    void Update()
    {
        if (storingPlayerNameScript.hasNameBeenSaved)
        {
            welcomeText.gameObject.SetActive(true);
            storingPlayerNameScript.playerName = PlayerPrefs.GetString("playerName");
            welcomeText.text = "Welcome Dr " + storingPlayerNameScript.playerName;
        }
        else if(storingPlayerNameScript.hasGameBeenPlayedBefore)
        {
            storingPlayerNameScript.playerName = PlayerPrefs.GetString("playerName");
            welcomeBackText.gameObject.SetActive(true);
            welcomeBackText.text = "Welcome back Dr " + storingPlayerNameScript.playerName;
        }

    }
}
