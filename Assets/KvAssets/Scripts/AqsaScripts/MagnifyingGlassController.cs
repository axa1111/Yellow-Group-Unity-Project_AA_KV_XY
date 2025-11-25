using UnityEngine;

public class MagnifyingGlassController : MonoBehaviour
{

    void OnMouseDrag()
    {
        //store the position of the mouse as variable mousePos
        Vector3 mousePos = Input.mousePosition;
        //set the z value to 45 (distance from camera)
        mousePos.z = 0.6f;
        //the position of the item is equal to the position of the mouse (on screen)
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
