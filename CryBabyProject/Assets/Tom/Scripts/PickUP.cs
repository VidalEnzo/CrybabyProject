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
            interactUI.enabled = false; //d�sactive le texte du Canvas

            RaycastHit raycast; // Initialisation d'un Raycast
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycast, pickUpRange)) // Sile Raycast touche un objet dans la port�e de pickUpRange
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

                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange)) // Lance un Raycast dans la port�e de pickUpRange
                {

                    
                    gameObject.layer = LayerMask.NameToLayer("Ignore Raycast"); // Ignore le GameObject avec le Layer "Ignore Layer"

                    Grab(hit.transform.gameObject); // Proc�de au code de la fonction Grab()
                    interactUI.enabled = false; // D�sactive le texte du Canvas
                }

            }
            else
            {
                Drop(); // Si le joueur rappuie sur E, acc�de au code de la fonction Drop()
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
        Rigidbody rigObj = grabedObj.GetComponent<Rigidbody>(); // Initialisation et r�cup�ration du Rigidbody de l'objet attrap�
        Collider colObj = grabedObj.GetComponent<Collider>(); // Initialisation et r�cup�ration du Collider de l'objet attrap�

        colObj.isTrigger = true; // Dans le Collider, set l'option isTrigger � true
        grabedObj.transform.parent = container; //D�place l'objet s�lectionn� en enfant du gameObject "container"
        rigObj.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ; // Force les poistions de l'objet s�lectionn� � �tre fixe 
        heldObj = grabedObj;
        heldObj.transform.localPosition = Vector3.zero; // Place l'objet s�lectionn� au centre du gameObject parent
        rigObj.useGravity = false; // D�sactive la graivt� du Rigidbody de l'objet s�lectionn� 
        rigObj.velocity = Vector3.zero; // R�initialise la v�locit� (force appliqu�e par le Rigidbody) de l'objet s�lectionn�
        rigObj.angularVelocity = Vector3.zero; // R�initialise la v�locit� angulaire (force de rotation appliqu�e par le Rigidbody) de l'objet s�lectionn�

        

        //rigObj.isKinematic = true;
    }

    public void Drop()
    {
        Rigidbody  heldRig = heldObj.GetComponent<Rigidbody>(); // Initialisation et r�cup�ration du Rigidbody de l'objet attrap�
        Collider colObj = heldObj.GetComponent<Collider>(); // Initialisation et r�cup�ration du Collider de l'objet attrap�

        colObj.isTrigger = false; // Dans le Collider, set l'option isTrigger � false
        heldRig.useGravity = true; // R�sactive la graivt� du Rigidbody de l'objet s�lectionn� 
        heldObj.transform.parent = null; // D�tache l'objet tenu par le gameObject parent pour qu'il ne soit plus enfant 
        heldRig.constraints = RigidbodyConstraints.None; // D�sactive les contraintes appliqu�s au Rigidbody (fixation des positions)

        heldObj = null; // Plus aucun gameObject n'est alors tenu 
        heldRig.velocity = Vector3.zero; // R�initialise la v�locit� (force appliqu�e par le Rigidbody) de l'objet s�lectionn�
        heldRig.angularVelocity = Vector3.zero; // R�initialise la v�locit� angulaire (force de rotation appliqu�e par le Rigidbody) de l'objet s�lectionn�

        //heldRig.isKinematic = false;

    }

    void Throw()
    { 
        Rigidbody rigidbodyObj = heldObj.GetComponent<Rigidbody>();
        Collider colObj = heldObj.GetComponent<Collider>(); // Initialisation et r�cup�ration du Collider de l'objet attrap�

        colObj.isTrigger = false; // Dans le Collider, set l'option isTrigger � false
        heldObj.GetComponent<Rigidbody>().AddForce(container.forward * launchForce); // Ajoute une force dans la direction de devant pour simuler le lancer d'un objet
        rigidbodyObj.useGravity = true; // R�sactive la graivt� du Rigidbody de l'objet s�lectionn� 
        heldObj.transform.parent = null; // D�tache l'objet tenu par le gameObject parent pour qu'il ne soit plus enfant 
        rigidbodyObj.constraints = RigidbodyConstraints.None; // D�sactive les contraintes appliqu�s au Rigidbody (fixation des positions)
        heldObj = null;
        Debug.Log("objet lanc�");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(gameObject.transform.position, transform.forward * pickUpRange);
    }
}
