using UnityEngine;

//This script sits on the canvas in the main menu scene

public class QuitApp : MonoBehaviour
{
    // call this method on the Quit button
    public void OnQuit()
    {
        //get the instance of game manager and call it's quit method 
        GameManager.instance.Quit();
        Debug.Log("QuitApp");
    }
}
