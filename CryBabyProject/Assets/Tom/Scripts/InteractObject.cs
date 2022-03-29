using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractObject : MonoBehaviour
{
    [SerializeField] ObjetInteractif[] chambreTools;
    [SerializeField] ObjetInteractif[] salonTools;
    [SerializeField] ObjetInteractif[] toiletsTools;

    public Animator animChambre;
    public Animator animSalon;

    public Collider colChambreDoor;


    public void CheckChambreObject(GameObject myObj) // Fonction pour v�rifier quel objet entre en collision
    {
        for (int i = 0; i < chambreTools.Length;  i++) // Parcours le tableau initialiser plus bas 
        {
            if (myObj != null) // V�rifie s'il y a bien un objet qui se trouve dans le collider 
            {
                if (myObj.transform.name == chambreTools[i].tools.name) // V�rifie si le nom de l'objet entr� en collsion correspond � celui d'un objet pr�sent dans le tableau 
                {
                    if (myObj.CompareTag("WrongObject")) // Si l'objet entr� en collsion porte le tag "WrongObject"
                    {
                        // Appelle et application du son 
                        SceneManager.LoadScene("Loose");// Chargement de la sc�ne "Loose"
                    }
                    else if (myObj.CompareTag("scie")) // Si l'objet entr� en collsion porte le tag "GoodObject"
                    {
                        animChambre.SetBool("goodObject", true); // Modifie la valeur la valeur de la variable "goodObject" � true
                        colChambreDoor.enabled = !colChambreDoor.enabled;
                    }
                }
            }
        }
    }

    public void CheckSalonObject(GameObject myObj) // Fonction pour v�rifier quel objet entre en collision
    {
        for (int i = 0; i < salonTools.Length; i++) // Parcours le tableau initialiser plus bas 
        {
            if (myObj != null) // V�rifie s'il y a bien un objet qui se trouve dans le collider 
            {
                if (myObj.transform.name == salonTools[i].tools.name) // V�rifie si le nom de l'objet entr� en collsion correspond � celui d'un objet pr�sent dans le tableau
                {
                    if (myObj.CompareTag("WrongObject")) // Si l'objet entr� en collsion porte le tag "WrongObject"
                    {
                        // Appelle et application du son 
                        SceneManager.LoadScene("Loose");// Chargement de la sc�ne "Loose"
                    }
                    else if (myObj.CompareTag("Seau")) // Si l'objet entr� en collsion porte le tag "GoodObject"
                    {
                        animSalon.SetBool("Seaujet�", true); // Modifie la valeur la valeur de la variable "Seaujet�" de l'animator � true
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
}
