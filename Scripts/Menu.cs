using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioSource menuMusic;
    public AudioSource click;
    public GameObject rewardPanel;
    public GameObject storePanel;
    public GameObject back;
    public GameObject sound;
    public GameObject chest;
    public GameObject collectButton;
    public static QuizManager instance;

    public float timeRemaining;
    public bool timer = false;
    public Text timeText;
    public GameObject cheer;

    // Start is called before the first frame update
    void Start()
    {
        menuMusic.Play();
        
    }


    void Update()
    {
        if (timer)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            else
            {
                chest.SetActive(true);
                collectButton.SetActive(true);

                timeText.text = string.Format(" Ready to collect! ");
            }
        }

    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

       // float hour = Mathf.FloorToInt(timeRemaining / 3600);
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }




    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        click.Play();
    }


    public void Quit()
    {
        Application.Quit();
        click.Play();
    }


    public void DailyReward()
    {
        rewardPanel.SetActive(true);
        click.Play();
        cheer.SetActive(false);


    }

    public void Store()
    {
        storePanel.SetActive(true);
        click.Play();


    }

    public void Back()
    {
        rewardPanel.SetActive(false);
        storePanel.SetActive(false);
        click.Play();
    }


    public void Sound()
    {
        click.Play();
        menuMusic.Stop();
        QuizManager.instance.music.mute = !QuizManager.instance.music.mute;
        
    }

    public void Collect()
    {
        cheer.SetActive(true);
        timer = true;
        click.Play();
        chest.SetActive(false);
        collectButton.SetActive(false);
        
        timeRemaining = 86400;
    }






}
