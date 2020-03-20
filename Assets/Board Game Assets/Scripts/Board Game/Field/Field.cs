using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public int IndexInPath = 0;

    [SerializeField]
    public FieldAltPoint[] altPoints;

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
        player.GetComponent<PlayerMovement>().altFieldOn.IsFree = true;
        return player;
    }

    public GameObject AddPlayerToField(GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        
        playerMovement.currentPlayerField = this;
        playerMovement.altFieldOn = SetPlayerToFreeAltPoint();
        
        playerMovement.positionToTravelTo = playerMovement.altFieldOn.gameObject.transform.position;
        return player;
    }

    public FieldAltPoint SetPlayerToFreeAltPoint()
    {
        for (int i = 0; i < altPoints.Length; i++)
        {
            if (altPoints[i].IsFree)
            {
                altPoints[i].IsFree = false;
                return altPoints[i];
            }
        }
        Debug.Log("error, no alt point is free");
        return null;
    }

    public Field InitialSetUpField(int indexInFieldsArray)
    {
        altPoints = GetComponentsInChildren<FieldAltPoint>();
        foreach (var altPoint in altPoints)
        {
            altPoint.IsFree = true;
        }
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