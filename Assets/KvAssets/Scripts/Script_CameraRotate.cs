using UnityEngine;

public class Script_CameraRotate : MonoBehaviour
{
    //public float rotationSpeed;
    //public float rotationDuration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("RightArrowPressed");
            transform.Rotate(0.0f,-0.1f,0.0f, Space.Self);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("LeftArrowPressed");
            transform.Rotate(0.0f,0.1f,0.0f, Space.Self);
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("UpArrowPressed");
            transform.Rotate(0.1f,0.0f,0.0f, Space.Self);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("DownArrowPressed");
            transform.Rotate(-0.1f,0.0f,0.0f, Space.Self);
        }
    }
}
