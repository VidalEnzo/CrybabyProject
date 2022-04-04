using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeofObject : MonoBehaviour
{
    [SerializeField]
    EnumObject objet;

    public EnumObject typeOfObject => objet;
}
