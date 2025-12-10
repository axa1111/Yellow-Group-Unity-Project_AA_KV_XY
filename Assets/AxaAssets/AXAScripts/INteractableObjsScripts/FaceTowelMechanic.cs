using System.Collections;
using UnityEngine;

public class FaceTowelMechanic : MonoBehaviour
{
    private bool isMoving = false;

    [Header("GameObjects")]
    public GameObject faceTowelPickedUpObj; //ref to face twoel picked up
    public GameObject facePositionObj; //ref to position near face the towel should move to
    public GameObject faceTowelTablePositionObj; //ref to position face towel should be in
    public GameObject faceTowelOnTableObj; //ref to fsce towel on table
    public GameObject headHighlightScript; //ref to soldiers head 
    public GameObject zzzParticleSystemObj; //reference to zz particle system
    public GameObject dialogueFour; //ref to dialogue 

    private float speed = 2f; //movement speed to 2 f
    private float returnSpeed = 0.01f; //returning speed to 0.01f

    //Colliders
    private Collider faceTowelOnTableCollider;
    private Collider facePositionCollider;

    //Scripts
    private InteractablesManager interactablesManagerScript;

    //AudioSource
    private AudioSource zzzAudioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //setting references for components/objs
        interactablesManagerScript = GetComponent<InteractablesManager>();
        facePositionCollider = headHighlightScript.GetComponent<Collider>();
        zzzParticleSystemObj.SetActive(false); //make sure its off the zz particle system
        zzzAudioSource = zzzParticleSystemObj.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the towel is moveing and the picked up face towel is not null
        if (isMoving && faceTowelPickedUpObj != null)
        {
            //move it towards the face 
            faceTowelPickedUpObj.transform.position = Vector3.MoveTowards(faceTowelPickedUpObj.transform.position, facePositionObj.transform.position, speed * Time.deltaTime);

            //when the towel is close to the face
            if (Vector3.Distance(faceTowelPickedUpObj.transform.position, facePositionObj.transform.position) < 0.01f)
            {
                //begin the coroutin 
                StartCoroutine(faceClothToggle());
                //confirm the position
                faceTowelPickedUpObj.transform.position = facePositionObj.transform.position;
            }
        }
    }
   
   //called in other script
   public void MoveTowelToFace()
    {
        //if the face towel is not null
        if (faceTowelPickedUpObj != null)
        {
            //make it parentless (as it is a child of camera)
            faceTowelPickedUpObj.transform.SetParent(null, true); //setting null to remove the the camera as parent and setting true to keep the position it was in the world space
            //set is moving true to begin the movement
            isMoving = true;
            //turn the faceposition collider off so it cant be highlighted/interacted with again
            facePositionCollider.enabled = false;
        }
    }
   private IEnumerator faceClothToggle()
    {
        //wait two seconds
        yield return new WaitForSeconds(2f);

        //while its away from the position on the table
        while (Vector3.Distance(faceTowelPickedUpObj.transform.position, faceTowelTablePositionObj.transform.position) > 0.01f)
        {
            //move it towards the position on the table and wait one frame
            faceTowelPickedUpObj.transform.position = Vector3.MoveTowards(faceTowelPickedUpObj.transform.position, faceTowelTablePositionObj.transform.position, returnSpeed * Time.deltaTime);
            yield return null;
        }
        //confirm the position to be the table position
        faceTowelPickedUpObj.transform.position = faceTowelTablePositionObj.transform.position;
        //swap the picked up towel out for the towel on the table
        interactablesManagerScript.SwapActiveObj(faceTowelPickedUpObj, faceTowelOnTableObj);
        //get the table face cloths collider
        faceTowelOnTableCollider = faceTowelOnTableObj.GetComponent<Collider>();
        //diasable it so it cant be interacted with again
        faceTowelOnTableCollider.enabled = false;
        //set is moving to false
        isMoving = false;
        //turn on the zz particle system
        zzzParticleSystemObj.SetActive(true);
        //play the audio
        zzzAudioSource.Play();
        //wait 0.7 seconds
        yield return new WaitForSeconds(0.7f);
        //show dialogue four 
        dialogueFour.SetActive(true);
    }
}
