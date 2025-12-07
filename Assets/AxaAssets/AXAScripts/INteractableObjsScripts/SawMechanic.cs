using System.Collections;
using UnityEngine;

public class SawMechanic : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject rightFootSawPos;
    public GameObject secondRightFootSawPos;
    public GameObject sawPickedUp;
    public GameObject sawPositionTable;
    public GameObject sawOnTable;

//floats
    private float speed = 3.3f;
    private float slowerMovementSpeed = 1f;

//bools
    private bool isMoving = false;
    private bool atFirstPosition = false;
    private bool atSecondPosition = false;
    private bool sawingDone = false;
    private bool coroutineHasBegun = false;//so coroutine only runs instead of every frame once as we trigger it in the update method
    public bool readyForFinalPosition = false;

    //animator
    private Animator sawAnim;

    //scripts
    private InteractablesManager interactablesManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactablesManager = GetComponent<InteractablesManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //move foot to saw
        if (isMoving)
        {
            if (sawPickedUp != null)
            {

                if (!atFirstPosition)
                {
                    sawPickedUp.transform.SetPositionAndRotation(Vector3.Lerp(sawPickedUp.transform.position, rightFootSawPos.transform.position, speed * Time.deltaTime), Quaternion.Slerp(sawPickedUp.transform.rotation, rightFootSawPos.transform.rotation, speed * Time.deltaTime));

                    if (Vector3.Distance(sawPickedUp.transform.position, rightFootSawPos.transform.position) < 0.1f && Quaternion.Angle(sawPickedUp.transform.rotation, rightFootSawPos.transform.rotation) < 0.1f)
                    {
                        sawPickedUp.transform.position = rightFootSawPos.transform.position;
                        sawPickedUp.transform.rotation = rightFootSawPos.transform.rotation;
                        atFirstPosition = true;
                    }
                }
                else if(atFirstPosition && !atSecondPosition)
                {
                    sawPickedUp.transform.position = Vector3.MoveTowards(sawPickedUp.transform.position, secondRightFootSawPos.transform.position, slowerMovementSpeed * Time.deltaTime);
                    if (Vector3.Distance(sawPickedUp.transform.position, secondRightFootSawPos.transform.position) < 0.01f)
                    {
                        sawPickedUp.transform.position = secondRightFootSawPos.transform.position;
                        atSecondPosition = true;

                    }
                }

                if (sawingDone && atSecondPosition && !readyForFinalPosition)
                {
                    sawPickedUp.transform.SetPositionAndRotation(Vector3.Lerp(sawPickedUp.transform.position, rightFootSawPos.transform.position, speed * Time.deltaTime), Quaternion.Slerp(sawPickedUp.transform.rotation, rightFootSawPos.transform.rotation, speed * Time.deltaTime));

                    if (Vector3.Distance(sawPickedUp.transform.position, rightFootSawPos.transform.position) < 0.1f && Quaternion.Angle(sawPickedUp.transform.rotation, rightFootSawPos.transform.rotation) < 0.1f)
                    {
                        sawPickedUp.transform.position = rightFootSawPos.transform.position;
                        sawPickedUp.transform.rotation = rightFootSawPos.transform.rotation;
                        readyForFinalPosition = true;
                    }
                }
                else if(sawingDone && atSecondPosition && readyForFinalPosition)
                {
                    sawPickedUp.transform.SetPositionAndRotation(Vector3.Lerp(sawPickedUp.transform.position, sawPositionTable.transform.position, speed * Time.deltaTime), Quaternion.Slerp(sawPickedUp.transform.rotation, sawPositionTable.transform.rotation, speed * Time.deltaTime));

                    if (Vector3.Distance(sawPickedUp.transform.position, sawPositionTable.transform.position) < 15f && Quaternion.Angle(sawPickedUp.transform.rotation, sawPositionTable.transform.rotation) < 15f)
                    {
                        sawPickedUp.transform.position = sawPositionTable.transform.position;
                        sawPickedUp.transform.rotation = sawPositionTable.transform.rotation;
                        interactablesManager.SwapActiveObj(sawPickedUp, sawOnTable);
                        isMoving = false;
                        atFirstPosition = false;
                        atSecondPosition = false;
                        sawingDone = false;
                        coroutineHasBegun = false;
                        readyForFinalPosition = false;
                    }
                }

            }
        }

        if (sawPickedUp != null && atSecondPosition && !sawingDone && !coroutineHasBegun)
        {
            StartCoroutine(StartSawAnimationAfterDelay());
            coroutineHasBegun = true;
        }
    }

    public void MoveSawToFoot()
    {
        if (sawPickedUp != null)
        {
            sawPickedUp.transform.SetParent(null, true); //setting null to remove the the camera as parent and setting true to keep the position it was in the world space
            isMoving = true;
        }
    }

    private IEnumerator StartSawAnimationAfterDelay()
    {
        yield return new WaitForSeconds(0.8f);
        sawAnim = sawPickedUp.GetComponent<Animator>();
        sawAnim.enabled = true;
        sawAnim.SetBool("sawAnimationBegin", true);
        yield return new WaitForSeconds(5f);
        sawAnim.enabled = false;
        sawingDone = true;
    }
}
