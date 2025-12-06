using UnityEngine;

public class scanFoot : MonoBehaviour
{

    public GameObject cameraDetectionCollider;
    public GameObject xrayButton;
    public GameObject mainCameraObj;

    private Script_ManageCamera script_ManageCameraScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get the script that manages the camera's movement
        script_ManageCameraScript = mainCameraObj.GetComponent<Script_ManageCamera>();
    }

//when the camera enters and stays in the collider then show the xray buttons
    private void OnTriggerStay(Collider other)
    {
        xrayButton.SetActive(true);
    }

//when the camera leaves the collider then hide the xray buttons
    private void OnTriggerExit(Collider other)
    {
        xrayButton.SetActive(false);

    }

//when the xray button is pressed disable the camera movement script
    public void OnXrayButtonPressed()
    {
        script_ManageCameraScript.enabled = false;
    }

//when the back button is pressed enable the camera movement script
    public void OnXrayCloseButtonPressed()
    {
        script_ManageCameraScript.enabled = true;
    }
}
