using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public int IndexInPath = 0;
    [SerializeField]
    //public FieldAltPoints currentFieldAltPoints;
    public FieldAltPoint[] altPoints;
    public int playersOnField = 0;

    public Field NextField()
    {
        return InstanceManager.Instance.Get<FieldHandler>().MemberWithIndex(IndexInPath+1).GetComponent<Field>();
    }

    public GameObject RemovePlayerFromField(GameObject player)
    {
        playersOnField--;
        return player;
    }

    public GameObject AddPlayerToField(GameObject player)
    {
        playersOnField++;
        return player;
    }

    public GameObject GetFreeAltPoint()
    {
        foreach(var altPoint in altPoints)
        {
            if (altPoint.IsFree) return altPoint.gameObject;
        }
        print("Error, all points are not free");
        return null;
    }


    public Field InitialSetUpField(int indexInFieldsArray)
    {
        altPoints = GetComponentsInChildren<FieldAltPoint>();
        IndexInPath = indexInFieldsArray;
        return this;
    }


}
