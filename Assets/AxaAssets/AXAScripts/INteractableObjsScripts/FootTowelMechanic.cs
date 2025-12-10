using System.Collections;
using UnityEngine;


//thiss script sits on the interactables parent obj in the scene
//it manages the interaction of the foot towel 
//there are two shaders created which allow for the texture chnage of the foot 
public class FootTowelMechanic : MonoBehaviour
{
    //GameObjects
    [Header("GameObjects")]
    public GameObject footTowelTableObj;
    public GameObject footTowelBucketObj;
    public GameObject dampFootTowelTableObj;
    public GameObject dampFootTowelPickedUp;
    public GameObject soldiersLeftFoot;
    public GameObject cameraObj;
    public GameObject tableTowelPos;
    public GameObject leftFootSoldierHighlightObj;
    public GameObject soldierObj;
    public GameObject DialogueTwo;//ref to dialogue 2 
    public GameObject dialogueThree;
    private Renderer soldierRenderer;

    //animators
    private Animator soldierAnimator;

    //speed
    private float speed = 2f;
    private float returnSpeed = 0.01f;

    //time float
    float duration = 6f;
    float elapsed = 0f;

    //bool 
    private bool isMoving = false;


    //colour 
    private Color darkYellow;
    //Renderer
    private Renderer footTowelBucketRend;

    //Scripts
    private InteractablesManager interactablesManagerScript;
    private RayCastManager rayCastManagerScript;

    //collider 
    private Collider dampFootTowelCollider;
    private Collider leftFootSoldierCollider;

    //materials
    public Material redToNeutralMat;

    void Start()
    {
        //getting the componenets setting references 
        footTowelBucketRend = footTowelBucketObj.GetComponent<Renderer>();
        interactablesManagerScript = GetComponent<InteractablesManager>();
        rayCastManagerScript = cameraObj.GetComponent<RayCastManager>();
        //setting the colour 
        darkYellow = new Color(78 / 255f, 60 / 255f, 0f);
        leftFootSoldierCollider = leftFootSoldierHighlightObj.GetComponent<CapsuleCollider>();
        soldierAnimator = soldierObj.GetComponent<Animator>();
        soldierRenderer = soldierObj.GetComponent<Renderer>();
    }

    //method to dunk foot towel 
    public void StartDunkingFootTowel()
    {
        //start coroutine StartWetFootTowel
        StartCoroutine(StartWetFootTowel());
    }

    //MANAGING DUNKING TOWEL IN WATER
    private IEnumerator StartWetFootTowel()
    {
        //wait 0.01 seconds
        yield return new WaitForSeconds(0.01f);
        //swap the towel objs
        interactablesManagerScript.SwapActiveObj(footTowelTableObj, footTowelBucketObj);
        //wait another 2.2 seconds
        yield return new WaitForSeconds(2.2f);
        //change the colour of the active foot towel to a darker yellow to make it look wet
        footTowelBucketRend.material.SetColor("_Color", darkYellow);
        //wait another 2.5 seconds
        yield return new WaitForSeconds(2.5f);
        //swap out the foot towels again
        interactablesManagerScript.SwapActiveObj(footTowelBucketObj, dampFootTowelTableObj);
        //add the damp foot towel to the list which manages the highlight script 
        rayCastManagerScript.AddInteractable(dampFootTowelTableObj);//adding the damp towel as it is set active later on in the game


    }

    //put towel on foot
    void Update()
    {
        //if is moving is true and the damp foot towel is not null
        if (isMoving && dampFootTowelPickedUp != null)
        {
            //move it towards the soldiers left foot
            dampFootTowelPickedUp.transform.position = Vector3.MoveTowards(dampFootTowelPickedUp.transform.position, soldiersLeftFoot.transform.position, speed * Time.deltaTime);

            //when we are close to it
            if (Vector3.Distance(dampFootTowelPickedUp.transform.position, soldiersLeftFoot.transform.position) < 0.01f)
            {
                //Start the coroutine clothDampFootTowelToggle
                StartCoroutine(clothDampFootTowelToggle());

                //set the damp foot towel to the soldiers left foor position
                dampFootTowelPickedUp.transform.position = soldiersLeftFoot.transform.position;
            }
        }
    }

    //method called to move the damp foot towel
    public void MoveDampTowelToFoot()
    {
        //if the damp foot towel is not null
        if (dampFootTowelPickedUp != null)
        {
            dampFootTowelPickedUp.transform.SetParent(null, true); //setting null to remove the the camera as parent and setting true to keep the position it was in the world space
            isMoving = true; //set is moving to true
            leftFootSoldierCollider.enabled = false; //tunr the collider off so it can be highlighted or interacted with again 
            //start coroutine which changes the soliders foot colour 
            StartCoroutine(ChangeFootColour());
        }
    }

    private IEnumerator clothDampFootTowelToggle()
    {
        //wait 2 seconds
        yield return new WaitForSeconds(2f);
        //when the damp towel is  away from the table position

        while (Vector3.Distance(dampFootTowelPickedUp.transform.position, tableTowelPos.transform.position) > 0.01f)
        {
            //move it towards the table position
            dampFootTowelPickedUp.transform.position = Vector3.MoveTowards(dampFootTowelPickedUp.transform.position, tableTowelPos.transform.position, returnSpeed * Time.deltaTime);
            yield return null;
        }
        dampFootTowelPickedUp.transform.position = tableTowelPos.transform.position;
        interactablesManagerScript.SwapActiveObj(dampFootTowelPickedUp, dampFootTowelTableObj); //swap out the damp towel for the table towel 
        dampFootTowelCollider = dampFootTowelTableObj.GetComponent<Collider>(); //get damp foot towel collider
        dampFootTowelCollider.enabled = false;//tunr collider off so cant be interacted with again 
        isMoving = false; //set is moving to false
    }


    private IEnumerator ChangeFootColour()
    {
        //wait one second
        yield return new WaitForSeconds(1f);
        //begin animation by setting bool true
        soldierAnimator.SetBool("ChangeFootoRed", true);
        //set dialogue two active
        DialogueTwo.SetActive(true);
        //wait 1.5 seconds
        yield return new WaitForSeconds(1.5f);
        //turn animation off
        soldierAnimator.enabled = false;
        //wait half a second
        yield return new WaitForSeconds(0.5f);
        //swap the material of the soldier to redToNEutralMAt
        soldierRenderer.material = redToNeutralMat;

        //whil the time elapsed is less than the time duration
        while (elapsed < duration)
        {
            //gradually change th eblend value over this time (6seconds)
            float blendValue = Mathf.Clamp01(elapsed / duration);
            //set the materials Float Blend 2 value to the changing blend value
            soldierRenderer.material.SetFloat("_Float_Blend_2", blendValue);
            elapsed += Time.deltaTime;
            yield return null; //wait till next frame
        }
        soldierRenderer.material.SetFloat("_Float_Blend_2", 1f); //make sure the float blend is at 1
        DialogueTwo.SetActive(false); //turn off dialogue 2
        dialogueThree.SetActive(true); //turn on dialogue 3

    }
}
