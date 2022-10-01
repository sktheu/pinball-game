using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Text
    public Text pin;
    public Text ball;
    public Text colors;
    public Text input;

    private float curTime = 0, maxTime = 1f;

    private Color boyColor;
    private Color blackColor;
    private Color chillColor;


    // Start is called before the first frame update
    void Start()
    {
        boyColor = pin.color;
        blackColor = ball.color;
        chillColor = colors.color;
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= maxTime)
        {
            curTime = 0;
            changeTextColor(pin);
            changeTextColor(ball);
            changeTextColor(colors);
            changeTextColor(input);
        }
        
    }


    void changeTextColor(Text text)
    {
        if (text.color == boyColor)
        {
            text.color = blackColor;
        }
        else if (text.color == blackColor)
        {
            text.color = chillColor;
        }
        else if (text.color == chillColor)
        {
            text.color = boyColor;
        }
    }



    public void ChangeToBoyScene()
    {
        SceneManager.LoadScene("Pinball_Boy");
    }


    public void ChangeToBlackScene()
    {
        SceneManager.LoadScene("Pinball_Black");
    }

    public void ChangeToChillScene()
    {
        SceneManager.LoadScene("Pinball_Chill");
    }
}
