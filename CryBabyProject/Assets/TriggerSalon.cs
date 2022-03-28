using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSalon : MonoBehaviour
{
    public Animator anim;
    public Collider colDoor;

    private void OnTriggerEnter(Collider other) // Détecte la collision avec un gameObject
    {
        if(other.CompareTag("Player")) // si le gameObject a le tag "Player"
        {
            anim.SetBool("goodObject", false); // Modifie la valeur la valeur de la variable "goodObject" à false  
            anim.SetBool("inSaloon", true); // Modifie la valeur la valeur de la variable "inSaloon" à true  
            colDoor.enabled = true;
        }
    }
}
