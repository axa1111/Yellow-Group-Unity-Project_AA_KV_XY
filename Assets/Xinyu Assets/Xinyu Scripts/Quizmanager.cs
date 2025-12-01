using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Quizmanager : MonoBehaviour
{
    public int maxQuestionIndex = 3;
    public int myQuestionIndex = 0;
    public List<GameObject> questionList;
    public int score = 0;
    public GameObject finalPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // OnNextClick();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNextClick()
    {
        if (myQuestionIndex < maxQuestionIndex)
        {
        //Pick up ramdomly one question out from the list
        int index = Random.Range(0, questionList.Count-1);
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
            finalPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Your Score is " + score;
        }
    }
}
