using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

//rotate around https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Transform.RotateAround.html
//slerp https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Vector3.Slerp.html
//set position and rotation https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Transform.SetPositionAndRotation.html
public class Script_ManageCamera : MonoBehaviour
{
    public GameObject leftFootTarget;
    public GameObject rightFootTarget;

    public Transform rightFootCameraPos;
    private GameObject currentTargetToLookAt;

    private float speed = 3.3f;

    private bool isMoving;

    private Animator cameraAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && currentTargetToLookAt != null)
        {
            transform.RotateAround(currentTargetToLookAt.transform.position, Vector3.up, -50 * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.LeftArrow) && currentTargetToLookAt != null)
        {
            transform.RotateAround(currentTargetToLookAt.transform.position, Vector3.up, 50 * Time.deltaTime);
        }

        if (currentTargetToLookAt != null && !isMoving)
        {
            transform.LookAt(currentTargetToLookAt.transform);
        }

        if (isMoving)
        {
            transform.SetPositionAndRotation(Vector3.Lerp(transform.position, rightFootCameraPos.transform.position, speed * Time.deltaTime), Quaternion.Slerp(transform.rotation, rightFootCameraPos.rotation, speed * Time.deltaTime));

            if (Vector3.Distance(transform.position, rightFootCameraPos.position) < 0.1f && Quaternion.Angle(transform.rotation, rightFootCameraPos.rotation) <0.1f)
            {
                transform.position = rightFootCameraPos.transform.position;
                transform.rotation = rightFootCameraPos.rotation;
                isMoving = false;
                currentTargetToLookAt = rightFootTarget;
            }
        }
    }

    //lets make the right foot button only appear when the player is in the right position for teh animation?
    public void OnRightFootButtonClick()
    {
        isMoving = true;

    }

    public void OnLeftFootButtonClick()
    {
        //set left foot as target and add button to trigger animation

        cameraAnim.SetBool("isLeftCloseLookButtonClicked", true);
        StartCoroutine(WaitForLeftFootAnimation());

    }

    private IEnumerator WaitForLeftFootAnimation()
    {
        yield return new WaitForSeconds(1.0f);
        cameraAnim.enabled = false;
        currentTargetToLookAt = leftFootTarget;
    }
}


