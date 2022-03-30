using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractObject : MonoBehaviour
{
    [SerializeField] ObjetInteractif[] chambreTools;
    [SerializeField] ObjetInteractif[] salonTools;
    [SerializeField] ObjetInteractif[] toiletsTools;
    [SerializeField] Particule[] allParticles;

    PickUP drop;

    public Animator animChambre;
    public Animator animSalon;

    public Collider colChambreDoor;
    public Collider colSalonDoor;
    public Collider fuite;


    public void CheckChambreObject(GameObject myObj) // Fonction pour vérifier quel objet entre en collision
    {
        for (int i = 0; i < chambreTools.Length;  i++) // Parcours le tableau initialiser plus bas 
        {
            if (myObj != null) // Vérifie s'il y a bien un objet qui se trouve dans le collider 
            {
                if (myObj.transform.name == chambreTools[i].tools.name) // Vérifie si le nom de l'objet entré en collsion correspond à celui d'un objet présent dans le tableau 
                {
                    if (myObj.CompareTag("WrongObject")) // Si l'objet entré en collsion porte le tag "WrongObject"
                    {
                        // Appelle et application du son 
                        SceneManager.LoadScene("Loose");// Chargement de la scène "Loose"
                    }
                    else if (myObj.CompareTag("scie")) // Si l'objet entré en collsion porte le tag "GoodObject"
                    {
                        
                        animChambre.SetBool("goodObject", true); // Modifie la valeur la valeur de la variable "goodObject" à true
                        colChambreDoor.enabled = !colChambreDoor.enabled;
                        drop.Drop();
                    }
                }
            }
        }
    }

    public void CheckSalonObject(GameObject myObj) // Fonction pour vérifier quel objet entre en collision
    {
        for (int i = 0; i < salonTools.Length; i++) // Parcours le tableau initialiser plus bas 
        {
            if (myObj != null) // Vérifie s'il y a bien un objet qui se trouve dans le collider 
            {
                if (myObj.transform.name == salonTools[i].tools.name) // Vérifie si le nom de l'objet entré en collsion correspond à celui d'un objet présent dans le tableau
                {
                    if (myObj.CompareTag("WrongObject")) // Si l'objet entré en collsion porte le tag "WrongObject"
                    {
                        // Appelle et application du son 
                        SceneManager.LoadScene("Loose");// Chargement de la scène "Loose"
                    }
                    else if (myObj.CompareTag("Seau")) // Si l'objet entré en collsion porte le tag "GoodObject"
                    {
                        
                        colSalonDoor.enabled = !colSalonDoor.enabled;
                        animSalon.SetBool("Seaujeté", true); // Modifie la valeur la valeur de la variable "Seaujeté" de l'animator à true
                        drop.Drop();
                    }
                }
            }
        }
    }

    public void CheckToiletteObject(GameObject myObj) // Fonction pour vérifier quel objet entre en collision
    {
        for (int i = 0; i < toiletsTools.Length; i++) // Parcours le tableau initialiser plus bas 
        {
            if (myObj != null) // Vérifie s'il y a bien un objet qui se trouve dans le collider 
            {
                if (myObj.transform.name == toiletsTools[i].tools.name) // Vérifie si le nom de l'objet entré en collsion correspond à celui d'un objet présent dans le tableau
                {
                    if (myObj.CompareTag("WrongObject")) // Si l'objet entré en collsion porte le tag "WrongObject"
                    {
                        // Appelle et application du son 
                        SceneManager.LoadScene("Loose");// Chargement de la scène "Loose"
                    }
                    else if (myObj.CompareTag("Marteau")) // Si l'objet entré en collsion porte le tag "GoodObject"
                    {
                        fuite.enabled = !fuite.enabled;
                        allParticles.particleEmitter.emit = false;
                        drop.Drop();
                    }
                }
            }
        }
    }

    [System.Serializable]
    class ObjetInteractif
    {
        public GameObject tools;
    }

    [System.Serializable]
    class Particule
    {
        public GameObject particle;
    }
}
