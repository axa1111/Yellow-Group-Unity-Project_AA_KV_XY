using UnityEngine;

public class scanFoot : MonoBehaviour
{
    //reference to collider 
    public GameObject cameraDetectionCollider;

    //reference to UI button
    public GameObject xrayButton;

    //reference to main camera
    public GameObject mainCameraObj;

    //reference to script managing camera movement
    private Script_ManageCamera script_ManageCameraScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get the script that manages the camera's movement
        script_ManageCameraScript = mainCameraObj.GetComponent<Script_ManageCamera>();
    }

//when the camera enters in the collider then show the xray buttons
    private void OnTriggerEnter(Collider other)
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
