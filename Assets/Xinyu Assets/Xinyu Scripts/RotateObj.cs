using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//This is the link for the youtube video i got this code from https://youtu.be/tnGWmYRKeEM?si=Up62WVpnfa9vbDXA


public class RotateObj : MonoBehaviour
{
    public float rotationSpeed;

    

    private void OnMouseDrag()
    {
        float rotY = Input.GetAxis("Mouse Y") * rotationSpeed;
        float rotX = Input.GetAxis("Mouse X") * rotationSpeed;

        transform.Rotate(Vector3.down, rotX);
        transform.Rotate(Vector3.right, rotY);
    }
}
