using System.Configuration;
using UnityEngine;

public class scanFoot : MonoBehaviour
{
    //ref to Obj which is ha sa collider used to detect the camera
    public GameObject cameraDetectionCollider;
    //ref to xray/scan button
    public GameObject xrayButton;
    //ref to main camera
    public GameObject mainCameraObj;
    //ref to script managing movement of main camera
    private Script_ManageCamera script_ManageCameraScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //locate script that manages camera movement
        script_ManageCameraScript = mainCameraObj.GetComponent<Script_ManageCamera>();
    }

    //show scan button when camera enters collider
    private void OnTriggerEnter(Collider other)
    {
        //set the scan button active
        xrayButton.SetActive(true);
    }

    //hide scan button when the camera leaves collider
    private void OnTriggerExit(Collider other)
    {
        // set the button inactive
        xrayButton.SetActive(false);

    }

    //set ManageCameraScript inactive when scan button clicked
    public void OnXrayButtonPressed()
    {
        //disable the script managing the camera movement
        script_ManageCameraScript.enabled = false;
    }

    //set ManageCameraScript active when back button clicked
    public void OnXrayCloseButtonPressed()
    {
        //enable it when the scan panel is closed 
        script_ManageCameraScript.enabled = true;
    }
}
