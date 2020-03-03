using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected FieldHandler path;
    [SerializeField]
    public Field currentPlayerField;
    public int turnsToSkip;

    public bool EnginesBroken()
    {
        return turnsToSkip > 0;
    }

}
