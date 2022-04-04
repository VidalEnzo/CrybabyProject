using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarageInteract : MonoBehaviour
{
    public InteractObject myTool;

    private void OnTriggerEnter(Collider other) // D�tecte la collision avec un gameObject
    {
        if (other.CompareTag("Player")) // si le gameObject a le tag "Player"
        {
            SceneManager.LoadScene("Loose"); // Charge la sc�ne "Loose"
        }
        else // Si un autre objet entre en collision 
        {
            myTool.CheckGarageObject(other.gameObject); // Appelle et applique les instructions du script "CheckGarageObjet()"
        }
    }
}
