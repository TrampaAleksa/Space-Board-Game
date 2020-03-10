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
        return InstanceManager.Instance.Get<FieldHandler>().MemberWithIndex(IndexInPath + 1).GetComponent<Field>();
    }

    public Field NthField(int n)
    {
        return InstanceManager.Instance.Get<FieldHandler>().MemberWithIndex(IndexInPath + n).GetComponent<Field>();
    }

    public Field PreviousField()
    {
        return InstanceManager.Instance.Get<FieldHandler>().MemberWithIndex(IndexInPath - 1).GetComponent<Field>();
    }

    public GameObject RemovePlayerFromField(GameObject player)
    {
        playersOnField--;
        return player;
    }

    public GameObject AddPlayerToField(GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.currentPlayerField = this;
        playersOnField++;
        playerMovement.positionToTravelTo = GetFreeAltPoint().gameObject.transform.position;
        return player;
    }

    public GameObject GetFreeAltPoint()
    {
        if (playersOnField == 0 || playersOnField > 4) print("Error, negative players on field or more than 4");
        return altPoints[playersOnField - 1].gameObject;
    }

    public Field InitialSetUpField(int indexInFieldsArray)
    {
        altPoints = GetComponentsInChildren<FieldAltPoint>();
        IndexInPath = indexInFieldsArray;
        return this;
    }

    public override bool Equals(object obj)
    {
        return obj is Field field &&
               base.Equals(obj) &&
               IndexInPath == field.IndexInPath;
    }
}