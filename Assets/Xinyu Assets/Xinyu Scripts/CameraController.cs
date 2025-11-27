using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public GameObject cameraMain;
  
    
    public void OnSceneSixButtonClick()
    {
        cameraMain.SetActive(false);
    }

    public void OnBackToSceneFour()
    {
        cameraMain.SetActive(true);
    }
        
}
