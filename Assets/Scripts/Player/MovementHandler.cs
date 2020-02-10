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
        MoveToNextField(player);
        return player;
    }
    public GameObject MoveToNextField(GameObject player)
    {
        Field currentPlayerField = player.GetComponent<PlayerMovement>().currentPlayerField;
        if (currentPlayerField.NextField().tag != "LastField")
        {
            currentPlayerField.NextField().tag = "NextField";
        }
        InstanceManager.Instance.Get<FieldHandler>().SetCurrentField(currentPlayerField.NextField(), player.gameObject);
        return player;
    }

}
