using UnityEngine;

public class DialogCycler : MonoBehaviour
{
public GameObject[] dialogs; // 拖入4个TMP文本 
   private int currentIndex = 0; 
 
   public void ShowNextDialog() 
   { 
       // 如果还有未显示的对话框 
       if (currentIndex < dialogs.Length) 
       { 
           // 显示当前对话框 
           dialogs[currentIndex].SetActive(true); 
           currentIndex++; 
       } 
   } 
}
