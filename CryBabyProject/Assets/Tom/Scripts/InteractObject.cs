using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InteractObject : MonoBehaviour
{
    [SerializeField]
    Animator animChambre, animSalon, animCuisine, animSDB, animToilette;

    [SerializeField]
    Collider colChambreDoor, colSalonDoor, fuite, colTV, colCuisineDoor, colSDBDoor, colToiletteDoor, colGaziniere, colVoiture, triggerGarage, triggerSalon, triggerCuisne, triggerSDB;

    [SerializeField]
    TriggerGarage stopGarage;

    [SerializeField]
    TriggerSalon stopSalon;

    [SerializeField]
    TriggerCuisine stopCuisine;

    [SerializeField]
    TriggerSDB stopSDB;

    [SerializeField]
    ParticleSystem water1, water2, water3, water4, fire1, fire2, fire3, fire4;

    [SerializeField]
    AudioSource tvSound;
    AudioSource gaz;
    AudioSource voiture;

    private void Start()
    {
        tvSound = GetComponent<AudioSource>();
        tvSound.volume = 1f;
        gaz = GameObject.FindGameObjectWithTag("Gaziniere").GetComponent<AudioSource>();
        GetComponent<AudioSource>().clip = gaz.clip;
        voiture = GameObject.FindGameObjectWithTag("Voiture").GetComponent<AudioSource>();
        GetComponent<AudioSource>().clip = voiture.clip;
    }

    public IEnumerator Time()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Loose");
    }

    public IEnumerator Time2()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<SoundManager>().Play("Nice");
    }


    public void CheckChambreObject(GameObject myObj) // Fonction pour vérifier quel objet entre en collision
    {
        //for (int i = 0; i < chambreTools.Length;  i++) // Parcours le tableau initialiser plus bas 
        //{
        //    if (myObj != null) // Vérifie s'il y a bien un objet qui se trouve dans le collider 
        //    {
        //        if (myObj.transform.name == chambreTools[i].tools.name) // Vérifie si le nom de l'objet entré en collsion correspond à celui d'un objet présent dans le tableau 
        //        {
        //            if (myObj.CompareTag("WrongObject")) // Si l'objet entré en collsion porte le tag "WrongObject"
        //            {
        //                // Appelle et application du son 
        //                SceneManager.LoadScene("Loose");// Chargement de la scène "Loose"
        //            }
        //            else if (myObj.CompareTag("scie")) // Si l'objet entré en collsion porte le tag "GoodObject"
        //            {
        //                FindObjectOfType<SoundManager>().Play("SawCutting");
        //                animChambre.SetBool("goodObject", true); // Modifie la valeur la valeur de la variable "goodObject" à true
        //                colChambreDoor.enabled = !colChambreDoor.enabled;
        //            }
        //        }
        //    }
        //}

        TypeofObject myType = myObj.GetComponent<TypeofObject>();

        if(myType.typeOfObject == EnumObject.Scie)
        {
            FindObjectOfType<SoundManager>().Play("SawCutting");
            animChambre.SetBool("Scie", true); // Modifie la valeur la valeur de la variable "goodObject" à true
            colChambreDoor.enabled = !colChambreDoor.enabled;
            //colChambreDoor.isTrigger = false;
        }
        else if(myType.typeOfObject == EnumObject.Clef)
        {
            FindObjectOfType<SoundManager>().Play("KeyMoan");
            StartCoroutine(Time());
        }
    }

    public void CheckSalonObject(GameObject myObj) // Fonction pour vérifier quel objet entre en collision
    {
        TypeofObject myType = myObj.GetComponent<TypeofObject>();

        if (myType.typeOfObject == EnumObject.SeauDeau)
        {
            FindObjectOfType<SoundManager>().Play("WaterDrop");
            tvSound.Stop();
            animCuisine.SetBool("Seaujeté", true); // Modifie la valeur la valeur de la variable "Seaujeté" de l'animator à true
            stopSalon.StopTimer();
            colTV.enabled = !colTV.enabled;
            colCuisineDoor.isTrigger = true;
            triggerSalon.enabled = !triggerSalon.enabled;
        }
        else if (myType.typeOfObject == EnumObject.Telecommande)
        {
            tvSound.volume = 10f;
            StartCoroutine(Time());
        }
        else if (myType.typeOfObject == EnumObject.Xylophone)
        {
            FindObjectOfType<SoundManager>().Play("3310");
            StartCoroutine(Time());
        }
    }

    public void CheckToiletteObject(GameObject myObj) // Fonction pour vérifier quel objet entre en collision
    {
        TypeofObject myType = myObj.GetComponent<TypeofObject>();

        if (myType.typeOfObject == EnumObject.Marteau)
        {
            FindObjectOfType<SoundManager>().Play("LevelEnding");
            WaterStop();
            fuite.enabled = !fuite.enabled;
            stopSDB.StopTimer();
            colToiletteDoor.isTrigger = true;
            triggerSDB.enabled = !triggerSDB.enabled;
            animToilette.SetBool("OuvToilette", true);
        }
        else if (myType.typeOfObject == EnumObject.Echelle)
        {
            FindObjectOfType<SoundManager>().Play("SpringComic");
            StartCoroutine(Time());
        }
    }

    public void CheckGarageObject(GameObject myObj)
    {
        TypeofObject myType = myObj.GetComponent<TypeofObject>();

        if (myType.typeOfObject == EnumObject.Savon)
        {
            FindObjectOfType<SoundManager>().Play("Squeak");
            animSalon.SetBool("OuvreSalon", true);
            voiture.Stop();
            stopGarage.StopTimer();
            colSalonDoor.isTrigger = true;
            colVoiture.enabled = !colVoiture.enabled;
            triggerGarage.enabled = !triggerGarage.enabled;
            StartCoroutine(Time2());
        }
    }

    public void CheckCuisineObject(GameObject myObj)
    {
        TypeofObject myType = myObj.GetComponent<TypeofObject>();

        if (myType.typeOfObject == EnumObject.Huile)
        {
            FindObjectOfType<SoundManager>().Play("Hammer");
            animSDB.SetBool("OuvSDB", true);
            gaz.Stop();
            stopCuisine.StopTimer();
            colSDBDoor.isTrigger = true;
            colGaziniere.enabled = !colGaziniere.enabled;
            triggerCuisne.enabled = !triggerCuisne.enabled;
            StartCoroutine(Time2());
            FireStop();
        }
        else if (myType.typeOfObject == EnumObject.Steack)
        {
            StartCoroutine(Time());
        }
    }

    void WaterStop()
    {
        water1.Stop();
        water2.Stop();
        water3.Stop();
        water4.Stop();
    }

    void FireStop()
    {
        fire1.Stop();
        fire2.Stop();
        fire3.Stop();
        fire4.Stop();
    }
}
