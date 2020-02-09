using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected FieldHandler path;
    public GameObject currentField;
    public int playersCurrentPathIndex = 0;
    [SerializeField]
    public FieldAltPoints currentFieldAltPoints;

}
