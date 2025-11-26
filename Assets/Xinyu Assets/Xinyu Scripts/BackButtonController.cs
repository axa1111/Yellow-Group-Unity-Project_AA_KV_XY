using UnityEngine;

public class BackButtonController : MonoBehaviour
{
    public SceneManager sceneManager;
    
    public void OnBackClick()
    {
        sceneManager.GoToScene4();
    }
}