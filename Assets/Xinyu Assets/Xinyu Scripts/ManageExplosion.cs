using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectClassList
{
    public GameObject obj;
    public Vector3 objDisp;
}

public class ManageExplosion : MonoBehaviour
{
    private List<ObjectClassList> myObjList;

    [SerializeField]
    private Transform myExplPivot;

    [SerializeField]
    private int factor = 200; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myObjList = new List<ObjectClassList>();

        //Populate teh List with the child attribute of the objerct
        for (int i = 0; i< transform.childCount; i++)
        {
            ObjectClassList myClassObj = new ObjectClassList();
            myClassObj.obj = transform.GetChild(i).gameObject;
            myClassObj.objDisp = transform.GetChild(i).position - myExplPivot.position;
            Debug.Log(transform.GetChild(i).name + "  "  + myClassObj.objDisp);
            myObjList.Add(myClassObj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //不需要if这一节
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for(int j = 0; j< myObjList.Count; j++)
            {
                Debug.Log("Obj is:" + myObjList[j].obj.name + "& Displacement is:" + myObjList[j].objDisp);
            }
        }
    }

    public void OnSliderChange(Slider mySlider)
    {
         for(int j = 0; j< myObjList.Count; j++)
            {
                
                myObjList[j].obj.transform.position = myExplPivot.position + myObjList[j].objDisp + myObjList[j].objDisp * factor * mySlider.value;
                // + myObjList[j].objDisp 多一个这个会让由多个cube组成的object不变形，如果没有这个滑动slider到最小会使object变成一个cube
            }
    }
}
