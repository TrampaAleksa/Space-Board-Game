using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldHandler : GenericObjectArray   
{
    private void Start()
    {
        InitializeFields();
    }
    public void SetCurrentField(int fieldIndex, GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        //update the current field to be without the player

        playerMovement.currentField = MemberWithIndex(playerMovement.playersCurrentPathIndex);
        playerMovement.currentFieldAltPoints = playerMovement.currentField.GetComponent<FieldAltPoints>();
        playerMovement.currentFieldAltPoints.playersOnField--;

        //get the field you are supposed to move to
        playerMovement.playersCurrentPathIndex = fieldIndex;
        playerMovement.currentField = MemberWithIndex(fieldIndex);
        playerMovement.currentFieldAltPoints = playerMovement.currentField.GetComponent<FieldAltPoints>();

        //Update the next field to have the player on it
        FieldAltPoints nextFieldAltPoints = playerMovement.currentFieldAltPoints;
        nextFieldAltPoints.playersOnField++;
        playerMovement.positionToTravelTo = nextFieldAltPoints.altPoints[nextFieldAltPoints.playersOnField - 1].transform.position;
    }
        
    public void InitializeFields()
    {
        int i = 0;
        foreach(var field in gameObjects)
        {
            field.AddComponent<Field>();
            field.GetComponent<Field>().InitialSetUpField(i);
            i++;
        }
    }

}
