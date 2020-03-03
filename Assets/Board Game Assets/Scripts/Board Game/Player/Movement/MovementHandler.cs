using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public GameObject MoveNFields(int n, GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        GameObject lastField = playerMovement.currentPlayerField.NthField(n).gameObject;
        lastField.tag = "LastField";
        GameObject field = n < 0 ? MoveToPreviousField(player) : MoveToNextField(player);
        return player;
    }

    public GameObject MoveToNextField(GameObject player)
    {
        Field currentPlayerField = player.GetComponent<PlayerMovement>().currentPlayerField;
        if (currentPlayerField.NextField().tag != "LastField")
        {
            currentPlayerField.NextField().tag = "NextField";
        }
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

    public void MoveCurrentPlayer(int numberOfFields)
    {
        GameObject currentPlayer = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
        InstanceManager.Instance.Get<MovementHandler>().MoveNFields(numberOfFields, currentPlayer);
    }
}