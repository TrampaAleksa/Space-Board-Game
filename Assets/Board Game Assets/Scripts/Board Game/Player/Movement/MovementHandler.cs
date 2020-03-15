using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public float fuelPerField = 0.5f;
    public bool moveForward = true;
    IPlayerFieldMovement move;

    void Awake()
    {
        move = new Move(fuelPerField);
    }

    public GameObject MoveNFields(int n, GameObject player)
    {
        moveForward = move.MoveNFields(n, player);
        return player;
    }

    public GameObject MoveToNextField(GameObject player)
    {
        move.MoveToNextField(player);
        return player;
    }

    public GameObject MoveToPreviousField(GameObject player)
    {
        move.MoveToPreviousField(player);
        return player;
    }

    public void MoveCurrentPlayer(int numberOfFields)
    {
        GameObject currentPlayer = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer();
        InstanceManager.Instance.Get<MovementHandler>().MoveNFields(numberOfFields, currentPlayer);
    }
}