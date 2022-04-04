using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerGarage : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    [SerializeField]
     Collider colDoor;

    [SerializeField]
    TextPopoUP garageText;

    [SerializeField]
    Timer timer;

    bool inGarage = false;


    private void Start() // Fonction appelé une fois au début de la partie
    {

        //SetMaxTime();
    }

    private void Update() // Fonction appelé a chaque frame lors de la partie
    {
        if(inGarage == true) // Si la variable "inSalon" est à vrai
        {
            timer.SartEventTimer();
            garageText.GarageText();
        } 
    }

    private void OnTriggerEnter(Collider other) // Détecte la collision avec un gameObject
    {
        if(other.CompareTag("Player")) // si le gameObject a le tag "Player"
        {
            anim.SetBool("Scie", false); // Modifie la valeur la valeur de la variable "goodObject" à false  
            anim.SetBool("inGarage", true); // Modifie la valeur la valeur de la variable "inSaloon" à true  
            colDoor.enabled = true; // Réactive le collider de la porte 
            inGarage = true; // Passe la valeur de la variable "inSalon" à true
        }
    }

    public void StopTimer()
    {
        inGarage = false;
        timer.StopEventTimer();
    }

    void Loose()
    {
        SceneManager.LoadScene("Loose"); // Ouvre la scène "Loose"
    }
}
