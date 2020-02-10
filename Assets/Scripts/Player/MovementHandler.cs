using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public GameObject MoveNFields(int n, GameObject player)
    {
        FieldHandler path = InstanceManager.Instance.Get<FieldHandler>();
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        int spacesToMove = playerMovement.spacesToMove = n;
        int currentPathIndex = playerMovement.currentPlayerField.IndexInPath;
        GameObject lastField = path.MemberWithIndex(currentPathIndex + spacesToMove);

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
        //Refactoring SetCurrentField to accept field instead of an index
        InstanceManager.Instance.Get<FieldHandler>().SetCurrentField(currentPlayerField.NextField(), player.gameObject);
        return player;
    }

}
