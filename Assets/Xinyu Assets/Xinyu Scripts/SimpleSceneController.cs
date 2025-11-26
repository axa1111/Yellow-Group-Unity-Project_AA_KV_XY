using UnityEngine;

public class SimpleSceneController : MonoBehaviour
{
    public SceneManager sceneManager;
    
    // 点击Next按钮切换到场景4
    public void OnNextButtonClick()
    {
        sceneManager.GoToScene4();
    }
}