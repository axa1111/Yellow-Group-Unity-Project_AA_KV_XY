using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TowelMovementInteraction : MonoBehaviour
{
    public Vector3 spawnPoint;
    public bool hasBeenThreeSec;

    public bool hasEnteredFootCollider;

    private float cameraDistance;

    [SerializeField]
    private Cloth clothComponent;

    void Start()
    {
        clothComponent.enabled = false;
        hasEnteredFootCollider = false;
    }
    void OnMouseDown()
    {
        //getting the distance of the obj from camera
        cameraDistance = Vector3.Distance(Camera.main.transform.position, transform.position);
    }
    void OnMouseDrag()
    {
        //store the position of the mouse as variable mousePos
        Vector3 mousePos = Input.mousePosition;
        //set the z value to 45 (distance from camera)
        mousePos.z = cameraDistance;
        //the position of the item is equal to the position of the mouse (on screen)
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        //we enable the cloth feature 
        clothComponent.enabled = true;
    }

    void OnMouseUp()
    {
        //if the towel isnt on the foot and the player lets go of it
        if (!hasEnteredFootCollider)
        {
            //it will be moved back to the spawn point (original position)
            transform.position = spawnPoint;
            //and we will disable the cloth feature 
            clothComponent.enabled = false;
        }
    }

//when the cloth enters the obj with a collider which is tagges Left Foot
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Left Foot"))
        {
            //we set hasEnteredCollider to true
            hasEnteredFootCollider = true;
            //and we begin the towel timer coroutine
            StartCoroutine(TowelTimer());
        }
    }

    private IEnumerator TowelTimer()
    {
        //we wait for 3 seconds
        yield return new WaitForSeconds(3);
        //and then set towel enterd foot collider to false
        hasEnteredFootCollider = false;
        
        //set has been 3 seconds to true
        //this will be used later to manage the texture change of the foot
        hasBeenThreeSec = true;
        
    }
}


