using UnityEngine;
using TMPro;

/*This script is working to store the players name to use in
dialogue throughout the game*/ 

public class StoringPlayerName : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI myText;

    [SerializeField]
    private GameObject inputNameParentObj;

    private string playerName;

    public void OnClickSaveName()
    {
        PlayerPrefs.SetString("playerName", myText.text);
        PlayerPrefs.Save();
        inputNameParentObj.SetActive(false);
    }

    public void OnClickGet()
    {
        playerName = PlayerPrefs.GetString("playerName");
        Debug.Log("Welcome back to the app " + playerName);
    }
}
