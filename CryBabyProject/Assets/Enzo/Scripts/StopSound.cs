using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSound : MonoBehaviour
{
    AudioSource tvSound;

    bool play;
    bool toggleChange;

    private void Start()
    {
        tvSound = GetComponent<AudioSource>();
        play = true;
    }

    private void Update()
    {
        if (play == true && toggleChange == true)
        {
            tvSound.Play();
            toggleChange = false;
        }

        if (play == false && toggleChange == true)
        {
            tvSound.Stop();
            toggleChange = false;
        }

    }

    void OnGUI()
    {
        //Switch this toggle to activate and deactivate the parent GameObject
        play = GUI.Toggle(new Rect(10, 10, 100, 30), play, "Play Music");

        //Detect if there is a change with the toggle
        if (GUI.changed)
        {
            //Change to true to show that there was just a change in the toggle state
            toggleChange = true;
        }
    }
}
