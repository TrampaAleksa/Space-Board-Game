using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : IPlayerFieldMovement
{

    private float fuelPerField;

    public Move(float fuelPerField){
        this.fuelPerField = fuelPerField;
    }

    public bool MoveNFields(int n, GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        bool moveForward;
        GameObject lastField = playerMovement.currentPlayerField.NthField(n).gameObject;
        lastField.tag = "LastField";
        moveForward = n > 0;
        GameObject field = moveForward ? MoveToNextField(player) : MoveToPreviousField(player);
        return moveForward;
    }

      public GameObject MoveToNextField(GameObject player)
    {
        Field currentPlayerField = player.GetComponent<PlayerMovement>().currentPlayerField;
        if (currentPlayerField.NextField().tag != "LastField")
        {
            currentPlayerField.NextField().tag = "NextField";
        }
        InstanceManager.Instance.Get<FuelHandler>().RemoveFuelFromPlayer(player, fuelPerField, false);
        //ship movement sound?
        InstanceManager.Instance.Get<FieldHandler>().SetCurrentField(currentPlayerField.NextField(), player.gameObject);
        return player;
    }

    public GameObject MoveToPreviousField(GameObject player)
    {
        Field currentPlayerField = player.GetComponent<PlayerMovement>().currentPlayerField;
        if (currentPlayerField.PreviousField().tag != "LastField")
        {
            currentPlayerField.PreviousField().tag = "NextField";
        }
        //ship movement sound?
        InstanceManager.Instance.Get<FieldHandler>().SetCurrentField(currentPlayerField.PreviousField(), player.gameObject);
        return player;
    }
}
