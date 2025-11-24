using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
 * This is an improved orbit script based on the MouseOrbitImproved script found
 * on the unity community wiki. It should run smoother then the original version
 * 
 * Modified by Matt on 29th Oct 2024
 * */
 
[AddComponentMenu("Camera-Control/Mouse Camera Drag Orbit with zoom")]

public class MouseCameraDragOrbitWithZoom  : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    float rotationYAxis = 0.0f;
	float rotationXAxis = 0.0f;

    float velocityX = 0.0f;
	float velocityY = 0.0f;

    private float distance;

    [SerializeField]
    private float orbitSpeed = 3.0f;

    [SerializeField]
    private float yMinLimit = -20f;
	[SerializeField]
    private float yMaxLimit = 80f;

    [SerializeField]
    private float smoothTime = 2.0f;

    [SerializeField]
    private float fovMin = 30.0f;

    [SerializeField]
    private float fovMax = 90.0f;

    [SerializeField]
    private float zoomSpeed = 0.5f;

    private Vector3 previousMousePos;

    // Start is called before the first frame update
    void Start()
    {
		Vector3 angles = transform.eulerAngles;
		rotationYAxis = angles.y;
		rotationXAxis = angles.x;

        //Orientate the Camera so it look at the target obj
        transform.LookAt(target,Vector3.up);

        //Calculate distance between Camera and target object
        distance = Vector3.Distance(transform.position,target.position); 

        //Store Value of Mouse position as previous
        previousMousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        /***********************************************************************************/
        //Manage Orbit aroudn target obj
        /***********************************************************************************/
        if (Input.GetMouseButton(0))
        {
            //Simply use Input.mousePositionDelta in Unity 6
            velocityX += orbitSpeed * GetMousePositionDelta(Input.mousePosition).x * 0.02f;
            velocityY += orbitSpeed * GetMousePositionDelta(Input.mousePosition).y * 0.02f;
        }
        rotationYAxis += velocityX;
        rotationXAxis -= velocityY;
        
        //Limit extend of rotation around X axis
        rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
   
        Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
        Quaternion rotation = toRotation;

        //Readjust Position
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + target.position;
        
        //Assign Pos and Rot to Camera Transform
        //transform.rotation = rotation;
        //transform.position = position;

        target.rotation = rotation;
        target.position = position;

        //Interpolation between values ==> Smoother motion
        velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
        velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
        /***********************************************************************************/

        
        /***********************************************************************************/
        //Manage Zoom using field of view
        /***********************************************************************************/
        float fieldOfView = transform.GetComponent<Camera>().fieldOfView;
        transform.GetComponent<Camera>().fieldOfView = Mathf.Clamp(fieldOfView + Input.mouseScrollDelta.y * zoomSpeed , fovMin, fovMax);
        /***********************************************************************************/

        //Store Value of Mouse position as previous
        previousMousePos = Input.mousePosition;
    }

    //Calculate Mouse Position Delta (Between Frames)
    Vector3 GetMousePositionDelta(Vector3 mousePos)
    {
        Vector3 mousePositionDelta = mousePos - previousMousePos;
        return mousePositionDelta.normalized;
    }

	// Clamp angle make sure the orbit does not flip the object upside down
	float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
}


