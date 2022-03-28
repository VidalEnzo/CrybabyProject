using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUP : MonoBehaviour
{
    public float pickUpRange = 1;
    public float launchForce = 250;
    public Transform container;
    GameObject heldObj;
    public Text interactUI;

    private void Update()
    {
        if(heldObj == null) //Check si un objet est tenu ou pas
        {
            interactUI.enabled = false; //désactive le texte du Canvas

            RaycastHit raycast; // Initialisation d'un Raycast
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycast, pickUpRange)) // Sile Raycast touche un objet dans la portée de pickUpRange
            {
                //if(gameObject.layer == LayerMask.NameToLayer("Toilette"))
                //{

                //}

                interactUI.enabled = true; // Alors active le texte du Canvas
            }
        }
        
        
        if (Input.GetKeyDown(KeyCode.E)) // Si le joueur appuie sur le touche E
        {
            if(heldObj == null) // Et s'il n'y a pas d'objet tenu 
            {
                RaycastHit hit; // Initialisation d'un Raycast

                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange)) // Lance un Raycast dans la portée de pickUpRange
                {

                    
                    gameObject.layer = LayerMask.NameToLayer("Ignore Raycast"); // Ignore le GameObject avec le Layer "Ignore Layer"

                    Grab(hit.transform.gameObject); // Procède au code de la fonction Grab()
                    interactUI.enabled = false; // Désactive le texte du Canvas
                }

            }
            else
            {
                Drop(); // Si le joueur rappuie sur E, accède au code de la fonction Drop()
            } 
        }

        if(heldObj != null)
        {
            Debug.Log("ici");
            if (Input.GetKeyDown(KeyCode.F))
            {
                Throw();
            }
        }
    }

    void Grab(GameObject grabedObj)
    {
        Rigidbody rigObj = grabedObj.GetComponent<Rigidbody>(); // Initialisation et récupération du Rigidbody de l'objet attrapé
        Collider colObj = grabedObj.GetComponent<Collider>(); // Initialisation et récupération du Collider de l'objet attrapé

        colObj.isTrigger = true; // Dans le Collider, set l'option isTrigger à true
        grabedObj.transform.parent = container; //Déplace l'objet sélectionné en enfant du gameObject "container"
        rigObj.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ; // Force les poistions de l'objet sélectionné à être fixe 
        heldObj = grabedObj;
        heldObj.transform.localPosition = Vector3.zero; // Place l'objet sélectionné au centre du gameObject parent
        rigObj.useGravity = false; // Désactive la graivté du Rigidbody de l'objet sélectionné 
        rigObj.velocity = Vector3.zero; // Réinitialise la vélocité (force appliquée par le Rigidbody) de l'objet sélectionné
        rigObj.angularVelocity = Vector3.zero; // Réinitialise la vélocité angulaire (force de rotation appliquée par le Rigidbody) de l'objet sélectionné

        

        //rigObj.isKinematic = true;
    }

    public void Drop()
    {
        Rigidbody  heldRig = heldObj.GetComponent<Rigidbody>(); // Initialisation et récupération du Rigidbody de l'objet attrapé
        Collider colObj = heldObj.GetComponent<Collider>(); // Initialisation et récupération du Collider de l'objet attrapé

        colObj.isTrigger = false; // Dans le Collider, set l'option isTrigger à false
        heldRig.useGravity = true; // Résactive la graivté du Rigidbody de l'objet sélectionné 
        heldObj.transform.parent = null; // Détache l'objet tenu par le gameObject parent pour qu'il ne soit plus enfant 
        heldRig.constraints = RigidbodyConstraints.None; // Désactive les contraintes appliqués au Rigidbody (fixation des positions)

        heldObj = null; // Plus aucun gameObject n'est alors tenu 
        heldRig.velocity = Vector3.zero; // Réinitialise la vélocité (force appliquée par le Rigidbody) de l'objet sélectionné
        heldRig.angularVelocity = Vector3.zero; // Réinitialise la vélocité angulaire (force de rotation appliquée par le Rigidbody) de l'objet sélectionné

        //heldRig.isKinematic = false;

    }

    void Throw()
    { 
        Rigidbody rigidbodyObj = heldObj.GetComponent<Rigidbody>();
        Collider colObj = heldObj.GetComponent<Collider>(); // Initialisation et récupération du Collider de l'objet attrapé

        colObj.isTrigger = false; // Dans le Collider, set l'option isTrigger à false
        heldObj.GetComponent<Rigidbody>().AddForce(container.forward * launchForce); // Ajoute une force dans la direction de devant pour simuler le lancer d'un objet
        rigidbodyObj.useGravity = true; // Résactive la graivté du Rigidbody de l'objet sélectionné 
        heldObj.transform.parent = null; // Détache l'objet tenu par le gameObject parent pour qu'il ne soit plus enfant 
        rigidbodyObj.constraints = RigidbodyConstraints.None; // Désactive les contraintes appliqués au Rigidbody (fixation des positions)
        heldObj = null;
        Debug.Log("objet lancé");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(gameObject.transform.position, transform.forward * pickUpRange);
    }
}
