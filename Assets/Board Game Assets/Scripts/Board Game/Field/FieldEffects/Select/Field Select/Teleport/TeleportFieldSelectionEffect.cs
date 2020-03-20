using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFieldSelectionEffect : MonoBehaviour, ISelectionEffect
{
    public void ConfirmedSelection()
    {
        Teleport.TryTeleporting(new PlayerAndFieldReferences());
    }
}

public class PlayerAndFieldReferences
{
    public GameObject playerToTeleport;
    public Field playersField;
    public Field selectedFieldComponent;

    public PlayerAndFieldReferences()
    {
        playerToTeleport = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
        playersField = playerToTeleport.GetComponent<PlayerMovement>().currentPlayerField;
        selectedFieldComponent = InstanceManager.Instance.Get<FieldSelectionHandler>().GetCurrentField();
    }
}