using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public SceneManager sceneManager;
    
    public void OnRehabilitationClick()
    {
        sceneManager.GoToScene5();
    }
    
    public void OnMuscleClick()
    {
        sceneManager.GoToScene6();
    }
    
    public void OnQuizClick()
    {
        sceneManager.GoToScene7();
    }
}