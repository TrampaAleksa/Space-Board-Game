using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    protected FieldPath path;
    public GameObject MoveNFields(GameObject player)
    {
        
        return null;
    }

    private void Start()
    {
        path = InstanceManager.Instance.Get<FieldPath>();
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
        return null;
}
   
}
