using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractObject : MonoBehaviour
{
    [SerializeField] ObjetInteractif[] allTools;

    public Animator anim;
    public Collider colDoor;

    public void CheckObject(GameObject myObj) // Fonction pour v�rifier quel objet entre en collision
    {
        for (int i = 0; i < allTools.Length;  i++) // Parcours le tableau initialiser plus bas 
        {
            if (myObj != null) // V�rifie s'il y a bien un objet qui se trouve dans le collider 
            {
                if (myObj.transform.name == allTools[i].tools.name) // V�rifie si le nom de l'objet entr� en collsion correspond � celui d'un objet pr�sent dans le tableau 
                {
                    if (myObj.CompareTag("WrongObject")) // Si l'objet entr� en collsion porte le tag "WrongObject"
                    {
                        // Appelle et application du son 
                        SceneManager.LoadScene("Loose");// Chargement de la sc�ne "Loose"
                    }
                    else if (myObj.CompareTag("GoodObject")) // Si l'objet entr� en collsion porte le tag "GoodObject"
                    {
                        anim.SetBool("goodObject", true); // Modifie la valeur la valeur de la variable "goodObject" � true
                        colDoor.enabled = !colDoor.enabled;
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
