using UnityEngine;

public class SawInteraction : MonoBehaviour
{
    private bool hasEnteredRightFootCollider;
    public Vector3 spawnPoint;

    private float cameraDistance;

    private Animator sawAnim;

    void Start()
    {
        hasEnteredRightFootCollider = false;
        sawAnim = GetComponent<Animator>();
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
    }

     void OnMouseUp()
    {
        //if the towel isnt on the foot and the player lets go of it
        if (!hasEnteredRightFootCollider)
        {
            //it will be moved back to the spawn point (original position)
            transform.position = spawnPoint;
        }
    }

//when the cloth enters the obj with a collider which is tagges Left Foot
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Right Foot"))
        {
            sawAnim.enabled = true;
            //we set hasEnteredCollider to true
            hasEnteredRightFootCollider = true;
            sawAnim.SetBool("isInRightFootCollider", true);

        }
    }
}
