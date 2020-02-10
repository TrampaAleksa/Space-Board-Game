using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldHandler : GenericObjectArray   
{
    private void Awake()
    {
        InitializeFields();
    }
    public void SetCurrentField(int fieldIndex, GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        Field originalField = playerMovement.currentPlayerField;
        originalField.RemovePlayerFromField(player);

        Field fieldToMoveTo = MemberWithIndex(fieldIndex).GetComponent<Field>();
        fieldToMoveTo.AddPlayerToField(player);
        //maybe move the position to travel to into the AddPlayerToField method
        playerMovement.positionToTravelTo = fieldToMoveTo.GetFreeAltPoint().gameObject.transform.position;
    }

    public GameObject SetupPlayerFieldOnLoad(GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        FirstMember().GetComponent<Field>().AddPlayerToField(player);
        playerMovement.positionToTravelTo = playerMovement.currentPlayerField.transform.position;
        return player;
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
