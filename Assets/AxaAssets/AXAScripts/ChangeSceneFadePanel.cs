using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//this script is on theFade_ToDark_Panel which is a child of the game manager
public class ChangeSceneFadePanel : MonoBehaviour
{
    //ref private string called scene to load
    private string sceneToLoad;

//when the fade panel is active
    void OnEnable()
    {
        //call fade to next scene method
        FadeToNextScene();
    }
    public void FadeToNextScene()
    {
        //start coroutine WaitTOFadeTillNextScene
        StartCoroutine(WaitToFadeTillNextScene());
    }

    private IEnumerator WaitToFadeTillNextScene()
    {
        //wait one second
        yield return new WaitForSeconds(1f);
        //call method switch scenes from game manager
        GameManager.instance.SwitchScenes(sceneToLoad);
        //wait half a second
        yield return new WaitForSeconds(0.5f);
        //set the panel inactive again
        gameObject.SetActive(false);
    }
    private void Update()
    {
        //the sceneToLoad is based on what scene we are in, this check runs in hte update method to make sure we get the correct scene 

        //if we are in the main menu scene
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            //scene to load is diagnosis scene
            sceneToLoad = "Diagnosis_Scene_KV";
        }

        //if we are in diagnosis scene
        if (SceneManager.GetActiveScene().name == "Diagnosis_Scene_KV")
        {
            //sene to load is treatment scene
            sceneToLoad = "Treatment_Scene_Aqsa";
        }

        //If we are in the treatment scene
        if (SceneManager.GetActiveScene().name == "Treatment_Scene_Aqsa")
        {
            //scene to load is rehabilitaion
            sceneToLoad = "1rehabilitation";
        }
    }



}
