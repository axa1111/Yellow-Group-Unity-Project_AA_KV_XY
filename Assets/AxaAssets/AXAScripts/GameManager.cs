using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
/* this script manages the scene changes throughout the game */
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject backToMainMenuPanel;
    private GameObject mainCamera;
    private PlayerMovement playerMovementScript;
    public GameObject fadeInPanel;
    private CanvasGroup canvasGroupComponent;
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

        DontDestroyOnLoad(this);
    }

    void Start()
    {
        canvasGroupComponent = backToMainMenuPanel.GetComponent<CanvasGroup>();
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
        FadeThePanel();
       
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
            if(SceneManager.GetActiveScene().name != "MainMenu")
           {
                backToMainMenuPanel.SetActive(true);//turn the panel on
                canvasGroupComponent.blocksRaycasts = true;

                if(SceneManager.GetActiveScene().name == "Treatment_Scene_Aqsa")//if the scene we are in is the treatment scene
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

    public void FadeThePanel()
    {
         StartCoroutine(fadeInPanelToggle());
    }
    
    public void CloseBackToMainMenuPanel()
    {
        if(backToMainMenuPanel != null)
        {
            if(backToMainMenuPanel.activeSelf)
            {
                backToMainMenuPanel.SetActive(false);
            }
        }
    }
    
    //SceneManager.GetActiveScene().name == "Treatment"
}
