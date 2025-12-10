using System.Collections;
using System.Configuration;
using UnityEngine;

//this script will manage the walkiw talkie including the animation and audio etc. 
public class WalkieTalkieManager : MonoBehaviour
{
    //ref to walkie talkie obj
    public GameObject walkieTalkieObj;
    //ref to walkie talkie animator
    private Animator walkieTalkieAnim;

    //REF TO MAIN CAMERA OBJ
    public GameObject mainCameraObj;
    //ref to main cam animation
    private Animator mainCameraAnim;

    //ref to fade panel
    private GameObject fadePanelObj;

   //ref to canvas 
    private GameObject canvasObj;

    //audio source
    private AudioSource cameraAS;

    public void Start()
    {
        //setting walkie talkie animator
        walkieTalkieAnim = walkieTalkieObj.GetComponent<Animator>();
        //setting camera animator
        mainCameraAnim = mainCameraObj.GetComponent<Animator>();
        //setting vanvas through tag
        canvasObj = GameObject.FindGameObjectWithTag("GameManagerCanvas");
        //setting fade panel
        fadePanelObj = canvasObj.transform.Find("Fade_ToDark_Panel").gameObject;
        //setting audiosource on camera
        cameraAS = mainCameraObj.GetComponent<AudioSource>();
    }
    
    //Method called on next button 
        public void HideWalkieTalkie()
    {
        //Start Coroutine WalkieTalkie Disapears
        StartCoroutine(WalkiTalkieDisappears());
    }

    private IEnumerator WalkiTalkieDisappears()
    {
        //wait for half a second
        yield return new WaitForSeconds(0.5f);
        //set bool true to trigger animation
        walkieTalkieAnim.SetBool("putWalkieTalkieAway", true);
        //waot 2 seconds
        yield return new WaitForSeconds(2f);
        //set bool to true to trigger walking animation
        mainCameraAnim.SetBool("isWalking", true);
        //play the footsteps audio
        cameraAS.Play();
        //wait 8 seconds
        yield return new WaitForSeconds(8f);
        //turn on the fade panel
        fadePanelObj.SetActive(true);

    }
}
