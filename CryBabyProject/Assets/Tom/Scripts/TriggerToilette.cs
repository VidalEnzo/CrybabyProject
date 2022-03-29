using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerToilette : MonoBehaviour
{
    public Text winUI;

    private void Start()
    {
        winUI.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Win();
        }
    }

    void Win()
    {
        winUI.enabled = true;

        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Gagné");
            //SceneManager.LoadScene("Win");
        }
    }
}
