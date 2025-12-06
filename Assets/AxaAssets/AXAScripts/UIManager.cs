using UnityEngine;

public class UIManager : MonoBehaviour
{
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
        Debug.Log("hijwkef");
    }
}
