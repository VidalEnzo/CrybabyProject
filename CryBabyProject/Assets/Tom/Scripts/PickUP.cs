using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    public float pickUpRange = 1;
    public float launchForce = 250;
    public Transform container;
    float distance;
    GameObject heldObj;

    private void Update()
    {
        distance = Vector3.Distance(heldObj.transform.position, gameObject.GetComponentInParent<Transform>().position);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(heldObj == null)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    Debug.Log(hit.collider.gameObject);
                    // Ignore le GameObject avec le Layer "Ignore Layer"
                    gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                    Grab(hit.transform.gameObject);
                    Debug.Log("objet prit");

                    Debug.Log(distance);
                    if (distance <= 2f)
                    {
                        Debug.Log("trop loin");
                        Drop();
                    }

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Drop();
                        MoveObject();
                        Debug.Log("objet lanc�");
                    }
                }
            }
            else
            {
                Drop();
                Debug.Log("objet lach�");
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
