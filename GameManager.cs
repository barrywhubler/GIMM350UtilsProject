using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public int lastScore = 0;
    private float time = 30;
    public Text sText;
    public Text tText;
    //public Text GOText;
    public Canvas GOCanvas;
    private bool blinkOn;
    //private bool blinkOff;
    public int blinkCounter;
    public static bool gameOn = true;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lastScore = 0;
        time = 30;
        gameOn = true;
}

    public void GameOver()
    {
        GOCanvas.enabled = true;
        gameOn = false;
    }




    public void Timer()
    {
        if (time <= 0)
        {
            tText.text = "" + 0;
            GameOver();
        }
        else
        {
            time -= Time.deltaTime;
            tText.text = "" + time;
            if (time < 10)
            {
                
                Blinker();
            }
        }
    }
    public void Blinker()
    {
        blinkCounter++;
        if (blinkOn && blinkCounter > 40)
        {
            blinkCounter = 0;
            //tText.CrossFadeAlpha = 0;//color = 0;
            //Color tColor = tText.color;
            //tColor.a = 0.0f;
            tText.CrossFadeAlpha(0f, 0f, false);
            blinkOn = false;
        }
        else if (!blinkOn && blinkCounter >20){
            blinkCounter = 0;
            tText.color = Color.red;
            //Color ttColor = tText.color;
            tText.CrossFadeAlpha(1f, 0f, false);
            blinkOn = true;
            //ttColor.a = 1.0f;
        }
    }

    public void ScoreUp()
    {
        score++;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        if (lastScore < score)
        {
            lastScore = score;
            sText.text = "" + score;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        //print();
    }
}
