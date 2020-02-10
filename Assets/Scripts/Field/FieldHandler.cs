﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldHandler : GenericObjectArray   
{
    private void Awake()
    {
        InitializeFields();
    }
    public void SetCurrentField(Field fieldToSetTo, GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        Field originalField = playerMovement.currentPlayerField;
        originalField.RemovePlayerFromField(player);

        fieldToSetTo.AddPlayerToField(player);
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
