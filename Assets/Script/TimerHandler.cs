using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerHandler : MonoBehaviour
{
    public float startTime=0;
    public string textTime;
    public float guiTime;
    public bool isRunning = false;
    public int minutes;
    public int seconds;
    public int fraction;
    public TextMeshProUGUI textField;
    void Start()
    {
       
    }

    public void timerstart()
    {

       
       /* if (minutes <= 0)
        {
            isRunning = true;
            textField.text = "LEAVE";
        }
        else
        {*/
            isRunning = true;
            startTime = 3600;
        // textField.text = textTime;

    }
    void Update()
    {
        
        if (isRunning == true)

        {
            
            guiTime = (startTime - Time.time);
            minutes = (int)guiTime / (60);
            seconds = (int)guiTime % (60);
            fraction = (int)(guiTime * 100) % 100;
            textTime = string.Format("{0:00}:{1:00}", minutes, seconds, fraction);
            if (minutes <= 0)
            {

                textField.text = "LEAVE";
            }
            else
            {
                textField.text = textTime;
            }
        }


    }
}

