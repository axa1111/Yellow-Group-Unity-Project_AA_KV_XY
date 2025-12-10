using UnityEngine;

public class QuitApp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnQuit()
    {
        GameManager.instance.Quit();
    }
}
