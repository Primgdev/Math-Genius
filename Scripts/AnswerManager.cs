using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerManager : MonoBehaviour
{
    public bool isCorrect = false;
    public AudioSource correctAnswer;
    public AudioSource wrongAnswer;
    public QuizManager QM;
   
    


    public void Start()
    {
       
    }


    public void Answer()
    {
        if(isCorrect)
        {
            print("you got the right answer!!! :)");
            QM.Answered();
            QM.CorrectAnswer();
            correctAnswer.Play();
           
        }

        else
        {
            print("you failed it :(");
            QM.Answered();
            wrongAnswer.Play();
        }
    }
}
