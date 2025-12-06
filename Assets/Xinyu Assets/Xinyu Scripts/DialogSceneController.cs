using UnityEngine;

public class DialogSceneController : MonoBehaviour
{
    public GameObject[] dialogs; // 当前场景的所有对话框
    private int currentIndex = 0;
    public SceneController sceneController; // 引用主场景管理器
    
    void Start()
    {
        // 开始时隐藏所有对话框
        foreach (GameObject dialog in dialogs)
        {
            dialog.SetActive(false);
        }
    }
    
    // 显示下一个对话框或切换到下一个场景
    public void ShowNext()
    {
        if (currentIndex < dialogs.Length)
        {
            // 显示当前对话框
            dialogs[currentIndex].SetActive(true);
            currentIndex++;
        }
        else
        {
            // 所有对话框显示完毕，切换到下一个场景
            SwitchToNextScene();
        }
    }
    
    // 根据当前场景决定切换到哪个场景
    void SwitchToNextScene()
    {
        if (this.gameObject == sceneController.scene1)
        {
            sceneController.GoToScene2();
        }
        else if (this.gameObject == sceneController.scene2)
        {
            sceneController.GoToScene3();
        }
    }
}