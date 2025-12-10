using UnityEngine;
using System.Collections;

//rotate around https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Transform.RotateAround.html
//slerp https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Vector3.Slerp.html
//set position and rotation https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Transform.SetPositionAndRotation.html

//this script sits on the mainCameraObj
public class Script_ManageCamera : MonoBehaviour
{
    //reference to left footTarget
    public GameObject leftFootTarget;

    //reference to right footTarget
    public GameObject rightFootTarget;

    //ref to transform of rightFootCameraPosition 
    //this is where we want the camera to move towards later
    public Transform rightFootCameraPos;

    //variable currentTargetToLookAt
    private GameObject currentTargetToLookAt;

    // float speed set to 3.3 f
    private float speed = 3.3f;

    //bool is moving
    private bool isMoving;

    //ref to cameras Animator
    private Animator cameraAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set the cameras animator
        cameraAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the right arrow or D key is pressed
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && currentTargetToLookAt != null)
        {
            //roatet the camera on the around the current target to look counter clockwise
            transform.RotateAround(currentTargetToLookAt.transform.position, Vector3.up, -50 * Time.deltaTime);
        }

//otherwise if left arrow or A is pressed
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && currentTargetToLookAt != null)
        {
            //roatet the camera on the y axis around the current target to look at clockjwise
            transform.RotateAround(currentTargetToLookAt.transform.position, Vector3.up, 50 * Time.deltaTime);
        }

        if (currentTargetToLookAt != null && !isMoving)
        {
            //look at the current target to look at
            transform.LookAt(currentTargetToLookAt.transform);
        }

        //if isMoving is true
        if (isMoving)
        {
            //set the cameras position and rotation to the rirightFootCameraPosobj position and rotation
            transform.SetPositionAndRotation(Vector3.Lerp(transform.position, rightFootCameraPos.transform.position, speed * Time.deltaTime), Quaternion.Slerp(transform.rotation, rightFootCameraPos.rotation, speed * Time.deltaTime));

            //if the camera is near the specified position and rotation 
            if (Vector3.Distance(transform.position, rightFootCameraPos.position) < 0.1f && Quaternion.Angle(transform.rotation, rightFootCameraPos.rotation) < 0.1f)
            {
                //set the position to the rightFootCameraPosobj position and rotation
                transform.position = rightFootCameraPos.transform.position;
                transform.rotation = rightFootCameraPos.rotation;
                //stop moving by setting isMoving to false
                isMoving = false;
                //set the new target to the right foot
                currentTargetToLookAt = rightFootTarget;
            }
        }
    }

    //this method is called on the OnClick event of the InspectRightFoot Button
    public void OnRightFootButtonClick()
    {
        //we set is moving to true to trigger the camera movement 
        //see update method
        isMoving = true;

    }

//this method is called on the OnClick event of the InspectLeftFoot Button
    public void OnLeftFootButtonClick()
    {
        //trigger animation of camera moving to left foot 
        cameraAnim.SetBool("isLeftCloseLookButtonClicked", true);
         //Start the coroutine WaitForLeftFootAnimation()
        StartCoroutine(WaitForLeftFootAnimation());

    }

    private IEnumerator WaitForLeftFootAnimation()
    {
        //wait one second
        yield return new WaitForSeconds(1.0f);
        //turn the camera animator off so it doesnt intefer with the movement later on
        cameraAnim.enabled = false;
        //set current Target To Look at to be the left foot 
        currentTargetToLookAt = leftFootTarget;
    }
}


