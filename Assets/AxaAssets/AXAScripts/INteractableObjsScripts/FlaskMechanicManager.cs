using System.Collections;
using UnityEngine;
//this script will manage the flask interaction and animation being triggered it sits on interactable parent obj
public class FlaskMechanicManager : MonoBehaviour
{
    [Header("Game Object References")]
    public GameObject flaskObj;
    public GameObject corkObj;
    public GameObject faceTowelObj;

    [Header("Texture References")]
    public Texture chloroformedTowel;

    //animators
    private Animator flaskAnim;
    private Animator corkAnim;
    private Animator faceTowelAnim;

    //colliders
    private Collider flaskCollider;

    //Audio Aource
    private AudioSource flaskAS;
    private AudioSource corkAS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //getting components from each obj
        if (flaskObj != null)
        {
            flaskAnim = flaskObj.GetComponent<Animator>();
            flaskAS = flaskObj.GetComponent<AudioSource>();
        }

        if (corkObj != null)
        {
            corkAnim = corkObj.GetComponent<Animator>();
            corkAS = corkObj.GetComponent<AudioSource>();
        }

        if(faceTowelObj != null)
        {
            faceTowelAnim = faceTowelObj.GetComponent<Animator>();
        }

        flaskCollider = flaskObj.GetComponent<Collider>();
    }

    //public method to trigger coroutine which will be accessed by the interactbles sscript
    public void FlaskMechanic()
    {
        StartCoroutine(StartFlaskMechanic());

    }
    
    //coroutineto trigger animation of the bottle and do the texture change of the towel here
    //turning off collider for flask so it can't be interacted wth again and highligh stops
    private IEnumerator StartFlaskMechanic()
    {
        //turn off flask collider so it no longer highlights
        flaskCollider.enabled = false;
        //play the cork animation by setting bool to true
        corkAnim.SetBool("isCorkRemoved", true);
        //play the audio
        corkAS.Play();
        //wait one second
        yield return new WaitForSeconds(1.0f);
        //play the flask pouring animation by setting bool to true
        flaskAnim.SetBool("FlaskToEmpty", true);
        //play the audio
        flaskAS.Play();
        //wait one second
        yield return new WaitForSeconds(1.0f);
        //play the towel animation 
        faceTowelAnim.SetBool("faceTowelIsWet", true);
        
    }
}
