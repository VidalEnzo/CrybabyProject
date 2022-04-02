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

    public Animator animChambre;
    public Animator animSalon;

    public Collider colChambreDoor;
    public Collider colSalonDoor;
    public Collider fuite;
    public AudioSource tvSound;

    private void Start()
    {
        tvSound = GetComponent<AudioSource>();
        tvSound.volume = 0.5f;
    }

    public IEnumerator TimeDelay()
    {
        FindObjectOfType<SoundManager>().Play("KeyMoan");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Loose");// Chargement de la scène "Loose"
    }

    public IEnumerator TimeDelay2()
    {
        tvSound.volume = 2f;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Loose");
    }

    public IEnumerator TimeDelay3()
    {
        tvSound.Stop();
        FindObjectOfType<SoundManager>().Play("MetalHit");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Loose");
    }

    public IEnumerator TimeDelay4()
    {
        FindObjectOfType<SoundManager>().Play("SpringComic");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Loose");
    }

    public void CheckChambreObject(GameObject myObj) // Fonction pour vérifier quel objet entre en collision
    {
        for (int i = 0; i < chambreTools.Length;  i++) // Parcours le tableau initialiser plus bas 
        {
            if (myObj != null) // Vérifie s'il y a bien un objet qui se trouve dans le collider 
            {
                if (myObj.transform.name == chambreTools[i].tools.name) // Vérifie si le nom de l'objet entré en collsion correspond à celui d'un objet présent dans le tableau 
                {
                    if (myObj.CompareTag("Clef")) // Si l'objet entré en collsion porte le tag "WrongObject"
                    {
                        StartCoroutine(TimeDelay()); 
                    }
                    else if (myObj.CompareTag("scie")) // Si l'objet entré en collsion porte le tag "GoodObject"
                    {
                        FindObjectOfType<SoundManager>().Play("SawCutting");
                        animChambre.SetBool("goodObject", true); // Modifie la valeur la valeur de la variable "goodObject" à true
                        colChambreDoor.enabled = !colChambreDoor.enabled;
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
                    if (myObj.CompareTag("Télécommande")) // Si l'objet entré en collsion porte le tag "WrongObject"
                    {
                        StartCoroutine(TimeDelay2());
                    }
                    else if (myObj.CompareTag("Xylo"))
                    {
                        StartCoroutine(TimeDelay3());
                    }
                    else if (myObj.CompareTag("Seau")) // Si l'objet entré en collsion porte le tag "GoodObject"
                    {
                        FindObjectOfType<SoundManager>().Play("WaterDrop");
                        tvSound.Stop();
                        animSalon.SetBool("Seaujeté", true); // Modifie la valeur la valeur de la variable "Seaujeté" de l'animator à true
                        colSalonDoor.enabled = !colSalonDoor.enabled;
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
                    if (myObj.CompareTag("Echelle")) // Si l'objet entré en collsion porte le tag "WrongObject"
                    {
                        StartCoroutine(TimeDelay4());
                    }
                    else if (myObj.CompareTag("Marteau")) // Si l'objet entré en collsion porte le tag "GoodObject"
                    {
                        FindObjectOfType<SoundManager>().Play("Hammer");
                        fuite.enabled = !fuite.enabled;
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
