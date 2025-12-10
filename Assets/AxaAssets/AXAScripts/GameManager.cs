using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
/* this script manages the scene changes throughout the game */
public class GameManager : MonoBehaviour
{
    //static reference ot GameManager Class so i can call it anywhere
    public static GameManager instance = null;
    //ref to backToMainMenuPanel
    public GameObject backToMainMenuPanel;

    //ref to camera holding the player movement script
    private GameObject mainCamera;
    //ref to player movement script
    private PlayerMovement playerMovementScript;
    //ref to fade panel
    public GameObject fadeInPanel;
    //ref to canvas group
    private CanvasGroup canvasGroupComponent;
    void Awake()
    {
        //if no instance exists set this obj as main instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            //otherwise destroy this duplicate if another already exists
            Destroy(gameObject);
            return;
        }

        //dont destroy this gameobject accross scenes
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        //getting the canvas group
        canvasGroupComponent = backToMainMenuPanel.GetComponent<CanvasGroup>();
    }


    //called on click event if quit button
    public void Quit()
    {
        Application.Quit();
        //debug for development testing
        Debug.Log("Quit");
    }

    //function directing player back to the main menu scene
    //called on the Onclick event of Main menu button on bkacToMainMenuPanel
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

//to toggle the backToMainMenu panel we use the escape key
//this is because in the treatment scene we dont have a mouse in this scene
    void Update()
    {
        //when pressed escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if we havent found main menu panel and we're not in the main menu scene where it doesnt exist 
            if(SceneManager.GetActiveScene().name != "MainMenu")
           {
                backToMainMenuPanel.SetActive(true);//turn the panel on
                canvasGroupComponent.blocksRaycasts = true;//block raycasts

                if(SceneManager.GetActiveScene().name == "Treatment_Scene_Aqsa")//if the scene we are in is the treatment scene
                {
                    Cursor.lockState = CursorLockMode.None;//unlock cursor
                    mainCamera = GameObject.FindWithTag("MainCameraTreatment"); //find the main camera
                    playerMovementScript = mainCamera.GetComponent<PlayerMovement>(); //get player movement script
                    if (mainCamera != null)//if its found
                    {
                        Cursor.visible = true; //show cursor
                        canvasGroupComponent.blocksRaycasts = true; //block raycast
                        //disable player movement script
                        playerMovementScript.enabled = false;
                    }
                }
           }
        }
    }

    //method to call in other scripts where scene will be specified 
    public void SwitchScenes(string nextScene)
    {
        //load the next scene (Specified in ChangeSceneFadePanel script)
        SceneManager.LoadScene(nextScene);
        StartCoroutine(fadeInPanelToggle());

    }

    //created coRoutine so we could wait till the scene loaded to set the fade panel active
    private IEnumerator fadeInPanelToggle()
    {
        yield return null;
        //if we're in the main menu
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            //turn to fade panel off
            fadeInPanel.SetActive(false);
        }
        else
        {
            //turn it on 
            fadeInPanel.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        {
            fadeInPanel.SetActive(false); //then turn it off again
        }

    }

//public method to fade the panel
    public void FadeThePanel()
    {
        //start coroutine fadeInPanelToggle
        StartCoroutine(fadeInPanelToggle());
    }

//to close the back to maine menu panel, its called on resume button
    public void CloseBackToMainMenuPanel()
    {
        //if its not null
        if (backToMainMenuPanel != null)
        {
            //and its active
            if (backToMainMenuPanel.activeSelf)
            {
                //set it inactive
                backToMainMenuPanel.SetActive(false);
            }
        }
    }
    
    //when pressing the resume button turn bakc the playerMovement script
    public void ResumeGameButtonClick()
    {
        //if we are in the treatment scene
        if(SceneManager.GetActiveScene().name == "Treatment_Scene_Aqsa")//if the scene we are in is the treatment scene
        {
            //hide the cursor
            Cursor.visible = false;
            //lock it
            Cursor.lockState = CursorLockMode.Locked;
            //get the player movement script
            playerMovementScript = mainCamera.GetComponent<PlayerMovement>();
            //enable it
            playerMovementScript.enabled = true;
        }
    }
}
