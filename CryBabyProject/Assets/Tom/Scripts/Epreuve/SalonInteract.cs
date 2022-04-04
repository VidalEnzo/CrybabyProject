using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalonInteract : MonoBehaviour
{
    public InteractObject myTool;

    private void OnTriggerEnter(Collider other) // Détecte la collision avec un gameObject
    {
        if (other.CompareTag("Untagged")) // si le gameObject a le tag "Player"
        {
            myTool.CheckSalonObject(other.gameObject); // Appelle et applique les instructions du script "CheckSalonObjet()"
        }
    }
}
