using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSDB : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other) // D�tecte la collision avec un gameObject
    {
        if (other.CompareTag("Player")) // si le gameObject a le tag "Player"
        {
            anim.SetBool("Seaujet�", false); // Modifie la valeur la valeur de la variable "goodObject" � false  
            anim.SetBool("inToilette", true); // Modifie la valeur la valeur de la variable "inSaloon" � true  
        }
    }

}
