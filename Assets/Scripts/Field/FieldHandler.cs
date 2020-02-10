using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldHandler : GenericObjectArray, IBoardState
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

    public void SaveState()
    {
    }

    public void SetupState()
    {
        int i = 0;
        foreach(var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            int index = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].pathIndex;
            MemberWithIndex(index).GetComponent<Field>().AddPlayerToField(player);
            i++;
        }
    }
}
