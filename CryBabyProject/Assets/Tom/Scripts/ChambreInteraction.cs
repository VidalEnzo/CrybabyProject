using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChambreInteraction : MonoBehaviour
{
    //public GameObject door;
    public InteractObject myTool;

    //Collider doorCol;

    private void Update()
    {
        //();
    }

    //public void GetObject()
    //{
    //    doorCol = door.GetComponent<Collider>();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
        }
        Debug.Log("detection collision");
        myTool.CheckObject(other.gameObject);
        
    }


}