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
        //locate script that manages camera movement
        script_ManageCameraScript = mainCameraObj.GetComponent<Script_ManageCamera>();
    }

    //show scan button when camera enters collider
    private void OnTriggerEnter(Collider other)
    {
        xrayButton.SetActive(true);
    }

    //hide scan button when the camera leaves collider
    private void OnTriggerExit(Collider other)
    {
        xrayButton.SetActive(false);

    }

    //set ManageCameraScript inactive when scan button clicked
    public void OnXrayButtonPressed()
    {
        script_ManageCameraScript.enabled = false;
    }

    //set ManageCameraScript active when back button clicked
    public void OnXrayCloseButtonPressed()
    {
        script_ManageCameraScript.enabled = true;
    }
}
