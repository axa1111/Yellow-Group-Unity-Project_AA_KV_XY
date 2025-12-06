using UnityEngine;
using UnityEngine.SceneManagement;
/* this script manages the scene changes throughout the game */
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private GameObject backToMainMenuPanel;
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
        //when pressed escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if we havent found main menu panel and we're not in the main menu scene where it doesnt exist 
            if(backToMainMenuPanel == null && SceneManager.GetActiveScene().name != "MainMenu")
            {
                //look for the objext tagged backToMainMenuPanel and set the gameobject backToMainMenuPanel to the obj in scene with the tag
                backToMainMenuPanel = GameObject.FindGameObjectWithTag("backToMainMenuPanel");
            }
            else if (backToMainMenuPanel !=null) //if its already been set
           {
                backToMainMenuPanel.SetActive(true);//turn the panel on

                if(SceneManager.GetActiveScene().name != "Treatment_Scene_Aqsa")//if the scene we are in is the treatment scene
                {
                    Cursor.visible = true; //show the cursor (this is important for the treatment scene)
                    mainCamera = GameObject.FindWithTag("MainCamera"); //find the main camera
                    if (mainCamera != null)//if its found
                    {
                        //get the player movement script
                        playerMovementScript = mainCamera.GetComponent<PlayerMovement>();
                        //disable it
                        playerMovementScript.enabled = false;
                    }
                }
           }
        }
    }

    //method to call in other scripts where scene will be specified 
    public void SwitchScenes(string nextScene)
    {
        SceneManager.LoadScene(nextScene);

    }
    
    //SceneManager.GetActiveScene().name == "Treatment"
}
