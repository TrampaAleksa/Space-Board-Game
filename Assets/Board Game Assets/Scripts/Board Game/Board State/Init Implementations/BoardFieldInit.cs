using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardFieldInit : MonoBehaviour, IBoardStateInitializer
{
    public void SavePlayerState(GameObject player, PlayerBoardState playerState)
    {
        int index = playerState.pathIndex
            = player.GetComponent<PlayerMovement>().currentPlayerField.IndexInPath;
        print("Saved players position index: " + index);
    }

    public void SetupPlayerState(GameObject player, PlayerBoardState playerState)
    {
        int index = playerState.pathIndex;
        var fieldHandler = InstanceManager.Instance.Get<FieldHandler>();
        fieldHandler.MemberWithIndex(index).GetComponent<Field>().AddPlayerToField(player);
        fieldHandler.TeleportPlayerToField(player, fieldHandler.MemberWithIndex(index).GetComponent<Field>());
    }
}
