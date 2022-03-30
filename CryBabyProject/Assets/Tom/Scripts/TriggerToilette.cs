using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerToilette : MonoBehaviour
{
    public Text winUI;
    public float maxTime = 1;

    bool inToilette = false;
    float timeValue;

    private void Start()
    {
        winUI.enabled = false;
    }

    private void Update()
    {
        if(inToilette == true)
        {
            TakeAShit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Win();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        winUI.enabled = false;
        inToilette = false;
    }

    void Win()
    {
        winUI.enabled = true;
        inToilette = true;
        Debug.Log(inToilette);
    }

    void TakeAShit()
    {
        if (timeValue <= maxTime)
        {
            Debug.Log("timer lance");
            timeValue += Time.deltaTime;
        }
        else
        {
             timeValue = maxTime;
             Debug.Log("Gagné");
             SceneManager.LoadScene("Win");
        }
    }
}
