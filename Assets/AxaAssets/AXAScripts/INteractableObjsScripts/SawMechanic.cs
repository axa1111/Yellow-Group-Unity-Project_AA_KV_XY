using System.Collections;
using UnityEngine;
//this script sits on the interactable parent obj in teatment scene
// it manages the saw interactions
public class SawMechanic : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject rightFootSawPos;
    public GameObject secondRightFootSawPos;
    public GameObject sawPickedUp;
    public GameObject sawPositionTable;
    public GameObject sawOnTable;
    public GameObject dialogueFive;
    public GameObject dialogueSix;

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
    public bool readyToMoveOntoDiagnosisScene = false;

    //animator
    private Animator sawAnim;

    //scripts
    private InteractablesManager interactablesManager;

    //particle system
    public ParticleSystem bloodParticleSystem;

    //audio source
    private AudioSource sawAS;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactablesManager = GetComponent<InteractablesManager>();
        bloodParticleSystem.Stop();

        sawAS = sawPickedUp.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //if is moving is true
        if (isMoving)
        {
            if (sawPickedUp != null) //if saw picked up is not null
            {

                if (!atFirstPosition) //if we are not yet at the first position
                {
                    //move the saw to the right foot position
                    sawPickedUp.transform.SetPositionAndRotation(Vector3.Lerp(sawPickedUp.transform.position, rightFootSawPos.transform.position, speed * Time.deltaTime), Quaternion.Slerp(sawPickedUp.transform.rotation, rightFootSawPos.transform.rotation, speed * Time.deltaTime));

                    //when it is close to that position
                    if (Vector3.Distance(sawPickedUp.transform.position, rightFootSawPos.transform.position) < 0.1f && Quaternion.Angle(sawPickedUp.transform.rotation, rightFootSawPos.transform.rotation) < 0.1f)
                    {
                        //confirm the position and rotation to be set to the rightfootsaw transform
                        sawPickedUp.transform.position = rightFootSawPos.transform.position;
                        sawPickedUp.transform.rotation = rightFootSawPos.transform.rotation;

                        //set at first position to true
                        atFirstPosition = true;
                    }
                }
                else if (atFirstPosition && !atSecondPosition) //if we are at the first position but not yet moved to the second position (using bools to check)
                {
                    //move the saw picked up to the second position
                    sawPickedUp.transform.position = Vector3.MoveTowards(sawPickedUp.transform.position, secondRightFootSawPos.transform.position, slowerMovementSpeed * Time.deltaTime);
                    //when it is close to that position
                    if (Vector3.Distance(sawPickedUp.transform.position, secondRightFootSawPos.transform.position) < 0.01f)
                    {
                         //confirm the position set to the second position transform
                        sawPickedUp.transform.position = secondRightFootSawPos.transform.position;
                        atSecondPosition = true; //set bool to true

                    }
                }
                //if sawing done = true and they are at the second positon but not the final position
                if (sawingDone && atSecondPosition && !readyForFinalPosition)
                {
                    //move the saw picked up to right foot position
                    sawPickedUp.transform.SetPositionAndRotation(Vector3.Lerp(sawPickedUp.transform.position, rightFootSawPos.transform.position, speed * Time.deltaTime), Quaternion.Slerp(sawPickedUp.transform.rotation, rightFootSawPos.transform.rotation, speed * Time.deltaTime));

                    //when it is close to that position
                    if (Vector3.Distance(sawPickedUp.transform.position, rightFootSawPos.transform.position) < 0.1f && Quaternion.Angle(sawPickedUp.transform.rotation, rightFootSawPos.transform.rotation) < 0.1f)
                    {
                        //confirm the saw picked up positiona nd rotation to be at 
                        sawPickedUp.transform.position = rightFootSawPos.transform.position;
                        sawPickedUp.transform.rotation = rightFootSawPos.transform.rotation;
                        readyForFinalPosition = true; //set bool to true
                    }
                }
                else if (sawingDone && atSecondPosition && readyForFinalPosition) //if sawing done and all bools true
                {
                    //move saw to tsble 
                    sawPickedUp.transform.SetPositionAndRotation(Vector3.Lerp(sawPickedUp.transform.position, sawPositionTable.transform.position, speed * Time.deltaTime), Quaternion.Slerp(sawPickedUp.transform.rotation, sawPositionTable.transform.rotation, speed * Time.deltaTime));
                    //when it is near the table
                    if (Vector3.Distance(sawPickedUp.transform.position, sawPositionTable.transform.position) < 0.5f && Quaternion.Angle(sawPickedUp.transform.rotation, sawPositionTable.transform.rotation) < 0.5f)
                    {
                        //confirm the position and rotation to be the the tablesaw position and rotatino 
                        sawPickedUp.transform.position = sawPositionTable.transform.position;
                        sawPickedUp.transform.rotation = sawPositionTable.transform.rotation;
                        interactablesManager.SwapActiveObj(sawPickedUp, sawOnTable); //swap out the saw to the tavle sae
                        //set bools to false
                        isMoving = false;
                        atFirstPosition = false;
                        atSecondPosition = false;
                        sawingDone = false;
                        coroutineHasBegun = false;
                        readyForFinalPosition = false;

                        //set dialogue to false 
                        dialogueFive.SetActive(false);
                        dialogueSix.SetActive(true);
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
        bloodParticleSystem.Play();
        sawAS.Play();
        yield return new WaitForSeconds(5f);
        sawAnim.enabled = false;
        sawingDone = true;
        readyToMoveOntoDiagnosisScene = true;
    }
}
