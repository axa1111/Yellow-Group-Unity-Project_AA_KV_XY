using System.Collections;
using UnityEngine;

//this script sits on the blanket obj in the scene
//it turns the gravity off of the blankets cloth component
//this stops the blanket from slipping off 

public class Blanket : MonoBehaviour
{
    //ref to cloth component
    private Cloth cloth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set cloth componenet
        cloth = GetComponent<Cloth>();

        //start coroutine to turn gravity off
        StartCoroutine(turnGravityOff());
    }

    private IEnumerator turnGravityOff()
    {
        //wait 4.5 seconds so blanket can move into position
        yield return new WaitForSeconds(4.5f);

        //turn the gravity off
        cloth.useGravity = false;
    }
}
