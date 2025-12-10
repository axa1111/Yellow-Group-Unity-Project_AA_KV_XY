using UnityEngine;

//this script sits on the Canvas object which is a child of Scen2 parent object

public class ModelToOriginalPosition : MonoBehaviour
{
    public Quaternion originalRotation; //public variable to store orignal rotation
    public GameObject model; //model we want to rotate
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    public void OnButtonResetClick() //when reset button is pressed
    {
        model.transform.rotation = originalRotation; //set the models rotation to the original rotation values
    }
}
