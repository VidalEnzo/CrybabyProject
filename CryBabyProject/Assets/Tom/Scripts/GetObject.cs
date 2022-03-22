using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    float launchForce = 600;
    float distance;
    Vector3 posObj;
    

    public bool canHold = true;
    public bool isHolding = false;
    public GameObject item;
    public GameObject tempParent;

    private void Update()
    {
        Grab();

        if(isHolding == true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            if(Input.GetMouseButtonDown(1))
            {
                //throw
            }
        }
        else
        {
            posObj = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = posObj;
        }
    }

    void Grab()
    {

            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;

        
    }

    private void OnMouseUp()
    {
        isHolding = false;
        //item.GetComponent<Rigidbody>().useGravity = true;
        //item.GetComponent<Rigidbody>().detectCollisions = false;
    }
}
