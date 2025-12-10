using UnityEngine;

public class ModelToReset : MonoBehaviour
{
     public Quaternion originalRotation; //public variable to store orignal rotation
    public GameObject model; //model we want to rotate
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    public void OnButtonResetClick() //when reset button is pressed
    {
        model.transform.rotation = originalRotation; //set the models rotation to the original rotation values
    }
}
