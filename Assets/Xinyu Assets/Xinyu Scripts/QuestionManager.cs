using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class QuestionManager : MonoBehaviour
{
    public GameObject correctResponse;
    public GameObject userResponse;
    public ToggleGroup myToggleGroup;
    public GameObject positiveFeedback;
    public GameObject negativeFeedback;
    public Quizmanager myQuizManagerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myQuizManagerScript = GameObject.Find("CanvasQuiz").GetComponent<Quizmanager>();
    }
    //
    public void OnConfirmClick()
    {
        //compare the user response with the correct store into the system 
        if(myToggleGroup.AnyTogglesOn())
        {
            Toggle selectedToggle = myToggleGroup.ActiveToggles().FirstOrDefault();
            Debug.Log(selectedToggle.name);

            userResponse = selectedToggle.gameObject;

            //set all toggle as non interactable
            for(int i = 0; i < myToggleGroup.gameObject.transform.childCount; i++)
            {
                myToggleGroup.gameObject.transform.GetChild(i).GetComponent<Toggle>().interactable=false;
            }

            if(userResponse == correctResponse)
            {
                //show positive feedback
                positiveFeedback.SetActive(true);
                myQuizManagerScript.score += 1;
            }
            else
            {
                negativeFeedback.SetActive(true);
                //show negative feedback
            }
            /*// 在确认答案后，启用Next按钮
            if (myQuizManagerScript != null)
            {
                myQuizManagerScript.EnableNextButton();
            }
            else
            {
                Debug.LogError("myQuizManagerScript为空！");
            }*/

        }
        else
        {
            //no teggle selected==>show nehative feedback
            negativeFeedback.SetActive(true);
        }
    }
}
