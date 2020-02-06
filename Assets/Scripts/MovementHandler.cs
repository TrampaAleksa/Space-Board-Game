using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    protected FieldPath path;
    private void Start()
    {
        path = InstanceManager.Instance.Get<FieldPath>();
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

    public GameObject MoveToNextField(GameObject player,int currentPathIndex)
    {
        path = InstanceManager.Instance.Get<FieldPath>();

        player.GetComponent<PlayerMovement>().spacesToMove--;

        int nextPathIndex = (currentPathIndex + 1) % (path.fields.Length);
        if (path.fields[nextPathIndex].tag != "LastField")
        {
            path.fields[nextPathIndex].tag = "NextField";
        }

        player.GetComponent<PlayerMovement>().SetCurrentField(nextPathIndex);
        return player;
}
   
}
