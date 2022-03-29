using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerSalon : MonoBehaviour
{
    public Animator anim;
    public Collider colDoor;   

    public Text timeText;
    public Slider slider;
    public float maxTime = 20;

    float timeValue;
    bool inSalon = false;


    private void Start() // Fonction appel� une fois au d�but de la partie
    {
        timeText.enabled = false; //D�sactive le texte du Canvas
        slider.enabled = false;

        SetMaxTime();
    }

    private void Update() // Fonction appel� a chaque frame lors de la partie
    {
        if(inSalon == true) // Si la variable "inSalon" est � vrai
        {
            StartEventTimer(); // Appelle la fonction selon la condition 
        }
    }

    private void OnTriggerEnter(Collider other) // D�tecte la collision avec un gameObject
    {
        if(other.CompareTag("Player")) // si le gameObject a le tag "Player"
        {
            anim.SetBool("goodObject", false); // Modifie la valeur la valeur de la variable "goodObject" � false  
            anim.SetBool("inSaloon", true); // Modifie la valeur la valeur de la variable "inSaloon" � true  
            colDoor.enabled = true; // R�active le collider de la porte 
            inSalon = true; // Passe la valeur de la variable "inSalon" � true
        }
    }

    void SetMaxTime()
    {
        timeValue = 0;
        slider.value = timeValue;
    }

    void StartEventTimer()
    {
        slider.enabled = false;

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

        DisplayTime(timeValue); // Appelle la fonction 
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0) // si la varaible est strictement inf�rieur � 0
        {
            timeToDisplay = 0; // Set la valeur de la variable � 0
        }


        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Affiche la variable sous le format minutes + secondes
    }

    public void StopTimer()
    {
        inSalon = false;
        timeValue = 1;
        timeText.enabled = false;
    }

    void Loose()
    {
        SceneManager.LoadScene("Loose"); // Ouvre la sc�ne "Loose"
    }
}
