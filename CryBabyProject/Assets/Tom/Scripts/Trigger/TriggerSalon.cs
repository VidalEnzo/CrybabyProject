using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerSalon : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    [SerializeField]
    Collider colDoor;

    [SerializeField]
    TextPopoUP salonText;

    [SerializeField]
    Timer timer;

    bool inSalon = false;

    private void Update() // Fonction appel� a chaque frame lors de la partie
    {
        if (inSalon == true) // Si la variable "inSalon" est � vrai
        {
            timer.SartEventTimer();
            salonText.SalonText();
        }
    }

    private void OnTriggerEnter(Collider other) // D�tecte la collision avec un gameObject
    {
        if (other.CompareTag("Player")) // si le gameObject a le tag "Player"
        {
            anim.SetBool("OuvreSalon", false); // Modifie la valeur la valeur de la variable "goodObject" � false  
            anim.SetBool("FermeSalon", true); // Modifie la valeur la valeur de la variable "inSaloon" � true  
            colDoor.isTrigger = false; // D�sactive le Trigger du collider de la porte, ca �vite de passer au travers
            inSalon = true; // Passe la valeur de la variable "inSalon" � true
        }
    }

    public void StopTimer()
    {
        inSalon = false;
        timer.StopEventTimer();
    }

    void Loose()
    {
        SceneManager.LoadScene("Loose"); // Ouvre la sc�ne "Loose"
    }
}
