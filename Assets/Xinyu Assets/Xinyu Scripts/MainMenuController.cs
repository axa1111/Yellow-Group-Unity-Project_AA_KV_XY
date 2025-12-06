using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public SceneController sceneController;
    
    public void OnRehabilitationClick()
    {
        sceneController.GoToScene5();
    }
    
    public void OnMuscleClick()
    {
        sceneController.GoToScene6();
    }
    
    public void OnQuizClick()
    {
        sceneController.GoToScene7();
    }
}