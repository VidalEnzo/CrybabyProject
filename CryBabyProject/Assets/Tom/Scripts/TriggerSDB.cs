using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSDB : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other) // Détecte la collision avec un gameObject
    {
        if (other.CompareTag("Player")) // si le gameObject a le tag "Player"
        {
            anim.SetBool("Seaujeté", false); // Modifie la valeur la valeur de la variable "goodObject" à false  
            anim.SetBool("inToilette", true); // Modifie la valeur la valeur de la variable "inSaloon" à true  
        }
    }

}
