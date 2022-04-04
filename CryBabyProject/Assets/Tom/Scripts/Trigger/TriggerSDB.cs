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

    private void Update() // Fonction appel� a chaque frame lors de la partie
    {
        if (inSDB == true) // Si la variable "inSalon" est � vrai
        {
            timer.SartEventTimer();
            SDBText.ToiletteText();
        }
    }

    private void OnTriggerEnter(Collider other) // D�tecte la collision avec un gameObject
    {
        if (other.CompareTag("Player")) // si le gameObject a le tag "Player"
        {
            anim.SetBool("OuvSDB", false); // Modifie la valeur la valeur de la variable "goodObject" � false  
            anim.SetBool("inSDB", true); // Modifie la valeur la valeur de la variable "inSaloon" � true  
            colDoor.isTrigger = false; // D�sactive le Trigger du collider de la porte, ca �vite de passer au travers
            inSDB = true; // Passe la valeur de la variable "inSalon" � true
        }
    }

    public void StopTimer()
    {
        inSDB = false;
        timer.StopEventTimer();
    }

    void Loose()
    {
        SceneManager.LoadScene("Loose"); // Ouvre la sc�ne "Loose"
    }

}
