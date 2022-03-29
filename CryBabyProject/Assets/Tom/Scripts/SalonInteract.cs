using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalonInteract : MonoBehaviour
{
    public InteractObject myTool;

    private void OnTriggerEnter(Collider other) // Détecte la collision avec un gameObject
    {
        if (other.CompareTag("WrongObject")) // si le gameObject a le tag "Player"
        {
            Debug.Log("player");
            SceneManager.LoadScene("Loose"); // Charge la scène "Loose"
        }
        else // Si un autre objet entre en collision 
        {
            myTool.CheckSalonObject(other.gameObject); // Appelle et applique les instructions du script "CheckSalonObjet()"
        }
    }
}
