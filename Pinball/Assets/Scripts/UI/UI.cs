using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text score;
    public Text title;
    public Text time;

    private bool animTitle = true;
    private int animTitleFrames = 0, animTitleMaxFrames = 120;

    private float seconds = 0;
    private int minutes = 0;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Pontos: " + GameObject.FindGameObjectWithTag("Ball").GetComponent<BallMove>().score;

        animateTitle();

        setTime();
    }


    void animateTitle()
    {
        animTitleFrames++;
        if (animTitleFrames >= animTitleMaxFrames)
        {
            animTitleFrames = 0;
            if (animTitle)
            {
                animTitle = false;
            }
            else
            {
                animTitle = true;
            }
        }

        if (animTitle)
        {
            title.enabled = true;
        }
        else
        {
            title.enabled = false;
        }
    }

    void setTime()
    {
        string text = "Tempo: ";


        seconds += Time.deltaTime;
        if (seconds >= 60f)
        {
            seconds = 0;
            minutes++;
        }

        if (minutes < 10)
        {
            text += "0" + minutes + ":";
        }
        else
        {
            text += minutes + ":";
        }

        if (seconds < 10)
        {
            text += "0" + (int)(seconds);
        }
        else
        {
            text += (int)(seconds);
        }

        time.text = text;
    }
}
