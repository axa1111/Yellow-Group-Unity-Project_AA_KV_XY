using UnityEngine;
using System.Collections;

public class Script_ManageCamera : MonoBehaviour
{
    public GameObject leftFootTarget;
    public GameObject rightFootTarget;
    private GameObject currentTargetToLookAt;

    private Animator cameraAnim;
    private bool animationHasBegun;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraAnim = GetComponent<Animator>();
        animationHasBegun = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f, 0.0f, 0.0f, Space.Self);
        }

        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f, 0.0f, 0.0f, Space.Self);
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
        yield return new WaitForSeconds(1.0f);
        cameraAnim.enabled = false;
        currentTargetToLookAt = rightFootTarget;
    }

}
