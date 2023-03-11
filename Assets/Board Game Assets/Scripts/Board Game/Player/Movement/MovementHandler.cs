using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public float fuelPerField = 0.5f;
    public bool moveForward = true;
    IPlayerFieldMovement move;
    private PlayersHandler _playersHandler;

    private void Start()
    {
        move = new Move(fuelPerField);
        _playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
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

    public int moveTest = 1;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            MoveCurrentPlayer(moveTest);
        }
    }

    public void MoveCurrentPlayer(int numberOfFields)
    {
        GameObject currentPlayer = _playersHandler.GetCurrentPlayer();
        MoveNFields(numberOfFields, currentPlayer);
    }
}