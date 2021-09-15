using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{


    public GameObject hint;
    public static QuizManager instance;




    public void Hint()
    {
        hint.SetActive(true);
        QuizManager.instance.timer = false;
        QuizManager.instance.music.Stop();
    }


    public void Escape()
    {
        hint.SetActive(false);
        QuizManager.instance.timer = true;
        QuizManager.instance.music.Play();
    }


    public void MenuBack()
    {
        SceneManager.LoadScene(0);
    }
}
