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


    private void Start() // Fonction appelé une fois au début de la partie
    {
        timeText.enabled = false; //Désactive le texte du Canvas
        slider.enabled = false;

        SetMaxTime();
    }

    private void Update() // Fonction appelé a chaque frame lors de la partie
    {
        if(inSalon == true) // Si la variable "inSalon" est à vrai
        {
            StartEventTimer(); // Appelle la fonction selon la condition 
        }
    }

    private void OnTriggerEnter(Collider other) // Détecte la collision avec un gameObject
    {
        if(other.CompareTag("Player")) // si le gameObject a le tag "Player"
        {
            anim.SetBool("goodObject", false); // Modifie la valeur la valeur de la variable "goodObject" à false  
            anim.SetBool("inSaloon", true); // Modifie la valeur la valeur de la variable "inSaloon" à true  
            colDoor.enabled = true; // Réactive le collider de la porte 
            inSalon = true; // Passe la valeur de la variable "inSalon" à true
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
        if (timeToDisplay < 0) // si la varaible est strictement inférieur à 0
        {
            timeToDisplay = 0; // Set la valeur de la variable à 0
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
        SceneManager.LoadScene("Loose"); // Ouvre la scène "Loose"
    }
}
