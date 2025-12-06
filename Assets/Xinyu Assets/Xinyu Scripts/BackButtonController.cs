using UnityEngine;

public class BackButtonController : MonoBehaviour
{
    public SceneController sceneController;
    
    public void OnBackClick()
    {
        sceneController.GoToScene4();
    }
}