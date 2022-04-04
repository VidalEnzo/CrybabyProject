using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSDB : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    [SerializeField]
    Collider colDoor;

    [SerializeField]
    TextPopoUP SDBText;

    [SerializeField]
    Timer timer;

    bool inSDB = false;

    private void Update() // Fonction appelé a chaque frame lors de la partie
    {
        if (inSDB == true) // Si la variable "inSalon" est à vrai
        {
            timer.SartEventTimer();
            SDBText.ToiletteText();
        }
    }

    private void OnTriggerEnter(Collider other) // Détecte la collision avec un gameObject
    {
        if (other.CompareTag("Player")) // si le gameObject a le tag "Player"
        {
            anim.SetBool("OuvSDB", false); // Modifie la valeur la valeur de la variable "goodObject" à false  
            anim.SetBool("inSDB", true); // Modifie la valeur la valeur de la variable "inSaloon" à true  
            colDoor.isTrigger = false; // Désactive le Trigger du collider de la porte, ca évite de passer au travers
            inSDB = true; // Passe la valeur de la variable "inSalon" à true
        }
    }

    public void StopTimer()
    {
        inSDB = false;
        timer.StopEventTimer();
    }

    void Loose()
    {
        SceneManager.LoadScene("Loose"); // Ouvre la scène "Loose"
    }

}
