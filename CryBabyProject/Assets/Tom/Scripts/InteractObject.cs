using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [SerializeField] ObjetInteractif[] allTools;

    public void CheckObject(GameObject myObj)
    {
        for (int i = 0; i < allTools.Length;  i++)
        {
            Debug.Log("Element " + i + " : " + allTools[i].tools.name);

            if (myObj != null)
            {
                if (myObj.transform.name == allTools[i].tools.name)
                {
                    Debug.Log("entré");
                    if (myObj.CompareTag("WrongObject"))
                    {
                        Debug.Log("WrongObject");
                    }
                    else if (myObj.CompareTag("GoodObject"))
                    {
                        Debug.Log("GoodObject");
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
