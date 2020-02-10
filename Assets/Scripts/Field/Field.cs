using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public int IndexInPath = 0;
    [SerializeField]
    public FieldAltPoint[] altPoints;
    public int playersOnField = 0;

    public Field NextField()
    {
        return InstanceManager.Instance.Get<FieldHandler>().MemberWithIndex(IndexInPath+1).GetComponent<Field>();
    }
    public Field NthField(int n)
    {
       return  InstanceManager.Instance.Get<FieldHandler>().MemberWithIndex(IndexInPath+n).GetComponent<Field>();
    }

    public GameObject RemovePlayerFromField(GameObject player)
    {
        playersOnField--;
        return player;
    }

    public GameObject AddPlayerToField(GameObject player)
    {
        player.GetComponent<PlayerMovement>().currentPlayerField = this;
        playersOnField++;
        return player;
    }

    public GameObject GetFreeAltPoint()
    {
        if (playersOnField == 0 || playersOnField > 4) print("Error, negative players on field or more than 4");
        return altPoints[playersOnField-1].gameObject;
        /*foreach(var altPoint in altPoints)
        {
            if (altPoint.IsFree) return altPoint.gameObject;
        }
        print("Error, all points are not free");
        return null;*/
    }


    public Field InitialSetUpField(int indexInFieldsArray)
    {
        altPoints = GetComponentsInChildren<FieldAltPoint>();
        IndexInPath = indexInFieldsArray;
        return this;
    }


}
