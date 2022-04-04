using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerToilette : MonoBehaviour
{
    [SerializeField]
    Text winUI;

    [SerializeField]
    Image back;

    [SerializeField]
    float maxTime = 1;

    bool inToilette = false;
    float timeValue;

    private void Start()
    {
        winUI.enabled = false;
        back.enabled = false;
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
        back.enabled = false;
        inToilette = false;
    }

    void Win()
    {
        winUI.enabled = true;
        back.enabled = true;
        inToilette = true;
    }

    void TakeAShit()
    {
        if (timeValue <= maxTime)
        {
            timeValue += Time.deltaTime;
        }
        else
        {
             timeValue = maxTime;
             SceneManager.LoadScene("Win");
        }
    }
}
