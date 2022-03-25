using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public Text timeText;
    public Text youLost;
    
    void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            //youLost.gameObject.SetActive(true);
            Loose();
        }

        DisplayTime(timeValue);
        
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