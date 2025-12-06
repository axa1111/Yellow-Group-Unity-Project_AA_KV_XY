using UnityEngine;

public class SceneController : MonoBehaviour
{
    // 所有场景的父对象
    public GameObject scene1, scene2, scene3, scene4, scene5, scene6, scene7;
    
    void Start()
    {
        // 初始化：只显示场景1，隐藏其他所有场景
        SetActiveScene(scene1);
    }
    
    // 切换到指定场景，隐藏其他所有场景
    public void SetActiveScene(GameObject activeScene)
    {
        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(false);
        scene4.SetActive(false);
        scene5.SetActive(false);
        scene6.SetActive(false);
        scene7.SetActive(false);
        
        activeScene.SetActive(true);
    }
    
    // 公共方法供按钮调用
    public void GoToScene1() { SetActiveScene(scene1); }
    public void GoToScene2() { SetActiveScene(scene2); }
    public void GoToScene3() { SetActiveScene(scene3); }
    public void GoToScene4() { SetActiveScene(scene4); }
    public void GoToScene5() { SetActiveScene(scene5); }
    public void GoToScene6() { SetActiveScene(scene6); }
    public void GoToScene7() { SetActiveScene(scene7); }
}
