using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timeText;
    public Slider slider;
    public float maxTime = 10;

    float timeValue;
    

    private void Start()
    {
        SetMaxTime();
    }

    void Update()
    {
        if (timeValue <= maxTime)
        {
            timeValue += Time.deltaTime;
            slider.value = timeValue; 
        }
        else
        {
            timeValue = maxTime;
            Debug.Log(timeValue);
            Loose();
        }

        DisplayTime(timeValue);
        
    }

    void SetMaxTime()
    {
        timeValue = 0; 
        slider.value = timeValue;
    }    

    void DisplayTime(float timeToDisplay)
    {
       

        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
       

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float miliseconds = timeToDisplay % 1 * 1000;

        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, miliseconds);
    }

    void Loose()
    {
        SceneManager.LoadScene("Loose");
    }
}
