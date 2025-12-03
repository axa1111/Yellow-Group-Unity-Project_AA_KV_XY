using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;


//thiss script sits on the interactables parent obj in the scene
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

    //speed
    private float speed = 2f;
    private float returnSpeed = 0.01f;

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

    void Start()
    {
        footTowelBucketRend = footTowelBucketObj.GetComponent<Renderer>();
        interactablesManagerScript = GetComponent<InteractablesManager>();
        rayCastManagerScript = cameraObj.GetComponent<RayCastManager>();
        darkYellow = new Color(78 / 255f, 60 / 255f, 0f);
        leftFootSoldierCollider = leftFootSoldierHighlightObj.GetComponent<CapsuleCollider>();
    }

    public void StartDunkingFootTowel()
    {
        StartCoroutine(StartWetFootTowel());
    }

    //MANAGING DUNKING TOWEL IN WATER
    private IEnumerator StartWetFootTowel()
    {
        yield return new WaitForSeconds(0.01f);
        interactablesManagerScript.SwapActiveObj(footTowelTableObj, footTowelBucketObj);
        yield return new WaitForSeconds(2.2f);
        footTowelBucketRend.material.SetColor("_Color", darkYellow);
        yield return new WaitForSeconds(2.5f);
        interactablesManagerScript.SwapActiveObj(footTowelBucketObj, dampFootTowelTableObj);
        rayCastManagerScript.AddInteractable(dampFootTowelTableObj);//adding the damp towel as it is set active later on in the game


    }

    //put towel on foot
    void Update()
    {
        if (isMoving && dampFootTowelPickedUp != null)
        {
            dampFootTowelPickedUp.transform.position = Vector3.MoveTowards(dampFootTowelPickedUp.transform.position, soldiersLeftFoot.transform.position, speed * Time.deltaTime);

            if (Vector3.Distance(dampFootTowelPickedUp.transform.position, soldiersLeftFoot.transform.position) < 0.01f)
            {
                StartCoroutine(clothDampFootTowelToggle());
                dampFootTowelPickedUp.transform.position = soldiersLeftFoot.transform.position;
            }
        }
    }

    public void MoveDampTowelToFoot()
    {
        if (dampFootTowelPickedUp != null)
        {
            dampFootTowelPickedUp.transform.SetParent(null, true); //setting null to remove the the camera as parent and setting true to keep the position it was in the world space
            isMoving = true;
            leftFootSoldierCollider.enabled = false;
        }
    }
    
    private IEnumerator clothDampFootTowelToggle()
    {
        yield return new WaitForSeconds(2f);

        while (Vector3.Distance(dampFootTowelPickedUp.transform.position, tableTowelPos.transform.position) > 0.01f)
        {
            dampFootTowelPickedUp.transform.position = Vector3.MoveTowards(dampFootTowelPickedUp.transform.position, tableTowelPos.transform.position, returnSpeed * Time.deltaTime);
            yield return null;
        }
        dampFootTowelPickedUp.transform.position = tableTowelPos.transform.position;
        interactablesManagerScript.SwapActiveObj(dampFootTowelPickedUp, dampFootTowelTableObj);
        dampFootTowelCollider = dampFootTowelTableObj.GetComponent<Collider>();
        dampFootTowelCollider.enabled = false;
        isMoving = false;
        
        
    }
}
