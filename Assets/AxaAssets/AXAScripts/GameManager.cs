using UnityEngine;
using UnityEngine.SceneManagement;
/* this script manages the scene changes throughout the game */
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject backToMainMenuPanel;
    private GameObject mainCamera;
    private PlayerMovement playerMovementScript;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public void Quit()
    {
        Application.Quit();
        //debug for development testing
        Debug.Log("Quit");
    }

    //this function is called using the onclick section of the play button in the main menu
    public void BeginGame()
    {
        //loading the first scene
        SceneManager.LoadScene("Diagnosis_Scene_KV");
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

//method to call in other scripts where scene will be specified 
    public void SwitchScenes(string nextScene)
    {
        SceneManager.LoadScene(nextScene);

    }
}
