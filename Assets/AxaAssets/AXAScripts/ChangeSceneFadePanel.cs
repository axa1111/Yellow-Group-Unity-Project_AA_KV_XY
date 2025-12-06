using UnityEngine;
using System.Collections;
using System;
public class ChangeSceneFadePanel : MonoBehaviour
{
    public string sceneToLoad;

    void Start ()
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
        {
            GameManager.instance.SwitchScenes(sceneToLoad);
        }
    }
}
