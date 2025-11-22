using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//this script will manage the walkiw talkie including the animation and audio etc. 
public class WalkieTalkieManager : MonoBehaviour
{
    public GameObject walkieTalkieObj;
    private Animator walkieTalkieAnim;

    public GameObject mainCameraObj;
    private Animator mainCameraAnim;

    public GameObject fadePanelObj;
    private Animator fadePanelAnim;


    public void HideWalkieTalkie()
    {
        StartCoroutine(WalkiTalkieDisappears());
        walkieTalkieAnim = walkieTalkieObj.GetComponent<Animator>();
        mainCameraAnim = mainCameraObj.GetComponent<Animator>();
        fadePanelAnim = fadePanelObj.GetComponent<Animator>();
        
    }

    private IEnumerator WalkiTalkieDisappears()
    {
        yield return new WaitForSeconds(0.5f);
        walkieTalkieAnim.SetBool("putWalkieTalkieAway", true);
        yield return new WaitForSeconds(2f);
        walkieTalkieObj.SetActive(false);
        mainCameraAnim.SetBool("isWalking", true);
        yield return new WaitForSeconds(8f);
        fadePanelObj.SetActive(true);
        //trigger next scene
    }
}
