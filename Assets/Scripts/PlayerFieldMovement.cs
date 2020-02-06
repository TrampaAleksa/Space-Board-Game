using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFieldMovement : MovementHandler
{
    public void SetCurrentField(int fieldIndex, GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        //update the current field to be without the player
        
        playerMovement.currentField = path.fields[playerMovement.currentPathIndex];
        playerMovement.currentFieldAltPoints = playerMovement.currentField.GetComponent<FieldAltPoints>();
        playerMovement.currentFieldAltPoints.playersOnField--;

        //get the field you are supposed to move to
        playerMovement.currentPathIndex = fieldIndex;
        playerMovement.currentField = path.fields[fieldIndex];
        playerMovement.currentFieldAltPoints = playerMovement.currentField.GetComponent<FieldAltPoints>();

        //Update the next field to have the player on it
        FieldAltPoints nextFieldAltPoints = playerMovement.currentFieldAltPoints;
        nextFieldAltPoints.playersOnField++;
        playerMovement.positionToTravelTo = nextFieldAltPoints.altPoints[nextFieldAltPoints.playersOnField - 1].transform.position;

    }

    public GameObject MoveNFields(int n, GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        int spacesToMove = playerMovement.spacesToMove = n;
        int currentPathIndex = playerMovement.currentPathIndex;

        GameObject lastField = currentPathIndex + spacesToMove >= path.fields.Length ?
            path.fields[currentPathIndex + spacesToMove - path.fields.Length] :
            path.fields[currentPathIndex + spacesToMove];
        lastField.tag = "LastField";
        MoveToNextField(player, currentPathIndex);
        return player;
    }

    public GameObject MoveToNextField(GameObject player, int currentPathIndex)
    {
        path = InstanceManager.Instance.Get<FieldPath>();

        player.GetComponent<PlayerMovement>().spacesToMove--;

        int nextPathIndex = (currentPathIndex + 1) % (path.fields.Length);
        if (path.fields[nextPathIndex].tag != "LastField")
        {
            path.fields[nextPathIndex].tag = "NextField";
        }
        InstanceManager.Instance.Get<PlayerFieldMovement>().SetCurrentField(nextPathIndex, player.gameObject);
        //player.GetComponent<PlayerMovement>().SetCurrentField(nextPathIndex);
        return player;
    }

}
