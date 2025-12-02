using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;


//thiss script sits on the interactables parent obj in the scene
public class FootTowelMechanic : MonoBehaviour
{
    //GameObjects
    [Header("GameObjects")]
    public GameObject footTowelTableObj;
    public GameObject footTowelBucketObj;
    public GameObject dampFootTowelTableObj;

    //colour 
    private Color darkYellow;
    //Renderer

    private Renderer footTowelBucketRend;

    //Scripts
    private InteractablesManager interactablesManagerScript;

    void Start()
    {
        footTowelBucketRend = footTowelBucketObj.GetComponent<Renderer>();
        interactablesManagerScript = GetComponent<InteractablesManager>();
        darkYellow = new Color(78/255f, 60/255f, 0f);
    }

    public void StartDunkingFootTowel()
    {
        StartCoroutine(StartWetFootTowel());
    }


    private IEnumerator StartWetFootTowel()
    {
        yield return new WaitForSeconds(0.01f);
        interactablesManagerScript.SwapActiveObj(footTowelTableObj, footTowelBucketObj);
        yield return new WaitForSeconds(2.2f);
        footTowelBucketRend.material.SetColor("_Color", darkYellow);
        yield return new WaitForSeconds(2.5f);
        interactablesManagerScript.SwapActiveObj(footTowelBucketObj, dampFootTowelTableObj);

    }
}
