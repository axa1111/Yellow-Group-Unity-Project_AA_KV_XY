using UnityEngine;

public class InstructionsMenuToggle : MonoBehaviour
{
    public bool isInstructionsVisible;
    public GameObject InstructionsObj;
     void Start()
    {
        isInstructionsVisible = true; //set it to true in the beggining
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) //if the I button is pressed
        {
            isInstructionsVisible = !isInstructionsVisible; /*whatever the bool is set it will set to opposite, quicker way of writing;
             if(isInstructionsVisible)
             {
                isInstructionsVisible = false
             }
             else
             {
                isInstructionsVisible = true;
             }*/

            InstructionsObj.SetActive(isInstructionsVisible); //set the magnifying glass active or inactive depending on if the bool is true or false
        }
    }

}
