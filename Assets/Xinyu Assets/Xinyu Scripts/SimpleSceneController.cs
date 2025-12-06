using UnityEngine;

public class SimpleSceneController : MonoBehaviour
{
    public SceneController sceneController;
    
    // 点击Next按钮切换到场景4
    public void OnNextButtonClick()
    {
        sceneController.GoToScene4();
    }
}