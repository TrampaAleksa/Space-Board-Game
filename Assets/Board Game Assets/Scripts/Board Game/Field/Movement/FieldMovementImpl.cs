using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMovementImpl : IFieldMovement
{
    public void SetCurrentField(Field fieldToSetTo, GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        Field originalField = playerMovement.currentPlayerField;
        originalField.RemovePlayerFromField(player);

        fieldToSetTo.AddPlayerToField(player);
    }

    public void SwapTwoPlayers(PlayerMovement playerMovement1, PlayerMovement playerMovement2)
    {
        Field originalField1 = playerMovement1.currentPlayerField;
        Field originalField2 = playerMovement2.currentPlayerField;

        originalField1.RemovePlayerFromField(playerMovement1.gameObject);
        originalField2.RemovePlayerFromField(playerMovement2.gameObject);

        originalField2.AddPlayerToField(playerMovement1.gameObject);
        originalField1.AddPlayerToField(playerMovement2.gameObject);
    }

    public void TeleportPlayerToField(GameObject player, Field field)
    {
        SetCurrentField(field, player);
        AudioManager.Instance.PlaySound("teleport");
        player.GetComponent<PlayerMovement>().transform.position = player.GetComponent<PlayerMovement>().positionToTravelTo;
    }
}