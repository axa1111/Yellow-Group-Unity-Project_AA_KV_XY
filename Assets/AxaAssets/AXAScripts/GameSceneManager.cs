using UnityEngine;
using UnityEngine.SceneManagement;
/* this script manages the scene changes throughout the game */
public class GameSceneManager : MonoBehaviour
{
    public GameObject backToMainMenuPanel;
    private GameObject mainCamera;
    private PlayerMovement playerMovementScript;
    
    public void Quit()
    {
        Application.Quit();
        //debug for development testing
        Debug.Log("Quit");
    }

    //this function is called using the onclick section of the play button in the main menu
    public void Play()
    {
        //loading the main scene
        SceneManager.LoadScene("DiagnosisSceneName");
    }

    //function directing player back to the main menu scene
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "Treatment")
            {
                backToMainMenuPanel.SetActive(true);
                Cursor.visible = true;
                mainCamera = GameObject.FindWithTag("MainCamera");
                if (mainCamera != null)
                {
                    playerMovementScript = mainCamera.GetComponent<PlayerMovement>();
                    playerMovementScript.enabled = false;
                }
            }


        }
    }
    
    public void ReturnToTreatmentScene()
    {
        Cursor.visible = true;
        if (mainCamera != null)
            {
                playerMovementScript.enabled = false;
            }
    }

}
