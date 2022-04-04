using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCuisine : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    [SerializeField]
    Collider colDoor;

    [SerializeField]
    TextPopoUP cuisneText;

    [SerializeField]
    Timer timer;

    bool inCuisne = false;

    private void Update() // Fonction appelé a chaque frame lors de la partie
    {
        if (inCuisne == true) // Si la variable "inSalon" est à vrai
        {
            timer.SartEventTimer();
            cuisneText.CuisneText();
        }
    }

    private void OnTriggerEnter(Collider other) // Détecte la collision avec un gameObject
    {
        if (other.CompareTag("Player")) // si le gameObject a le tag "Player"
        {
            anim.SetBool("Seaujeté", false); // Modifie la valeur la valeur de la variable "goodObject" à false  
            anim.SetBool("inCuisine", true); // Modifie la valeur la valeur de la variable "inSaloon" à true  
            colDoor.isTrigger = false; // Désactive le Trigger du collider de la porte, ca évite de passer au travers
            inCuisne = true; // Passe la valeur de la variable "inSalon" à true
        }
    }

    public void StopTimer()
    {
        inCuisne = false;
        timer.StopEventTimer();
    }

    void Loose()
    {
        SceneManager.LoadScene("Loose"); // Ouvre la scène "Loose"
    }
}
