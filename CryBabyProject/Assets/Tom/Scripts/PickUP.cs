using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUP : MonoBehaviour
{
    public float pickUpRange = 1;
    public float launchForce = 250;
    public Transform container;
    //float distance;
    GameObject heldObj;
    public Text interactUI;

    private void Update()
    {
        //distance = Vector3.Distance(heldObj.transform.position, gameObject.GetComponentInParent<Transform>().position);
        if(heldObj == null)
        {
            RaycastHit raycast;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycast, pickUpRange))
            {
                Debug.Log(raycast.collider.gameObject);
                interactUI.enabled = true;

            }

        }
        
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(heldObj == null)
            {
                RaycastHit hit;
                Debug.Log("tir lance");

                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    Debug.Log(hit.collider.gameObject);

                    // Ignore le GameObject avec le Layer "Ignore Layer"
                    gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

                    Grab(hit.transform.gameObject);
                    interactUI.enabled = false;
                    Debug.Log("objet prit");

                    //Debug.Log(distance);
                    //if (distance <= 2f)
                    //{
                    //    Debug.Log("trop loin");
                    //    Drop();
                    //}

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Drop();
                        MoveObject();
                        Debug.Log("objet lancé");
                    }
                }
            }
            else
            {
                Drop();
                Debug.Log("objet laché");
            } 
        }
    }

    void MoveObject()
    {
        Vector3 moveDirection = (container.position - heldObj.transform.position);
        heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * launchForce);

    }

    void Grab(GameObject grabedObj)
    {
        if(grabedObj.GetComponent<Rigidbody>())
        {
            Rigidbody rigObj = grabedObj.GetComponent<Rigidbody>();
            rigObj.useGravity = false;
            rigObj.constraints = RigidbodyConstraints.FreezePositionY;
            rigObj.drag = 10;

            rigObj.transform.parent = container;
            heldObj = grabedObj;
            heldObj.transform.localPosition = Vector3.zero;
        }
    }

    void Drop()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;
        heldRig.constraints = RigidbodyConstraints.None;

        heldObj.transform.parent = null;
        heldObj = null;
    }
}
