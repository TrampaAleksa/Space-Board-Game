using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFieldMovement : MonoBehaviour
{
    public GameObject MoveNFields(int n, GameObject player)
    {
        FieldHandler path = InstanceManager.Instance.Get<FieldHandler>();
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        int spacesToMove = playerMovement.spacesToMove = n;
        int currentPathIndex = playerMovement.currentPlayerField.GetComponent<Field>().IndexInPath;
        GameObject lastField = path.MemberWithIndex(currentPathIndex + spacesToMove);
        //GameObject lastField = currentPathIndex + spacesToMove >= path.gameObjects.Length ?
        //    path.MemberWithIndex(currentPathIndex + spacesToMove - path.gameObjects.Length) :
        //    path.MemberWithIndex(currentPathIndex + spacesToMove);
        lastField.tag = "LastField";
        MoveToNextField(player, currentPathIndex);
        return player;
    }

    public GameObject MoveToNextField(GameObject player, int currentPathIndex)
    {
        FieldHandler path = InstanceManager.Instance.Get<FieldHandler>();
        player.GetComponent<PlayerMovement>().spacesToMove--;

        int nextPathIndex = (currentPathIndex + 1) % (path.gameObjects.Length);
        if (path.MemberWithIndex(nextPathIndex).tag != "LastField")
        {
            path.MemberWithIndex(nextPathIndex).tag = "NextField";
        }
        InstanceManager.Instance.Get<FieldHandler>().SetCurrentField(nextPathIndex, player.gameObject);
        return player;
    }

}
