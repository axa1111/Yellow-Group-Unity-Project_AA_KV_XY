using System.Collections;
using UnityEngine;

//this script will manage the walkiw talkie including the animation and audio etc. 
public class WalkieTalkieManager : MonoBehaviour
{
    public GameObject walkieTalkieObj;
    private Animator walkieTalkieAnim;

    public GameObject mainCameraObj;
    private Animator mainCameraAnim;

    private GameObject fadePanelObj;
    private GameObject canvasObj;
    private Animator fadePanelAnim;

    public void Start()
    {
        walkieTalkieAnim = walkieTalkieObj.GetComponent<Animator>();
        mainCameraAnim = mainCameraObj.GetComponent<Animator>();
        canvasObj = GameObject.FindGameObjectWithTag("GameManagerCanvas");
        fadePanelObj = canvasObj.transform.Find("Fade_ToDark_Panel").gameObject;
    }
    public void HideWalkieTalkie()
    {
        StartCoroutine(WalkiTalkieDisappears());
    }

    private IEnumerator WalkiTalkieDisappears()
    {
        yield return new WaitForSeconds(0.5f);
        walkieTalkieAnim.SetBool("putWalkieTalkieAway", true);
        yield return new WaitForSeconds(2f);
        mainCameraAnim.SetBool("isWalking", true);
        yield return new WaitForSeconds(8f);
        fadePanelObj.SetActive(true);

    }
}
