using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour
{
    void Awake()
    {
        highscoreScreen.text = "Highscore : " + PlayerPrefs.GetFloat("highscore").ToString("0");
    }

    public Text highscoreScreen;

    
}
