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

    private void Update() // Fonction appel� a chaque frame lors de la partie
    {
        if (inCuisne == true) // Si la variable "inSalon" est � vrai
        {
            timer.SartEventTimer();
            cuisneText.CuisneText();
        }
    }

    private void OnTriggerEnter(Collider other) // D�tecte la collision avec un gameObject
    {
        if (other.CompareTag("Player")) // si le gameObject a le tag "Player"
        {
            anim.SetBool("Seaujet�", false); // Modifie la valeur la valeur de la variable "goodObject" � false  
            anim.SetBool("inCuisine", true); // Modifie la valeur la valeur de la variable "inSaloon" � true  
            colDoor.isTrigger = false; // D�sactive le Trigger du collider de la porte, ca �vite de passer au travers
            inCuisne = true; // Passe la valeur de la variable "inSalon" � true
        }
    }

    public void StopTimer()
    {
        inCuisne = false;
        timer.StopEventTimer();
    }

    void Loose()
    {
        SceneManager.LoadScene("Loose"); // Ouvre la sc�ne "Loose"
    }
}
