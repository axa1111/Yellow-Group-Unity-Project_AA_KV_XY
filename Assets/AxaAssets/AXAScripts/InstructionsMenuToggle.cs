using UnityEngine;
/*This script sits on the instruction_parent obj in the treatment scene, it toggles the instructions ppanel on and off*/
public class InstructionsMenuToggle : MonoBehaviour
{
    //bool to check if instructions panel is visible 
    public bool isInstructionsVisible;
    public bool isDialogueVisible; //bool to check if dialogue is visble 
    public GameObject InstructionsObj; //instruction panel ref
    public GameObject dialogueParent; //dialogue parent ref
     void Start()
    {
        //setting is instructions visible to true as the senc=e will begin with showing the instructions
        isInstructionsVisible = true; //set it to true in the beggining
        dialogueParent.SetActive(false); //tunr off te dialogue 
        isDialogueVisible = false; //ser bool to false
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
             isDialogueVisible = !isDialogueVisible; //whatever the bool is set it will set to opposite,
            InstructionsObj.SetActive(isInstructionsVisible); //set the instructions obj active or inactive depending on if the bool is true or false
            dialogueParent.SetActive(isDialogueVisible); //set the dialogue parent obj active or inactive depending on if the bool is true or false
        }
    }

}
