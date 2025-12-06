using UnityEngine;
using UnityEngine.UI;

public class SimpleClickShowButton : MonoBehaviour
{
    public Button myButton;  // 把UI按钮拖到这里
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                // 如果点击到了这个模型的碰撞体
                if (hit.collider == GetComponent<Collider>())
                {
                    myButton.gameObject.SetActive(true);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //按空格键隐藏按钮
            myButton.gameObject.SetActive(false);
        }
        
    }
    
}