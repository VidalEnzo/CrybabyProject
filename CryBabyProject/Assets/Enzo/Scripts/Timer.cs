using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Slider slider, eventSlider;

    [SerializeField]
    float maxTime = 180, eventMaxValue = 20;
    float timeValue, eventTimeValue;


    private void Start()
    {
        SetMaxTime();
        SetEventMaxTime();
        eventSlider.enabled = false;
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
            Loose();
        }

    }

    void SetEventMaxTime()
    {
        eventTimeValue = 0;
        slider.value = eventTimeValue;
    }

    public void SartEventTimer()
    {
        eventSlider.enabled = true;
        if (eventTimeValue <= eventMaxValue)
        {
            eventTimeValue += Time.deltaTime;
            eventSlider.value = eventTimeValue;
        }
        else
        {
            eventTimeValue = eventMaxValue;
            Loose();
        }
    }

    void SetMaxTime()
    {
        timeValue = 0; 
        slider.value = timeValue;
    }   

    public void StopEventTimer()
    {
        eventSlider.enabled = false;
        eventTimeValue = 0;
    }

    void Loose()
    {
        SceneManager.LoadScene("Loose");
    }
}
