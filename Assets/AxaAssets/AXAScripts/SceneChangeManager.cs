using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    private GameObject interactableObj;
    private SawMechanic sawMechanic;
    //switching scenes using methods from game manager instance 
    //decided to use this method as i can be specific of what scene to switch to without relying on build index
    //also prefer to set names within the script instead of in the inspector
    public void LoadDiagnosisScene()
    {
        GameManager.instance.SwitchScenes("Diagnosis_Scene_KV");
    }
    public void LoadTreatmentScene()
    {
        GameManager.instance.SwitchScenes("Treatment_Scene_Aqsa");
    }

    public void LoadRehabilitationScene()
    {
        GameManager.instance.SwitchScenes("1rehabilitation");
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Treatment_Scene_Aqsa")
        {
            if(interactableObj == null)
            {
                interactableObj = GameObject.FindWithTag("InteractablesParent");
                sawMechanic =interactableObj.GetComponent<SawMechanic>();
            }
            if(Input.GetKeyDown(KeyCode.Q) && sawMechanic.readyToMoveOntoDiagnosisScene)
            {
                Cursor.visible = true; //show the mouse
                Cursor.lockState = CursorLockMode.None; //unlock it
                interactableObj = GameObject.FindWithTag("InteractablesParent");
                sawMechanic =interactableObj.GetComponent<SawMechanic>();
                LoadRehabilitationScene();
            }
        }
    }
}
