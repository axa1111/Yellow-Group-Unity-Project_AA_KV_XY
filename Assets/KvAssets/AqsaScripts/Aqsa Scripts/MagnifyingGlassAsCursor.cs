
using UnityEngine;

/* cursor visibility https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Cursor.html
// This Script sits on the canvas*/
//the lense moves slower than the mouse - may need interpolation for faster movement???
public class MagnifyingGlassAsCursor : MonoBehaviour
{

    private float cursorDistance = 0.3f; //distance of how far magnifying glass appears in front of camera
    public Camera mainCam; //main camera
    private Vector3 offset = new Vector3(0.0f, -0.3f, 0.0f); //vector 3 to offset the lense 
    private bool isMagnifierVisible; //bool to check if magnifying glass is active 

    public GameObject magnifyingGlassParent; //magnifying glass parent object
    public GameObject treatmentSceneButton;

    void Start()
    {
        isMagnifierVisible = false; //set it to false in the beggining 
        treatmentSceneButton.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) //if the m button is pressed
        {
            isMagnifierVisible = !isMagnifierVisible; /*whatever the bool is set it will set to opposite, quicker way of writing;
             if(isMagnifierVisible)
             {
                isMagnifierVisible = false
             }
             else
             {
                isMagnifierVisible = true;
             }*/
            magnifyingGlassParent.SetActive(isMagnifierVisible); //set the magnifying glass active or inactive depending on if the bool is true or false 

            if (!treatmentSceneButton.activeSelf)
            {
                treatmentSceneButton.SetActive(true);
            }
        }



        if (isMagnifierVisible && magnifyingGlassParent != null)
        {
            Vector3 mousePos = Input.mousePosition; //getting mouse position on the screen
            mousePos.z = cursorDistance; //setting the distance of the magnifier from the camera
            Vector3 worldPos = mainCam.ScreenToWorldPoint(mousePos); //converting 2d screen position to 3d (X, Y, Z)
            magnifyingGlassParent.transform.position = worldPos + offset; //setting mgnifying glass to where the mouse is plus the offset 
        }
    }
}
