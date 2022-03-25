using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    GameObject [] intObject;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision avec : " + other.gameObject.name);
        CheckObject();
    }

    void CheckObject()
    {
        for(int i = 0; i <= intObject.Length; i++)
        {
            if (intObject[i].CompareTag("GoodObject"))
            {
                Debug.Log("GoodObject");
            }
            else if(intObject[i].CompareTag("WrongObject"))
            {
                Debug.Log("WrongObject");
            }
        }
    }
}
