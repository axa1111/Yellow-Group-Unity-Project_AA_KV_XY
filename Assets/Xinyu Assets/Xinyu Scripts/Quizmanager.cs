using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Quizmanager : MonoBehaviour
{
    public int maxQuestionIndex = 4; //// 最大问题数量（比如设置为3，表示有3道题
    public int myQuestionIndex = 0;
    public List<GameObject> questionList;
    public int score = 0;
    public GameObject finalPanel;
    /*public Button nextButton; // Next按钮的引用（需要在Unity中拖拽赋值）*/

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // OnNextClick();
        /*// 如果Next按钮不为空（已赋值）
        if (nextButton != null)
        {
            // 禁用Next按钮（变成灰色，不能点击）
            nextButton.interactable = false;
        }

        //reference:https://discussions.unity.com/t/understanding-a-foreach-loop/49363
        // 运行完所有问题
        foreach (GameObject question in questionList)
        {
            // 隐藏所有问题（开始时什么都不显示）
            question.SetActive(false);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        /*// 这个方法可以让其他脚本调用，用来启用Next按钮
    public void EnableNextButton()
    {
        // 检查Next按钮是否已赋值
        if (nextButton != null)
        {
            // 启用Next按钮（变成正常颜色，可以点击）
            nextButton.interactable = true;
            
            // 在控制台打印调试信息
            Debug.Log("Next按钮已启用");
        }
    }*/


    public void OnNextClick()
    {
        /*// 先禁用Next按钮，防止玩家连续点击
        if (nextButton != null)
        {
            nextButton.interactable = false;
        }
        
        // 隐藏当前显示的所有问题
        foreach (GameObject question in questionList)
        {
            question.SetActive(false);
        }*/

        // 判断是否还有题目
        // 条件1：当前题号小于最大题数
        // 条件2：问题列表中还有问题
        if (myQuestionIndex < maxQuestionIndex)
        {
        //Pick up ramdomly one question out from the list
        // 从剩余问题中随机选一个
        // Random.Range(0, questionList.Count) 生成0到Count-1的随机数
        int index = Random.Range(0, questionList.Count);

        // 显示选中的问题
        //set active the gameobject from the list at position index 
        questionList[index].SetActive(true);

        //remove the item at index from the list
        questionList.RemoveAt(index);
        //increase my question index
        myQuestionIndex += 1;
        }
        else
        {
            Debug.Log(myQuestionIndex);
            finalPanel.SetActive(true);
            finalPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Score is " + score;
            // 禁用Next按钮（游戏结束，不需要再点击）
            /*if (nextButton != null)
            {
                nextButton.interactable = false;
            }*/
        }
    }
}
