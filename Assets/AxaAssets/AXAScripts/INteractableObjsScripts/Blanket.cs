using System.Collections;
using UnityEngine;

public class Blanket : MonoBehaviour
{
    private Cloth cloth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cloth = GetComponent<Cloth>();
        StartCoroutine(turnGravityOff());
    }

   private IEnumerator turnGravityOff()
    {
        yield return new WaitForSeconds(4.5f);
        cloth.useGravity = false;
    }
}
