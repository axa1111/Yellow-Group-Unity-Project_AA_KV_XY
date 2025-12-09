using UnityEngine;
using TMPro;

/*This script is working to store the players name to use in
dialogue throughout the game*/

public class StoringPlayerName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myText;

    [SerializeField] private GameObject inputNameParentObj;

    public string playerName;
    public bool hasNameBeenSaved;
    public bool hasGameBeenPlayedBefore = false;
    
    void Start()
    {
        //setting bool to false;
        hasNameBeenSaved = false;
    }

    public void OnPlayClick()
    {
        if (PlayerPrefs.HasKey("playerName"))
        {
            inputNameParentObj.SetActive(false);
            hasGameBeenPlayedBefore = true;
        }
        else
        {
            hasGameBeenPlayedBefore = false;
            inputNameParentObj.SetActive(true);
        }
    }
    public void OnClickSaveName()
    {
            playerName = myText.text;
            PlayerPrefs.SetString("playerName", myText.text);
            PlayerPrefs.Save();
            inputNameParentObj.SetActive(false);
            hasNameBeenSaved = true;    
    }

    public void OnClickGet()
    {
        playerName = PlayerPrefs.GetString("playerName");
        Debug.Log("Welcome back to the app " + playerName);
    }

    public void OnClickChangeName()
    {
        hasGameBeenPlayedBefore = false;
        hasNameBeenSaved = false;
        PlayerPrefs.DeleteKey("playerName");
        inputNameParentObj.SetActive(true);
    }
}
