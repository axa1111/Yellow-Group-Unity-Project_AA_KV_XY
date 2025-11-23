using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_CameraAnimation : MonoBehaviour
{
    //Animation script for camera

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        animator.SetBool("CloserLookClicked", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
