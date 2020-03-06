using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFieldMovement
{
    void SetCurrentField(Field fieldToSetTo, GameObject player);

    void TeleportPlayerToField(GameObject player, Field field);

    void SwapTwoPlayers(PlayerMovement playerMovement1, PlayerMovement playerMovement2);
}