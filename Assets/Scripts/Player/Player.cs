using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected FieldHandler path;
    public int playersCurrentPathIndex = 0;
    [SerializeField]
    public FieldAltPoints currentFieldAltPoints;
    public GameObject currentPlayerField;

}
