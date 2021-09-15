using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;
    public List<Contents> contents;
    public GameObject[] options;
    public int question;
    public Text questionNo;
    public Text scoreCount;
    public int score;
    public GameObject endScene;
    public AudioSource music;
    public GameObject s1;
    public GameObject s1Background;
    public GameObject s2;
    public GameObject s2Background;
    public GameObject s3;
    public GameObject s3Background;
    public GameObject nextLevel;
    public AudioSource winSound;
    public AudioSource loseSound;
    public GameObject ad;
    public Text questionCount;
    public float timeRemaining;
    public bool timer = false;
    public Text timeText;



    public Text levelFinish;
    
    public Text timeUp;




    private void Start()
    {
        instance = this;
        timer = true;
        generateQuestion();
        music.Play();
    }
    

    void Update()
    {
        if(timer)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            else
            {
                
                Debug.Log("Time has run out!");
                endScene.SetActive(true);
                timeUp.gameObject.SetActive(true);
                ad.gameObject.SetActive(true);
                music.Stop();
                StartCoroutine(Win());
                timeRemaining = 0;
                timer = false;
            }
        }
        
    }


    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }



    void generateQuestion()
    {
        if (contents.Count > 0)
        {
            question = Random.Range(0, contents.Count);

           // questionCount = question.ToString();
            questionNo.text = contents[question].Question;
            SetAnswer();

        }


        else 
        {
            print("you cleared this level........... hurray!!!!!! :)");
            endScene.SetActive(true);
            levelFinish.gameObject.SetActive(true);
            music.Stop();
           
            StartCoroutine(Win());
        }
    }

    



    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerManager>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = contents[question].Answer[i];


            if (contents[question].rightAnswer == i + 1)
            {
                options[i].GetComponent<AnswerManager>().isCorrect = true;
                

            }
        }


    }

    public void CorrectAnswer()
    {
       
        score += 1;
        scoreCount.text = score.ToString();
        
    }

    public void Answered()
    {
        contents.RemoveAt(question);
        generateQuestion();
    }

    IEnumerator Win()

    {
        timer = false;

        if (score >= 0)
        {
            s1.SetActive(false);
            nextLevel.SetActive(false);
            loseSound.Play();
        }
       
        if (score == 3)
        {
            s1.SetActive(true);
            s2.SetActive(true);
            nextLevel.SetActive(false);
            loseSound.Play();
        }


        if (score == 4)
        {
            s1.SetActive(true);
            s2.SetActive(true);
            s3.SetActive(true);
            nextLevel.SetActive(true);
            winSound.Play();

        }
        else
        {


            yield return null;
        }
    }

   
}
