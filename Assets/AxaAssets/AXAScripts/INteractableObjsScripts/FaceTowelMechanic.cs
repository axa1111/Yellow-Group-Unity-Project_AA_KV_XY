using System.Collections;
using UnityEngine;

public class FaceTowelMechanic : MonoBehaviour
{
    private bool isMoving = false;

    [Header("GameObjects")]
    public GameObject faceTowelPickedUpObj;
    public GameObject facePositionObj;
    public GameObject faceTowelTablePositionObj;
    public GameObject faceTowelOnTableObj;
    public GameObject headHighlightScript;
    public GameObject zzzParticleSystemObj; //reference to zz particle system
    public GameObject dialogueFour;

    private float speed = 2f;
    private float returnSpeed = 0.01f;

    //Colliders
    private Collider faceTowelOnTableCollider;
    private Collider facePositionCollider;

    //Scripts
    private InteractablesManager interactablesManagerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactablesManagerScript = GetComponent<InteractablesManager>();
        facePositionCollider = headHighlightScript.GetComponent<Collider>();
        zzzParticleSystemObj.SetActive(false); //make sure its off the zz particle system
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving && faceTowelPickedUpObj != null)
        {
            faceTowelPickedUpObj.transform.position = Vector3.MoveTowards(faceTowelPickedUpObj.transform.position, facePositionObj.transform.position, speed * Time.deltaTime);

            if (Vector3.Distance(faceTowelPickedUpObj.transform.position, facePositionObj.transform.position) < 0.01f)
            {
                StartCoroutine(faceClothToggle());
                faceTowelPickedUpObj.transform.position = facePositionObj.transform.position;
            }
        }
    }
   
   public void MoveTowelToFace()
    {
        if (faceTowelPickedUpObj != null)
        {
            faceTowelPickedUpObj.transform.SetParent(null, true); //setting null to remove the the camera as parent and setting true to keep the position it was in the world space
            isMoving = true;
            facePositionCollider.enabled = false;
        }
    }
   private IEnumerator faceClothToggle()
    {
        yield return new WaitForSeconds(2f);

        while (Vector3.Distance(faceTowelPickedUpObj.transform.position, faceTowelTablePositionObj.transform.position) > 0.01f)
        {
            faceTowelPickedUpObj.transform.position = Vector3.MoveTowards(faceTowelPickedUpObj.transform.position, faceTowelTablePositionObj.transform.position, returnSpeed * Time.deltaTime);
            yield return null;
        }
        faceTowelPickedUpObj.transform.position = faceTowelTablePositionObj.transform.position;
        interactablesManagerScript.SwapActiveObj(faceTowelPickedUpObj, faceTowelOnTableObj);
        faceTowelOnTableCollider = faceTowelOnTableObj.GetComponent<Collider>();
        faceTowelOnTableCollider.enabled = false;
        isMoving = false;
        zzzParticleSystemObj.SetActive(true); // turn on the zzz particle system
        yield return new WaitForSeconds(0.7f);
        dialogueFour.SetActive(true);
    }
}
