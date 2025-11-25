using UnityEngine;
using System.Collections;

//rotate around https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Transform.RotateAround.html
public class Script_ManageCamera : MonoBehaviour
{
    public GameObject leftFootTarget;
    public GameObject rightFootTarget;
    private GameObject currentTargetToLookAt;

    private Animator cameraAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(currentTargetToLookAt.transform.position, Vector3.up, -50 * Time.deltaTime);
        }

        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(currentTargetToLookAt.transform.position, Vector3.up, 50 * Time.deltaTime);
        }

        if(currentTargetToLookAt != null)
        {
            transform.LookAt(currentTargetToLookAt.transform);
        }
    }

    public void OnRightFootButtonClick()
    {
        //set right foot as target and add button to trigger animation

        cameraAnim.enabled = true;
        StartCoroutine(WaitForRightFootAnimation());
        //make 'inspect right foot' button inactive until 'inspect left foot' clicked?
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

    private IEnumerator WaitForRightFootAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        cameraAnim.SetBool("isRightCloseLookButtonClicked", true);
        currentTargetToLookAt = rightFootTarget;
        yield return new WaitForSeconds(1f);
        cameraAnim.enabled = false;
    }

}
