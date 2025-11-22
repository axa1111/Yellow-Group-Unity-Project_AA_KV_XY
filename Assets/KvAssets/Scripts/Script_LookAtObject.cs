using UnityEngine;

public class Script_LookAtObject : MonoBehaviour
{
    public GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LookAt()
    {
        LookAt(Transform.LookAt target);
    }
}
