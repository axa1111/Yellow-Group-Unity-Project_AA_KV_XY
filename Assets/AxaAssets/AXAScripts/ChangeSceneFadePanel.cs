using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ChangeSceneFadePanel : MonoBehaviour
{
    private string sceneToLoad;

    void OnEnable()
    {
        FadeToNextScene();
    }
    public void FadeToNextScene()
    {
        StartCoroutine(WaitToFadeTillNextScene());
    }

    private IEnumerator WaitToFadeTillNextScene()
    {
        yield return new WaitForSeconds(1f);
        GameManager.instance.SwitchScenes(sceneToLoad);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            sceneToLoad = "Diagnosis_Scene_KV";
        }

        if (SceneManager.GetActiveScene().name == "Diagnosis_Scene_KV")
        {
            sceneToLoad = "Treatment_Scene_Aqsa";
        }

        if (SceneManager.GetActiveScene().name == "Treatment_Scene_Aqsa")
        {
            sceneToLoad = "1rehabilitation";
        }
    }
    
    
    
}
